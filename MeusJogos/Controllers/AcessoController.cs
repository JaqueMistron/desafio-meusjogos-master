using AutoMapper;
using MeusJogos.Business.Interface;
using MeusJogos.Domain.Entities;
using MeusJogos.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MeusJogos.Controllers
{
    [ValidateInput(false)]
    public class AcessoController : Controller
    {
        public IUsuarioBusiness UsuarioBusiness { get; set; }
        public IMapper Mapper { get; set; }

        // GET: Acesso
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Nome,Senha")] UsuarioViewModel usuario)
        {
            if (!ModelState["Nome"].Errors.Any() && !ModelState["Senha"].Errors.Any())
            {
                if (VerificarUsuarioValido(usuario))
                {
                    FormsAuthentication.RedirectFromLoginPage(usuario.Nome, true);
                }
                else
                {
                    ModelState.AddModelError("", "Nome de usuário e/ou senha inválidos.");
                }
            }
            return View(usuario);
        }
        
        // GET: Acesso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acesso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Senha")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!VerificarNomeUsuarioExistente(usuarioViewModel.Nome))
                {
                    var usuario = Mapper.Map<Usuario>(usuarioViewModel);                   
                    UsuarioBusiness.Salvar(usuario);
                    FormsAuthentication.RedirectFromLoginPage(usuario.Nome, true);
                }
                else
                {
                    ModelState.AddModelError("", "O Nome de usuário já existe! Escolha outro.");
                }
            }

            return View(usuarioViewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool VerificarNomeUsuarioExistente(string nomeUsuario)
        {
            return UsuarioBusiness.VerificarUsuarioExistente(nomeUsuario);
        }

        private bool VerificarUsuarioValido(UsuarioViewModel usuario)
        {
            var objUsuario = Mapper.Map<Usuario>(usuario);
            return UsuarioBusiness.ValidarUsuario(objUsuario);
        }
    }
}
