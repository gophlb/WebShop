using Core;
using System;
using DAL;
using AutoMapper;

namespace BLL
{
    public class ClientManager : IClientManager
    {
        IClientAccess clientAccess;


        static ClientManager()
        {
            Mapper.CreateMap<ClientViewModel, Client>().ReverseMap();
        }


        public ClientManager(IClientAccess clientAccess)
        {
            this.clientAccess = clientAccess;
        }

        public void AddClient(ClientViewModel clientVM)
        {
            Client client = Mapper.Map<Client>(clientVM);
            clientAccess.AddClient(client);
        }
    }
}
