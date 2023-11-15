using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class Printer
    {
        public void PrintToConsole(List<Product> products)
        {
            for (int index = 0; index < products.Count; index++)
            {
                var product = products[index];

                Console.WriteLine("Product number      {0}", index + 1);
                Console.WriteLine("Name:               {0}", product.Name);
                Console.WriteLine("Ordered:            {0:F}", product.OrderDate);
                Console.WriteLine("Amount:             {0}", product.Amount + (product.IsCountable ? "P" : "KG"));
                Console.WriteLine("Unit price:         {0:C}", product.Price);
                Console.WriteLine("Line Total:         {0:C}", product.Price * product.Amount);
                Console.WriteLine("-----------------------------------------------");

            }
        }
        public void PrintToConsole(List<ProductMetadata> productMetadata)
        {
            for (int index = 0; index < productMetadata.Count; index++)
            {
                var metadata = productMetadata[index];

                Console.WriteLine("Product number      {0}", index + 1);
                Console.WriteLine("Name:               {0}", metadata.Name);
                Console.WriteLine("Unit price:         {0:C}", metadata.Price);
                Console.WriteLine("Is Countable:       {0}",metadata.IsCountable ? "Po" : "Jo");
                Console.WriteLine("-----------------------------------------------");

            }
        }

        public void PrintToTextFile(string location, List<Product> products)
        {
            var stringBuilder = new StringBuilder();

            double finalPrice = 0;

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                finalPrice += product.Price * product.Amount;
                stringBuilder.Append($"Product number:      {i + 1}" + Environment.NewLine);
                stringBuilder.Append($"Name:                {product.Name}" + Environment.NewLine);
                stringBuilder.Append($"Ordered:             {product.OrderDate:F}" + Environment.NewLine);
                stringBuilder.Append($"AMount:              {product.Amount}"+(product.IsCountable ? "P" : "KG")
                    + Environment.NewLine);
                stringBuilder.Append($"Unit Price:          {product.Price:C}" + Environment.NewLine);
                stringBuilder.Append($"Line Total:          {(product.Price * product.Amount):F}"+Environment.NewLine);
                stringBuilder.Append("-----------------------------------------------------" + Environment.NewLine);
            }
            stringBuilder.Append($"Total price to pay:  {finalPrice:C}" + Environment.NewLine);
            
            stringBuilder.Append("-----------------------------------------------------" + Environment.NewLine);
            
            if (Directory.Exists(location))
            {
                var path = $"{location}\\Order-Summary.txt";
                File.WriteAllText(path, stringBuilder.ToString());

            } 
            else
            {
                throw new Exception($"Location {location} nuk egziston ne kte kompjuter");
            }
        }

        public void PrintToJsonFile(List<Product> products)
        {
            //listen me product e kemi convertuar nga obj ne nje string dhe e kemi copjuar
            //ne direktorin e programit
            var productToSting = JsonConvert.SerializeObject(products);
            File.WriteAllText("json",productToSting.ToString());
        }
        public List<Product> ReadJsonFromFile()
        {
            if (!File.Exists("json"))
            {
                return new List<Product>();
            }
            else
            {
                //lexon se qfare ka ne kte file dhe e converton kte txt qe ndodhet ne kte file ne nje list me product  
                var productToText = File.ReadAllText("json");
                var product = JsonConvert.DeserializeObject<List<Product>>(productToText);
                //lexon nje string kthen nje objekt  
                return product;
            }
        }
    }
}
