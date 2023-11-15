using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class ProductMetadata : IEquatable<ProductMetadata>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsCountable { get; set; }

        public bool Equals(ProductMetadata other)
        {
            if(other == null) return false;
            if(ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }
    }
}
