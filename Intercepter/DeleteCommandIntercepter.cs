using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class DeleteCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "delete";

        public void Execute(Command command)
        {
            StorMenager.ClearProduct();
            var productToJson = new Printer();
            productToJson.PrintToJsonFile(new List<Product>());
            Console.WriteLine("All products were deleted from the basket");
        }

        public void ShowDoc()
        {
            Console.WriteLine("delete: -use to delete all products in the basket");
        }
    }
}
