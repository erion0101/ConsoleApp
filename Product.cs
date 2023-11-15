using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public bool IsCountable { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public bool Equals(Product product)
        {
            if(product == null) return false;
            if(ReferenceEquals(this, product)) return true;
            return Name == product.Name;
        }
    }
}
