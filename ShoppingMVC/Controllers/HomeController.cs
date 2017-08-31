using System.Linq;
using System.Web.Mvc;
using DataLayer;

namespace ShoppingMVC.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            var db = new ShoppingEntities();
            var lista = db.Listas.FirstOrDefault(l => l.Aberta);
            return View(lista);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}