using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceNotifier
{
    public class Product
    {
        public string Upc { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }

    public class VendorOffer
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
