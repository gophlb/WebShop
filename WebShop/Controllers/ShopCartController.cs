using BLL;
using Core;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class ShopCartController : Controller
    {
        private IShopCartManager shopCartManager;
        private IProductManager productManager;
        private IOrderManager orderManager;


        public ShopCartController(IShopCartManager shopCartManager, IProductManager productManager, IOrderManager orderManager)
        {
            this.shopCartManager = shopCartManager;
            this.productManager = productManager;
            this.orderManager = orderManager;
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


        public ActionResult Checkout() 
        {
            /*
            ShippingDetails sd = new ShippingDetails()
            {
                Street = "Street",
                CityId = 1,
                CityName = "City",
                Email = "email@email.com",
                FirstName = "FirstName",
                LastName = "LastName",
                Title = "Mr",
                ZipCode = 111111
            };
            orderManager.Checkout(sd);
            */

            return null;
        }

    }
}