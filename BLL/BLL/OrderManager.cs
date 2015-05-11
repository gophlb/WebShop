using Core;
using System;
using DAL;
using AutoMapper;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        IOrderAccess orderAccess;


        static OrderManager()
        {
            Mapper.CreateMap<ClientViewModel, Client>().ReverseMap();
        }


        public OrderManager(IOrderAccess orderAccess)
        {
            this.orderAccess = orderAccess;
        }

        public void Add(ShopCart cart, ClientViewModel client)
        {
            
        }
    }
}
