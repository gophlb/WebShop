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
            return PartialView();
        }


        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            ProcessResult processResult = new ProcessResult
            {
                Result = (int)ProcessResult.RESULT_STATES.OK,
                Message = "",
                RedirectTo = ""
            };

            try
            {
                orderManager.Checkout(shippingDetails);
            }
            catch (Exception e)
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