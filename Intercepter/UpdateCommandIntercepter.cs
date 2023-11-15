using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class UpdateCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "update";

        public void Execute(Command command)
        {
            if(command.Parameters.TryGetValue("product", out var product))
            {
                double amount;
                if(command.Parameters.TryGetValue("amount",out var amountText))
                {
                    if(StorMenager.TryGetProductMetadata(product,out var productMetadata))
                    {
                        if (productMetadata.IsCountable)
                        {
                            if(int.TryParse(amountText,out var amountTemp))
                            {
                                amount = amountTemp;
                            }
                            else
                            {
                                throw new Exception("Please enter a integer value in the amount parameter");
                            }
                        }
                        else
                        {
                            if (!double.TryParse(amountText, out amount))
                            {
                                throw new Exception("Please enter a double value in the amount parameter");
                            }
                        }
                        StorMenager.UpdateProduct(product,amount);
                        Console.WriteLine("You have changed the product amount {0}", product);
                    }
                    else
                    {
                        throw new Exception($"Product whith name {product} dose not exist in Market");
                    }
                }
                else
                {
                    throw new Exception("Parameter amount is missing");
                }
            }
            else
            {
                throw new Exception("Parameter product is missing");
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("update: -used to update a product");
            Console.WriteLine("--product: -used to identify the product");
            Console.WriteLine("--amount: -used for the new quantity of the product");
        }
    }
}
