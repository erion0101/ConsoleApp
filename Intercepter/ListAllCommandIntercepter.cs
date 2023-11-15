using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class ListAllCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "list-all";

        public void Execute(Command command)
        {
            var productMetadata = StorMenager.GetAvaliableProduct();
            if(productMetadata.Count > 0)
            {
                var printer = new Printer();
                printer.PrintToConsole(productMetadata);
            }
            else
            {
                Console.WriteLine("No product is in the store");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("list-all: - used to see all products in the Market");
        }
    }
}
