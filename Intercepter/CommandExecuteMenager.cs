using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Intercepter
{
    public static class CommandExecuteMenager
    {
        public static readonly Dictionary<string,ICommandIntercepter> Intercepter 
        = new Dictionary<string,ICommandIntercepter>();
        static CommandExecuteMenager()
        {
            var  helperIntercepter = new HelpCommandIntercepter();
            Intercepter.Add(helperIntercepter.Operation, helperIntercepter);

            foreach (var intercepter in IntercepterStor.Intercepters)
            {
                Intercepter.Add(intercepter.Operation, intercepter);
            }
        }
        //Kjo metod thot mundohu ta marresh interecepter ne bazz te commandes qe na vjen prej pordorusit

        public static void Execute(Command command)
        {
            if(Intercepter.TryGetValue(command.Name,out var intercepter))
            {
                intercepter.Execute(command);
            }
            else
            {
                throw new Exception($"The interceptor for this command: {command.Name} could not be found");
            }
        }
       
    }
}
