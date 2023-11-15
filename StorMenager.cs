using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 //Kemi krijuar disa metoda qe na nevoiten gjithashtu edhe 2 lista nje per product qe ndodhen ne 
//Shport(ListOfProducts) dhe nje ushqimet qe ndodhen ne shitore(ListOfAvaliableProducts)
namespace ConsoleApp13
{
    public static class StorMenager
    {
        static StorMenager()
        {
            var printer = new Printer();
            var products = printer.ReadJsonFromFile();
            ListOfProducts = products;
        }
        public static bool TryGetProductMetadata(string name, out ProductMetadata value)
        {
            var index = ListOfAvalableProducts.IndexOf(new ProductMetadata
            {
                Name = name,
            });
            if(index != -1)
            {
                value = ListOfAvalableProducts[index];
                return true;
            }
            value = null;
            return false;
        }
        public static bool TryGetProduct(string name,out Product product)
        {
            var index = ListOfProducts.IndexOf(new Product
            {
                Name = name,
            });
            if(index != -1)
            {
                product = ListOfProducts[index];
                return true;
            }
            product = null;
            return false;
        }
        public static void AddProduct(Product product)
        {   
            if (ListOfProducts.Contains(new Product
            {
                Name = product.Name,
            }))
            {
                throw new Exception($"Product named: {product.Name} is in the list");
            }
            else
            {
                ListOfProducts.Add(product);
            }
        }
        public static void RemoveProduct(string name)
        {
            if (TryGetProduct(name, out Product product))
            {
                ListOfProducts.Remove(product);
            }
            else
            {
                throw new Exception("The product you want to delete is not in the list");
            }
        }
        public static void UpdateProduct(string name ,double amount)
        {
            if(TryGetProduct(name, out var product))
            {
                product.Amount = amount;
            }
            else
            {
                throw new Exception($"Product with the name: {product.Name} is not in the list");
            }
        }
        public static void ClearProduct()
        {
            ListOfProducts.Clear();
        }
        public static List<Product> GetProducts()
        {
            return ListOfProducts;
        }
        public static List<ProductMetadata> GetAvaliableProduct()
        {
            return ListOfAvalableProducts;
        }
        public static readonly List<Product> ListOfProducts = new List<Product>();
        public static readonly List<ProductMetadata> ListOfAvalableProducts = new List<ProductMetadata>
        { 
            new ProductMetadata()
            {
                Name = "Mish",
                IsCountable = false,
                Price = 7,
            },
            new ProductMetadata()
            {
                Name = "Mill",
                IsCountable = false,
                Price = 10,
            },
            new ProductMetadata()
            {
                Name = "Veze",
                IsCountable = true,
                Price = 0.40,
            },
            new ProductMetadata()
            {
                Name = "Djathi",
                IsCountable = false,
                Price = 2.50,
            },
            new ProductMetadata()
            {
                Name = "Qumsht",
                IsCountable = false,
                Price = 1.20,
            },new ProductMetadata()
            {
                Name = "Patate",
                IsCountable = false,
                Price = 3.20,
            },
        };

    }
}
