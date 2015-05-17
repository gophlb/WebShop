using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Utils.Extensions;

namespace DAL
{
    public class ProductAccess : IProductAccess
    {
        private readonly string xmlPath;

        public ProductAccess(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }


        public List<Product> GetAllProducts()
        {
            List<Product> products = null;

            if (File.Exists(xmlPath))
            {
                try
                {
                    XElement root = XElement.Load(xmlPath);

                    products = (
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
                            BackgroundColor = (string)p.Attribute("backgroundColor"),
                            Category = new Category
                            {
                                Id = (int)c.Attribute("id"),
                                Name = (string)c.Attribute("name")
                            }
                        }).OrderBy(p => p.Id).ToList();
                }
                catch (Exception e)
                {
                    e.Log("");
                    throw e;
                }
            }

            return products;
        }


        public List<Product> GetProducts(int page, int productsPerPage)
        {
            List<Product> products = GetAllProducts();

            if (products != null)
            {
                products = products.Skip((page - 1) * productsPerPage).Take(productsPerPage).ToList();
            }

            return products;
        }

        public Product GetProductByReference(string reference)
        {
            Product product = null;

            List<Product> products = GetAllProducts();

            if (products != null)
            {
                product = products.Where(e => e.Reference == reference).FirstOrDefault();
            }
            
            return product;
        }





        public int Count()
        {
            int count = 0;

            if (File.Exists(xmlPath))
            {
                try
                {
                    XElement root = XElement.Load(xmlPath);

                    if (root != null)
                    {
                        count = root.Element("products").Elements("product").Count();
                    }
                }
                catch (Exception e)
                {
                    e.Log("");
                    throw e;
                }
            }
            return count;
        }
    }
}
