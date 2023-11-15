using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp13.Intercepter
{
    public class AddCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "add";

        public void Execute(Command command)
        {
            if(command.Parameters.TryGetValue("product",out var product))
            {
                
                if (command.Parameters.TryGetValue("amount", out var amountText))
                {
                    if(StorMenager.TryGetProductMetadata(product,out var productMetadata))
                    {
                        double amount;
                        if (productMetadata.IsCountable)
                        {
                            if (int.TryParse(amountText, out var amountTemp))
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
                        if(amount < 1)
                        {
                            throw new Exception("Amount cannot be in the value 1");
                        }
                        StorMenager.AddProduct(new Product
                        {
                            Amount = amount,
                            IsCountable= productMetadata.IsCountable,
                            Name = product,
                            Price = productMetadata.Price,
                        });
                        Console.WriteLine("The product is successfully added to the basket");

                    }
                    else
                    {
                        throw new Exception($"The product whith name {product} is not found in the Market");
                    }
                }
                else
                {
                    throw new Exception("Parameter amount is missing ");
                }
            }
            else
            {
                throw new Exception("Parameter product is missing");
            }
            
        }

        public void ShowDoc()
        {
            Console.WriteLine("add: -use add to add a product");
            Console.WriteLine("--product: -Enter the name of the product");
            Console.WriteLine("--amount: -Specify the product amount");
        }
    }
}
