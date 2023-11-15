using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public static class CommandInterpreter
    {
        public static List<Command> InterpreterCommandText(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new Exception("Please enter a command for execution");

            var commandResult = new List<Command>();
            var allCommand = command.Split('&');

            foreach ( var commandWhithParameters in allCommand )
            {
                var parts = commandWhithParameters.Trim().Split(' ');

                if(parts.Length % 2 != 1)
                {
                    throw new Exception("Bad Command format");
                }
                var singelExecuteCommand = parts[0];
                var parameters = new Dictionary<string, string>();

                for (int i = 1; i < parts.Length; i+=2)
                {
                    if (parts[i].StartsWith("--"))
                    {
                        parameters.Add(parts[i].Substring(2), parts[i+1]);
                    }
                    else
                    {
                        throw new Exception("BeCareful! The parameter must start with two (--)");
                    }
                }
                commandResult.Add(new Command
                {
                    Name = singelExecuteCommand,
                    Parameters = parameters
                });
            }
            return commandResult;
        }
    }
}
