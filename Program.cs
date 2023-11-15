using ConsoleApp13.Intercepter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp13
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            string command = string.Empty;
            Console.WriteLine("Type: 'help' to see all the commands");
            Console.WriteLine("Type 'help --command x' where x is a command name, and viewing the documentation of command x");
            while (string.Compare(command,"exit",StringComparison.OrdinalIgnoreCase)!= 0)
            {
                Console.Write("-> ");
                command = Console.ReadLine();

                try
                {
                    var commands = CommandInterpreter.InterpreterCommandText(command);
                    foreach (var commandObject in commands)
                    {
                        CommandExecuteMenager.Execute(commandObject);
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor= ConsoleColor.White;
                }
            }

        }
    }

}
