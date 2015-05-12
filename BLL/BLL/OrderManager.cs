using AutoMapper;
using DAL;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        IOrderAccess orderAccess;
        ICartAccess cartAccess;

        static OrderManager()
        {
            Mapper.CreateMap<ShippingDetails, Client>();
            Mapper.CreateMap<ShippingDetails, Address>();
            Mapper.CreateMap<CartEntry, OrderLine>().ForMember(o => o.ProductReference, ce => ce.MapFrom(cep => cep.Product.Reference));
            Mapper.CreateMap<Cart, Order>();
        }


        public OrderManager(IOrderAccess orderAccess, ICartAccess cartAccess)
        {
            this.orderAccess = orderAccess;
            this.cartAccess = cartAccess;
        }


        public void Ckeckout(ShippingDetails shippingDetails)
        {
            Cart cart = cartAccess.Get();
            Order order = Mapper.Map<Order>(cart);
            Client client = Mapper.Map<Client>(shippingDetails);
            Address address = Mapper.Map<Address>(shippingDetails);

            client.Address.Add(address);
            orderAccess.Checkout(order, client);
        }
    }
}
