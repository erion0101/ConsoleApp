using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class PrintCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "print";

        public void Execute(Command command)
        {
            var products = StorMenager.GetProducts();
            if(products.Count > 0)
            {
                var print = new Printer();
                var location = FolderBrowserMenager.SelectFolderLocation();
                print.PrintToTextFile(location, products);
            }
            else
            {
                throw new Exception("There is no product in the basket");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("print: -use to print the summary to a text file");
        }
    }
}
