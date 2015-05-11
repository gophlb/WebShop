using BLL;
using Core;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private const int PRODUCTS_PER_PAGE = 10;
        private IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }


        public ActionResult GetProducts(int page = 1) 
        {
            List<ProductViewModel> products = productManager.GetProducts(page, PRODUCTS_PER_PAGE);
            int productsCount = productManager.Count();
            int numberOfPages = (productsCount + PRODUCTS_PER_PAGE - 1) / PRODUCTS_PER_PAGE;

            PaginationInfo paginationInfo = new PaginationInfo
            {
                CurrentPage = page,
                PagesCount = numberOfPages,
                ProductsCount = productsCount
            };

            ProductsListViewModel productsListViewModel = new ProductsListViewModel
            {
                Products = products,
                PaginationInfo = paginationInfo
            };

            return PartialView("ProductsList", productsListViewModel);
        }
    }
}