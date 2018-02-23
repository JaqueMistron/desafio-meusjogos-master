using AutoMapper;
using MeusJogos.Business.Interface;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;
using MeusJogos.Util;
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
    public class AmigoController : Controller
    {
        #region Propriedades (Autowired)

        public IAmigoBusiness AmigoBusiness { get; set; }
        public IUsuarioBusiness UsuarioBusiness { get; set; }
        public IMapper Mapper { get; set; }

        #endregion

        #region Ajax

        [HttpGet]
        public PartialViewResult ListarJogosAmigo(int id)
        {
            var amigo = AmigoBusiness.BuscarAmigo(id);
            var amigoVm = Mapper.Map<Amigo, AmigoViewModel>(amigo);
            return PartialView("~/Views/Amigo/modal/_modalDetalharJogoAmigo.cshtml", amigoVm);
        }

        #endregion

        // GET: Amigo
        public ActionResult Index()
        {
            var lista = AmigoBusiness.ListarAmigos(User.Identity.Name);
            var listaAmigoViewModel = Mapper.Map<List<Amigo>, List<AmigoViewModel>>(lista);

            return View(listaAmigoViewModel);
        }

        // GET: Amigo/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var amigo = AmigoBusiness.BuscarAmigo(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            var amigoViewModel = Mapper.Map<Amigo, AmigoViewModel>(amigo);
            return View(amigoViewModel);
        }

        // GET: Amigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amigo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAmigo,Nome,Telefone")] AmigoViewModel amigoViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = UsuarioBusiness.BuscarUsuarioPorNome(User.Identity.Name);
                var amigo = Mapper.Map<Amigo>(amigoViewModel);
                amigo.IdUsuario = usuario.IdUsuario;
                amigo.Telefone = RecursosUtil.RemoverFormatacao(amigo.Telefone);
                AmigoBusiness.Salvar(amigo);
                return RedirectToAction("Index");
            }
            return View(amigoViewModel);
        }

        // GET: Amigo/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var amigo = AmigoBusiness.BuscarAmigo(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            var amigoViewModel = Mapper.Map<Amigo, AmigoViewModel>(amigo);
            return View(amigoViewModel);
        }

        // POST: Amigo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAmigo,Nome,Telefone")] AmigoViewModel amigoViewModel)
        {
            if (ModelState.IsValid)
            {
                var amigo = Mapper.Map<Amigo>(amigoViewModel);
                var usuario = UsuarioBusiness.BuscarUsuarioPorNome(User.Identity.Name);
                amigo.IdUsuario = usuario.IdUsuario;
                amigo.Telefone = RecursosUtil.RemoverFormatacao(amigo.Telefone);
                AmigoBusiness.Salvar(amigo);
                return RedirectToAction("Index");
            }
            return View(amigoViewModel);
        }
        
        // GET: Amigo/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var amigo = AmigoBusiness.BuscarAmigo(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            var amigoViewModel = Mapper.Map<Amigo, AmigoViewModel>(amigo);
            return View(amigoViewModel);
        }

        // POST: Amigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AmigoBusiness.Excluir(id);
            return RedirectToAction("Index");
        }
        
    }
}
