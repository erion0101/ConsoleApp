using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class aBuyCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "buy";
        public void Execute(Command command)
        {
            var products = StorMenager.GetProducts();
            if(products.Count > 0 )
            {
                 var location = FolderBrowserMenager.SelectFolderLocation();
                 var printer = new Printer();
                 printer.PrintToTextFile(location, products);
                 StorMenager.ClearProduct();
                 printer.PrintToJsonFile(new List<Product>());
                 Console.WriteLine("The payment has been made successfully");
            }
            else
            {
                 Console.WriteLine("There are no products in the basket");
            }
        }
        public void ShowDoc()
        {
            Console.WriteLine("buy: used to buy products in the basket");
        }
    }
}
