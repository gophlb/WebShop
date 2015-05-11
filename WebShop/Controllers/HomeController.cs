using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Web Shop";
            return View();
        }
    }
}