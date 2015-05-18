using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "The RGB Shop";
            return View();
        }

        public ActionResult Greeting()
        {
            return PartialView();
        }
    }
}