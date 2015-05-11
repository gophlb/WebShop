using System;

namespace Core
{
    public class ProductViewModel
    {
        public string Reference { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public decimal VAT { get; set; }

        public decimal PriceExcVAT { get; set; }

        public decimal PriceIncVAT 
        {
            get { return PriceExcVAT + AmountVAT; }
        }

        public decimal AmountVAT
        {
            get { return PriceExcVAT * (VAT / 100); }
        }

        public string PhotoUrl { get; set; }
    }
}