using System.Collections.Generic;

namespace DAL
{
    public interface IProductAccess
    {
        List<Product> GetAllProducts();

        List<Product> GetProducts(int page, int productsPerPage);

        Product GetProductByReference(string reference);

        int Count();
    }
}
