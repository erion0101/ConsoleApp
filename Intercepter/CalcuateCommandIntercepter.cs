using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class CalcuateCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "calculate";

        public void Execute(Command command)
        {
            var products = StorMenager.GetProducts();

            if(products.Count > 0)
            {
                double finalprice = 0;

                foreach (var product in products)
                {
                    finalprice += product.Amount * product.Price;
                }
                var print = new Printer();
                print.PrintToConsole(products);
                Console.WriteLine($"The total price to be paid is {finalprice:C}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("calculate: -use to print and calculate the total price");
        }
    }
}
