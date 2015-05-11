using AutoMapper;
using Core;
using DAL;

namespace BLL
{
    public class ShopCartManager : IShopCartManager
    {
        private ICartAccess cartAccess;
        private IProductAccess productAccess;


        static ShopCartManager()
        {
            Mapper.CreateMap<Product, ProductViewModel>().ForMember(pvm => pvm.CategoryName, p => p.MapFrom(pp => pp.Category.Name));
            Mapper.CreateMap<CartEntry, ShopCartEntry>();
            Mapper.CreateMap<Cart, ShopCart>();
        }




        public ShopCartManager(ICartAccess cartAccess, IProductAccess productAccess)
        {
            this.cartAccess = cartAccess;
            this.productAccess = productAccess;
        }


        public ShopCart Get()
        {
            Cart cart = cartAccess.Get();

            ShopCart shopCart = Mapper.Map<ShopCart>(cart);

            return shopCart;
        }

        public void Add(string reference, int quantity = 1)
        {
            Product product = productAccess.GetProductByReference(reference);
            cartAccess.Add(product, quantity);
        }

        public void Remove(string reference, int quantity = 1)
        {
            cartAccess.Remove(reference, quantity);
        }

        public void Clear()
        {
            cartAccess.Clear();
        }

        public int Count()
        {
            return cartAccess.Count();
        }

        public void Save()
        {
            cartAccess.Save();
        }
    }
}
