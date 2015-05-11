﻿
namespace DAL
{
    public class ClientAccess : IClientAccess
    {
        public void AddClient(Client client)
        {
            using (webShopModelContainer db = new webShopModelContainer())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }
    }
}
