using Core;
using System;
using DAL;
using AutoMapper;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        IOrderAccess orderAccess;
        ICartAccess cartAccess;

        static OrderManager()
        {
            Mapper.CreateMap<ClientViewModel, Client>();
            Mapper.CreateMap<CartEntry, OrderLine>().ForMember(o => o.ProductReference, ce => ce.MapFrom(cep => cep.Product.Reference));
            Mapper.CreateMap<Cart, Order>();
        }


        public OrderManager(IOrderAccess orderAccess, ICartAccess cartAccess)
        {
            this.orderAccess = orderAccess;
            this.cartAccess = cartAccess;
        }


        public void Ckeckout(ClientViewModel clientVM)
        {
            Cart cart = cartAccess.Get();
            Order order = Mapper.Map<Order>(cart);
            Client client = Mapper.Map<Client>(clientVM);

            orderAccess.Checkout(order, client);
        }
    }
}
