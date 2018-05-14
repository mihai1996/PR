using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    class Hello:ICommand    
    {
        public String Name { get; set; }
        private string args;

        public byte[] Execute()
        {
            string response = args;
            byte[] data = new byte[args.Length];
            Array.Copy(Encoding.ASCII.GetBytes(args), data, args.Length);
            return data;
        }

        public Hello()
        {
            Name = "/hello";
        }

        public bool IsValid(string input)
        {
            string name = input.ToLower();
            string commandName = name.Split(' ').First();

            if (!String.IsNullOrWhiteSpace(commandName))
            {
                AddArguments(name);
                return commandName == Name;
            }

            return false;
        }

        private void AddArguments(string command)
        {
            int startIndex = command.IndexOf(' ') + 1;
            if (startIndex == 0)
                args = "";
            else
                args = command.Substring(startIndex);
        }
    }
}
