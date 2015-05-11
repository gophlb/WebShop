using System.Collections.Generic;
using Core;

namespace BLL
{
    public interface IProductManager
    {
        List<ProductViewModel> GetAllProducts();

        List<ProductViewModel> GetProducts(int page, int productsPerPage);

        ProductViewModel GetProductByReference(string reference);

        int Count();
    }
}
