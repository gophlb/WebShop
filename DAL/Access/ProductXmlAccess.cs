using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;

namespace DAL
{
    public class ProductXmlAccess : IProductAccess
    {
        private readonly string xmlPath;

        public ProductXmlAccess(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }

        public List<Product> GetAllProducts()
        {
            XElement root = XElement.Load(xmlPath);

            List<Product> products = (
                from c in root.Element("categories").Elements("category")
                join p in root.Element("products").Elements("product")
                on (string)c.Attribute("id") equals (string)p.Attribute("categoryId")                
                select new Product
                {
                    Id = (int)p.Attribute("id"),
                    Name = (string)p.Attribute("name"),
                    Reference = (string)p.Attribute("reference"),
                    Description = (string)p.Element("description"),
                    PriceExcVAT = (decimal)p.Attribute("priceExcVAT"),
                    VAT = (decimal)p.Attribute("vat"),
                    Category = new Category
                    {
                        Id = (int)c.Attribute("id"),
                        Name = (string)c.Attribute("name")
                    }
                }).OrderBy(p => p.Id).ToList();

            return products;
        }

        public List<Product> GetProducts(int page, int productsPerPage)
        {
            List<Product> products = GetAllProducts().Skip((page - 1) * productsPerPage).Take(productsPerPage).ToList();
            return products;
        }

        public Product GetProductByReference(string reference)
        {
            Product product = GetAllProducts().Where(e => e.Reference == reference).FirstOrDefault();

            return product;
        }





        public int Count()
        {
            XElement root = XElement.Load(xmlPath);
            return root.Element("products").Elements("product").Count();
        }
    }
}
