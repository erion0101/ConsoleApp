using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class ListCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "list";

        public void Execute(Command command)
        {

            var products = StorMenager.GetProducts();
            if (products.Count > 0)
            {
                var printer = new Printer();
                printer.PrintToConsole(products);
            }
            else
            {
                Console.WriteLine("There is no product in the basket.");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("list: -used to see all products in the basket");
        }
    }
}
