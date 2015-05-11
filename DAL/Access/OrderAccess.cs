using System;

namespace DAL
{
    public class OrderAccess : IOrderAccess
    {
        public void Add(Order order)
        {
            using (webShopModelContainer db = new webShopModelContainer())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
