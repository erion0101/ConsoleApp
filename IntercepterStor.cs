using ConsoleApp13.Intercepter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public static class IntercepterStor
    {
        public static List<ICommandIntercepter> Intercepters = new List<ICommandIntercepter>()
        {
            new AddCommandIntercepter(),
            new ListCommandIntercepter(),
            new ListAllCommandIntercepter(),
            new ClearCmdCommandIntercepter(),
            new DeleteCommandIntercepter(),
            new UpdateCommandIntercepter(),
            new CheckCommandIntercepter(),
            new CalcuateCommandIntercepter(),
            new RemoveCommandIntercepter(),
            new PrintCommandIntercepter(),
            new SaveCommandIntercepter(),
            new BuyCommandIntercepter(),
        };
    }
}
