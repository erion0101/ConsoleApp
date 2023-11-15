using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class RemoveCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "remove";

        public void Execute(Command command)
        {
            if(command.Parameters.TryGetValue("product",out var product))
            {
                StorMenager.RemoveProduct(product);
                
                Console.WriteLine($"The product named {product} has been removed from the cart");
            }
            else
            {
                throw new Exception("Parameter product missing");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("remove: -used to remove a specific product");
            Console.WriteLine("product: -used to identify the product to remove from basket");
        }
    }
}
