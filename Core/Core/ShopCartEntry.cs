
namespace Core
{
    public class ShopCartEntry
    {
        public string Reference { get; set; }
        public ProductViewModel Product {get;set;}
        public int Quantity { get; set; }
    }
}