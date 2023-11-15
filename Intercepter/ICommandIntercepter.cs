using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public interface ICommandIntercepter
    {
        string Operation { get; }
        void Execute(Command command);
        void ShowDoc();
    }
}
