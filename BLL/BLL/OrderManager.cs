using AutoMapper;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        IOrderAccess orderAccess;
        ICartAccess cartAccess;

        static OrderManager()
        {
            Mapper.CreateMap<ShippingDetails, City>().ForMember(c => c.Id, sd => sd.MapFrom(sde => sde.CityId));
            Mapper.CreateMap<ShippingDetails, Client>();
            Mapper.CreateMap<ShippingDetails, Address>();
            Mapper.CreateMap<CartEntry, OrderLine>();
            Mapper.CreateMap<Cart, Order>();
        }


        public OrderManager(IOrderAccess orderAccess, ICartAccess cartAccess)
        {
            this.orderAccess = orderAccess;
            this.cartAccess = cartAccess;
        }


        public void Checkout(ShippingDetails shippingDetails)
        {
            Cart cart = cartAccess.Get();
            Order order = Mapper.Map<Order>(cart);
            order.OrderLines = Mapper.Map<List<OrderLine>>(cart.Entries);
            
            Client client = Mapper.Map<Client>(shippingDetails);
            //City city = Mapper.Map<City>(shippingDetails);
            Address address = Mapper.Map<Address>(shippingDetails);

            //address.City = city;
            client.Address.Add(address);
            orderAccess.Checkout(order, client);
        }
    }
}