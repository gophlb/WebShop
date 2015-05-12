
namespace DAL
{
    public class OrderAccess : IOrderAccess
    {
        public void Checkout(Order order, Client client)
        {
            using (webShopModelContainer db = new webShopModelContainer())
            {
                db.Clients.Add(client);
                db.SaveChanges();

                order.Client = client;
                order.ClientId = client.Id;

                db.OrderLines.AddRange(order.OrderLines);
                db.SaveChanges();

                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
