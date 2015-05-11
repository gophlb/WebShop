
namespace DAL
{
    public class CartEntry
    {
        public string Reference { get; set; }
        public Product Product {get;set;}
        public int Quantity { get; set; }
    }
}