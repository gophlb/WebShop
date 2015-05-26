using System;
using System.Web;
using Utils.Extensions;

namespace DAL
{
    public class CartAccess : ICartAccess
    {
        private const string SESSION_ID = "#740dbefd#";


        public Cart Get()
        {
            Cart cart;
            try
            {
                if (HttpContext.Current.Session[SESSION_ID] != null)
                {
                    cart = (Cart)HttpContext.Current.Session[SESSION_ID];
                }
                else
                {
                    cart = new Cart();
                    HttpContext.Current.Session[SESSION_ID] = cart;
                }
            }
            catch (Exception e)
            {
                e.Log("");
                throw;
            }

            return cart;
        }


        public void Add(Product product, int quantity = 1)
        {
            Cart cart = Get();
            cart.Add(product, quantity);
        }

        public void Remove(string reference, int quantity = 1)
        {
            Cart cart = Get();
            cart.Remove(reference, quantity);
        }

        public void Clear()
        {
            Cart cart = Get();
            cart.Clear();
        }

        public int Count()
        {
            Cart cart = Get();
            return cart.Count();
        }
    }
}
