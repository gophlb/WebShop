using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Cart
    {
        private List<CartEntry> _entries;

        public List<CartEntry> Entries
        {
            get
            {
                if (_entries == null) { _entries = new List<CartEntry>(); }
                return _entries;
            }
        }

        public int Count() { return Entries.Sum(e => e.Quantity); }

        public void Add(Product product, int quantity = 1)
        {
            CartEntry cartEntry = Entries.Where(ce => ce.Reference == product.Reference).FirstOrDefault();

            if (cartEntry == null) { Entries.Add(new CartEntry { Product = product, Quantity = quantity, Reference = product.Reference }); }
            else { cartEntry.Quantity += quantity; }
        }

        public void Remove(string reference, int quantity = 1)
        {
            CartEntry cartEntry = Entries.Where(ce => ce.Reference == reference).FirstOrDefault();
            if (cartEntry != null)
            {
                if (quantity >= cartEntry.Quantity) { Entries.Remove(cartEntry); }
                else { cartEntry.Quantity -= quantity; }
            }
        }


        public List<CartEntry> Get() { return Entries; }


        public void Clear() { Entries.Clear(); }
    }
}