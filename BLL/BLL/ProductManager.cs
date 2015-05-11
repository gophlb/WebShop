using AutoMapper;
using Core;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ProductManager : IProductManager
    {
        private IProductAccess productAccess;



        static ProductManager()
        {
            Mapper.CreateMap<Product, ProductViewModel>().ForMember(pvm => pvm.CategoryName, p => p.MapFrom(pp => pp.Category.Name));
        }
        

        public ProductManager(IProductAccess productAccess)
        {
            this.productAccess = productAccess;
        }


        public List<ProductViewModel> GetAllProducts()
        {
            List<Product> products = productAccess.GetAllProducts();
            List<ProductViewModel> productsVM = Mapper.Map<List<ProductViewModel>>(products);

            return productsVM;
        }


        public List<ProductViewModel> GetProducts(int page, int productsPerPage)
        {
            List<Product> products = productAccess.GetProducts(page, productsPerPage);
            List<ProductViewModel> productsVM = Mapper.Map<List<ProductViewModel>>(products);

            return productsVM;
        }


        public ProductViewModel GetProductByReference(string reference)
        {
            Product product = productAccess.GetProductByReference(reference);
            ProductViewModel productVM = Mapper.Map<ProductViewModel>(product);

            return productVM;
        }


        public int Count()
        {
            return productAccess.Count();
        }
    }
}
