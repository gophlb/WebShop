using System;
using DAL;

namespace DAL
{
    public class Product
    {
        public int Id { get; set; }

        public string Reference { get; set; }

        public string Name { get; set; }

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

        public Category Category { get; set; }

        public string PhotoUrl { get; set; }
    }
}