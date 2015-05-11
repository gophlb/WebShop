using BLL;
using Core;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class ShopCartController : Controller
    {
        private IShopCartManager shopCartManager;
        private IProductManager productManager;


        public ShopCartController(IShopCartManager shopCartManager, IProductManager productManager)
        {
            this.shopCartManager = shopCartManager;
            this.productManager = productManager;
        }


        public ActionResult Detail()
        {
            ShopCart shopCart = shopCartManager.Get();

            return PartialView(shopCart);
        }


        public ActionResult MiniDetail()
        {
            ShopCart shopCart = shopCartManager.Get();

            return PartialView(shopCart);
        }


        public ActionResult AddProduct(string reference, int quantity = 1)
        {
            string result = "";

            shopCartManager.Add(reference, quantity);

            return Content(result);
        }


        public ActionResult RemoveProduct(string reference, int quantity = 1)
        {
            string result = "";

            shopCartManager.Remove(reference, quantity);

            return Content(result);
        }

        public ActionResult MiniShopCart()
        {
            ViewBag.ProductsCount = shopCartManager.Count();
            return PartialView();
        }
    }
}