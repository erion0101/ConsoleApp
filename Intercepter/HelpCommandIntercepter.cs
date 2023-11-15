using ConsoleApp13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class HelpCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "help";

        public void Execute(Command command)
        {
           if(command.Parameters.TryGetValue("command",out var cmd))
            {
                ShowDoc(cmd);
            }
            else
            {
                ShowDoc();
            }
        }

        public void ShowDoc()
        {
            Console.WriteLine("Dokumentacioni");
            foreach (var intercepter in IntercepterStor.Intercepters)
            {
                intercepter.ShowDoc();
                Console.WriteLine("--------------------------------------------------");
            }
        }
        public void ShowDoc(string cmd)
        {
            Console.WriteLine("Dokumentacioni");
            foreach (var intercepter in IntercepterStor.Intercepters)
            {
                if(intercepter.Operation == cmd)
                {
                    intercepter.ShowDoc();
                    Console.WriteLine("--------------------------------------------------");
                    return;
                }
            }
            throw new Exception($"Command {cmd} does not exist");

        }
    }
}
