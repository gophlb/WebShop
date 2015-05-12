using BLL;
using Core;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace WebShop.Controllers
{
    public class ShopCartController : Controller
    {
        private IShopCartManager shopCartManager;
        private IProductManager productManager;
        private IOrderManager orderManager;
        private ICityManager cityManager;


        public ShopCartController(IShopCartManager shopCartManager, IProductManager productManager,
                                IOrderManager orderManager, ICityManager cityManager)
        {
            this.shopCartManager = shopCartManager;
            this.productManager = productManager;
            this.orderManager = orderManager;
            this.cityManager = cityManager;
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


        public ActionResult ShippingDetails()
        {
            List<CityViewModel> cities = cityManager.GetAll();
            IEnumerable<SelectListItem> citiesSelectList = cities.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });

            ViewBag.Cities = citiesSelectList;
            return PartialView();
        }


        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            orderManager.Checkout(shippingDetails);

            return Redirect("");
        }

    }
}