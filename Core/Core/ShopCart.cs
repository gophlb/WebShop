using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class ShopCart
    {
        private List<ShopCartEntry> _entries;

        public List<ShopCartEntry> Entries
        {
            get
            {
                if (_entries == null) { _entries = new List<ShopCartEntry>(); }
                return _entries;
            }
        }

        public int Count() 
        {
            return Entries.Sum(e => e.Quantity);
        }

        public void Add(ProductViewModel product, int quantity = 1)
        {
            ShopCartEntry shopCartEntry = Entries.Where(ce => ce.Reference == product.Reference).FirstOrDefault();

            if (shopCartEntry == null) { Entries.Add(new ShopCartEntry { Product = product, Quantity = quantity }); }
            else { shopCartEntry.Quantity += quantity; }
        }
        
        public void Remove(string reference, int quantity = 1)
        {
            ShopCartEntry shopCartEntry = Entries.Where(ce => ce.Reference == reference).FirstOrDefault();
            if (shopCartEntry != null) 
            {
                if (quantity >= shopCartEntry.Quantity) { Entries.Remove(shopCartEntry); }
                else { shopCartEntry.Quantity -= quantity; }
            }            
        }


        public List<ShopCartEntry> Get() { return Entries; }


        public void Clear() { Entries.Clear(); }
    }
}