using BLL;
using Core;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

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
            shopCartManager.Add(reference, quantity);

            int productsCount = shopCartManager.Count();
            return Content(productsCount.ToString());
        }


        public ActionResult RemoveProduct(string reference, int quantity = 1)
        {
            ProcessResult processResult = new ProcessResult
            {
               Result = (int)ProcessResult.RESULT_STATES.OK,
               Message = "",
               RedirectTo = "/ShopCart/Detail"
            };

            try
            {
                shopCartManager.Remove(reference, quantity);
            }
            catch
            {
                processResult.Result = (int)ProcessResult.RESULT_STATES.KO;
                processResult.Message = "Something went wrong";
                processResult.RedirectTo = "";
            }

            return Json(processResult);
        }


        public ActionResult GetProductsCount()
        {
            int productsCount = shopCartManager.Count();
            return Content(productsCount.ToString());
        }


        public ActionResult ShippingDetails()
        {
            return PartialView();
        }


        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            // Access not through the web. Should be valid with the javascript validation.
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            ProcessResult processResult = new ProcessResult
            {
                Result = (int)ProcessResult.RESULT_STATES.OK,
                Message = "",
                RedirectTo = "/Home/Greeting"
            };

            try
            {
                orderManager.Checkout(shippingDetails);
            }
            catch
            {
                processResult.Result = (int)ProcessResult.RESULT_STATES.KO;
                processResult.Message = "Something went wrong";
                processResult.RedirectTo = "";
            }

            if (processResult.Result == (int)ProcessResult.RESULT_STATES.OK)
            {
                shopCartManager.Clear();
            }

            return Json(processResult);
        }

    }
}