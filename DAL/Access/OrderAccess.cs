using System;
using Utils.Extensions;

namespace DAL
{
    public class OrderAccess : IOrderAccess
    {
        public void Checkout(Order order, Client client)
        {
            try
            {
                using (webShopModelContainer db = new webShopModelContainer())
                {
                    db.Clients.Add(client);
                    db.SaveChanges();

                    order.Client = client;
                    order.ClientId = client.Id;

                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                e.Log("");
                throw e;
            }
        }
    }
}
