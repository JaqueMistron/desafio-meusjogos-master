using AutoMapper;
using MeusJogos.Business.Interface;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MeusJogos.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class JogoAmigoController : Controller
    {
        #region Propriedades (Autowired)

        public IMapper Mapper { get; set; }
        public IJogoAmigoBusiness JogoAmigoBusiness { get; set; }
        public IUsuarioBusiness UsuarioBusiness { get; set; }
        public IJogoBusiness JogoBusiness { get; set; }

        #endregion
        
        // GET: JogoAmigo
        public ActionResult Index()
        {
            var jogoAmigos = JogoAmigoBusiness.ListarJogosEmprestados(User.Identity.Name);
            var jogoAmigoViewModel = Mapper.Map<List<JogoAmigoViewModel>>(jogoAmigos);
            return View(jogoAmigoViewModel);
        }

        // GET: JogoAmigo/Details/5
        public ActionResult Details(int? idAmigo, int? idJogo)
        {
            if (idAmigo == null || idJogo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jogoAmigo = JogoAmigoBusiness.BuscarJogosEmprestadosPorUsuario(idAmigo.Value, idJogo.Value, User.Identity.Name);
            if (jogoAmigo == null)
            {
                return HttpNotFound();
            }

            var jogoAmigoViewModel = Mapper.Map<JogoAmigoViewModel>(jogoAmigo);
            return View(jogoAmigoViewModel);
        }

        // GET: JogoAmigo/Create
        public ActionResult Create()
        {
            CriarViewBagDropdownAmigos();
            CriarViewBagDropdownJogosDisponiveisEmprestimo();
            return View();
        }

        // GET: JogoAmigo/Edit/5
        public ActionResult Edit(int? idAmigo, int? idJogo)
        {
            if (idAmigo == null || idJogo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogoAmigo = JogoAmigoBusiness.BuscarJogosEmprestadosPorUsuario(idAmigo.Value, idJogo.Value, User.Identity.Name);
            if (jogoAmigo == null)
            {
                return HttpNotFound();
            }

            var jogoAmigoViewModel = Mapper.Map<JogoAmigoViewModel>(jogoAmigo);
            jogoAmigoViewModel.IdJogoAnterior = jogoAmigo.IdJogo;

            CriarViewBagDropdownAmigos(jogoAmigoViewModel.IdAmigo);
            CriarViewBagDropdownJogosDisponiveisAlteracao(jogoAmigo.Jogo);

            return View(jogoAmigoViewModel);
        }

        // GET: JogoAmigo/Delete/5
        public ActionResult Delete(int? idAmigo, int? idJogo)
        {
            if (idAmigo == null || idJogo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jogoAmigo = JogoAmigoBusiness.BuscarJogosEmprestadosPorUsuario(idAmigo.Value, idJogo.Value, User.Identity.Name);
            if (jogoAmigo == null)
            {
                return HttpNotFound();
            }
            var jogoAmigoViewModel = Mapper.Map<JogoAmigoViewModel>(jogoAmigo);
            return View(jogoAmigoViewModel);
        }
        
        // POST: JogoAmigo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAmigo,IdJogo,DataRetirada,DataDevolucao")] JogoAmigoViewModel jogoAmigoViewModel)
        {
            if (ModelState.IsValid && DataDevolucaoValidas(jogoAmigoViewModel))
            {
                var usuario = UsuarioBusiness.BuscarUsuarioPorNome(User.Identity.Name);
                var jogoAmigo = Mapper.Map<JogoAmigo>(jogoAmigoViewModel);
                jogoAmigo.IdUsuario = usuario.IdUsuario;
                JogoAmigoBusiness.Salvar(jogoAmigo);
                return RedirectToAction("Index");
            }

            CriarViewBagDropdownAmigos();
            CriarViewBagDropdownJogosDisponiveisEmprestimo();
            return View(jogoAmigoViewModel);
        }

        // POST: JogoAmigo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JogoAmigoViewModel jogoAmigoViewModel)
        {
            if (ModelState.IsValid && DataDevolucaoValidas(jogoAmigoViewModel))
            {
                JogoAmigoBusiness.Excluir(jogoAmigoViewModel.IdAmigo, jogoAmigoViewModel.IdJogoAnterior, User.Identity.Name);
                var usuario = UsuarioBusiness.BuscarUsuarioPorNome(User.Identity.Name);
                var jogoAmigo = Mapper.Map<JogoAmigo>(jogoAmigoViewModel);
                jogoAmigo.IdUsuario = usuario.IdUsuario;
                JogoAmigoBusiness.Salvar(jogoAmigo);
                return RedirectToAction("Index");
            }

            CriarViewBagDropdownAmigos(jogoAmigoViewModel.IdAmigo);
            var jogo = JogoBusiness.BuscarPorId(jogoAmigoViewModel.IdJogoAnterior);
            CriarViewBagDropdownJogosDisponiveisAlteracao(jogo);
            return View(jogoAmigoViewModel);
        }

        // POST: JogoAmigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idAmigo, int idJogo)
        {
            JogoAmigoBusiness.Excluir(idAmigo, idJogo, User.Identity.Name);
            return RedirectToAction("Index");
        }

        #region Métodos privados

        private void CriarViewBagDropdownAmigos(params int[] idAmigoSelecionado)
        {
            var amigos = JogoAmigoBusiness.BuscarAmigos(User.Identity.Name);
            var amigosViewModel = Mapper.Map<List<AmigoViewModel>>(amigos);
            if (idAmigoSelecionado.Any())
            {
                ViewBag.DropDownAmigos = new SelectList(amigosViewModel, "IdAmigo", "Nome", idAmigoSelecionado[0]);
            }
            else
            {
                ViewBag.DropDownAmigos = new SelectList(amigosViewModel, "IdAmigo", "Nome");
            }
        }

        private void CriarViewBagDropdownJogosDisponiveisEmprestimo()
        {
            var jogosDisponiveis = JogoAmigoBusiness.BuscarJogosDisponiveis(User.Identity.Name);
            var jogosDisponiveisViewModel = Mapper.Map<List<JogoViewModel>>(jogosDisponiveis);
            ViewBag.DropDownJogos = new SelectList(jogosDisponiveisViewModel, "IdJogo", "Titulo");
        }

        private void CriarViewBagDropdownJogosDisponiveisAlteracao(Jogo jogoAnterior)
        {
            var jogosDisponiveis = JogoAmigoBusiness.BuscarJogosDisponiveis(User.Identity.Name);
            jogosDisponiveis.Add(jogoAnterior);
            var jogosDisponiveisViewModel = Mapper.Map<List<JogoViewModel>>(jogosDisponiveis);
            ViewBag.DropDownJogos = new SelectList(jogosDisponiveisViewModel, "IdJogo", "Titulo", jogoAnterior.IdJogo);
        }

        private bool DataDevolucaoValidas(JogoAmigoViewModel jogoAmigoViewModel)
        {
            if (jogoAmigoViewModel.DataDevolucao.HasValue && jogoAmigoViewModel.DataDevolucao < jogoAmigoViewModel.DataRetirada)
            {
                ModelState.AddModelError("", "A Data de Devolução deve ser maior ou igual que a Data de Retirada");
                return false;
            }
            return true;
        }

        #endregion
    }
}