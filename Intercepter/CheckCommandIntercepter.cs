using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    internal class CheckCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "check";

        public void Execute(Command command)
        {
            if(command.Parameters.TryGetValue("product", out var productName))
            {
                if(StorMenager.TryGetProduct(productName, out var product))
                {
                    var printer = new Printer();
                    printer.PrintToConsole(new List<Product>
                    {
                        product
                    });
                }
                else
                {
                    throw new Exception($"Product with the name {productName} does not exist in the basket");
                }
            }
            else
            {
                throw new Exception("Parameter product is missing");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("check: -use it to see the product in the basket");
            Console.WriteLine("--product: -use to specify product");
        }
    }
}
