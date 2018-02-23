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
    public class JogoController : Controller
    {
        #region Propriedades (Autowired)

        public IMapper Mapper { get; set; }
        public IJogoBusiness JogoBusiness { get; set; }
        public IUsuarioBusiness UsuarioBusiness { get; set; }

        #endregion

        // GET: Jogos
        public ActionResult Index()
        {
            var listaJogos = JogoBusiness.ListarJogos(User.Identity.Name);
            var listaJogosViewModel = Mapper.Map<List<JogoViewModel>>(listaJogos);
            return View(listaJogosViewModel);
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogo = JogoBusiness.BuscarPorId(id.Value);

            if (jogo == null)
            {
                return HttpNotFound();
            }
            var jogoVm = Mapper.Map<JogoViewModel>(jogo);
            return View(jogoVm);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogo = JogoBusiness.BuscarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            var jogoViewModel = Mapper.Map<JogoViewModel>(jogo);
            return View(jogoViewModel);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogo = JogoBusiness.BuscarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            var jogoViewModel = Mapper.Map<JogoViewModel>(jogo);
            return View(jogoViewModel);
        }

        // POST: Jogos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJogo,Titulo,Versao,DataAquisicao")] JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid)
            {
                var jogo = Mapper.Map<Jogo>(jogoViewModel);
                var usuario = UsuarioBusiness.BuscarUsuarioPorNome(User.Identity.Name);
                jogo.IdUsuario = usuario.IdUsuario;
                JogoBusiness.Salvar(jogo);

                return RedirectToAction("Index");
            }
            return View(jogoViewModel);
        }

        // POST: Jogos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJogo,Titulo,Versao,DataAquisicao")] JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid)
            {
                var jogo = Mapper.Map<Jogo>(jogoViewModel);
                var usuario = UsuarioBusiness.BuscarUsuarioPorNome(User.Identity.Name);
                jogo.IdUsuario = usuario.IdUsuario;
                JogoBusiness.Salvar(jogo);
                return RedirectToAction("Index");
            }
            return View(jogoViewModel);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JogoBusiness.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult DetalharJogoAmigo(int id)
        {
            var jogo = JogoBusiness.BuscarPorId(id);
            var jogoEmprestado = jogo.ListaJogosEmprestados.FirstOrDefault();
            var jogoEmprestadoViewModel = Mapper.Map<JogoAmigo, JogoAmigoViewModel>(jogoEmprestado);
            return PartialView("~/Views/Jogo/modal/_modalDetalharJogoAmigo.cshtml", jogoEmprestadoViewModel);
        }
    }
}