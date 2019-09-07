using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odata.portal.Models
{
    public class Product
    {
        public string Name { get; set; }
        //public string ProductGroup { get; set; }
        public string ProductId { get; set; }

        public int Amount { get; set; }
        public int TaxRate { get; set; }
        public int NumberOfProducts { get; set; }
        public Category Category { get; set; }

    }
    public class Category
    {
        public string CategoryName { get; set; }
        public string Country { get; set; }
    }
}