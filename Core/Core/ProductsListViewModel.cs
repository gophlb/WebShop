using System.Collections.Generic;

namespace Core
{
    public class ProductsListViewModel
    {
        public List<ProductViewModel> Products { get; set; }

        public PaginationInfo PaginationInfo { get; set; }
    }
}
