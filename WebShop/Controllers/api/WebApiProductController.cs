using BLL;
using Core;
using System.Collections.Generic;
using System.Web.Http;


namespace WebShop.WebApiControllers
{
    public class WebApiProductController : ApiController
    {
        private const int PRODUCTS_PER_PAGE = 10;
        private IProductManager productManager;

        public WebApiProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }


        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> products = productManager.GetAllProducts();
            
            return products;
        }


        public List<ProductViewModel> GetPagedProducts(int page)
        {
            List<ProductViewModel> products = productManager.GetProducts(page, PRODUCTS_PER_PAGE);

            return products;
        }


        public IHttpActionResult GetProduct(string reference)
        {
            ProductViewModel product = productManager.GetProductByReference(reference);
            
            if (product == null) { return NotFound(); }
            
            return Ok(product);
        }
    }
}