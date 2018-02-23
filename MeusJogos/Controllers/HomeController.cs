using System.Web.Mvc;
using MeusJogos.Business;
using AutoMapper;

namespace MeusJogos.Controllers
{
    public class HomeController : Controller
    {
        public JogoAmigoBusiness EmprestimoBusiness { get; set; }
        public IMapper Mapper { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}