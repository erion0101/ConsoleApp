using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public class ClearCmdCommandIntercepter : ICommandIntercepter
    {
        public string Operation => "clear";

        public void Execute(Command command)
        {
            Console.Clear();
        }

        public void ShowDoc()
        {
            Console.WriteLine("clear: -use to clear text in Console");
        }
    }
}
