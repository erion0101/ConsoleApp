using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class SaveCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "save";

        public void Execute(Command command)
        {
            var products = StorMenager.GetProducts();
            var printer = new Printer();
            printer.PrintToJsonFile(products);
            Console.WriteLine("Product has been saved successfully");
            
        }

        public void ShowDoc()
        {
            Console.WriteLine("save: -use to save all changes to a file");
        }
    }
}
