using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Commands
{
    class Help:ICommand
    {
        public String Name { get; set; }

        public byte[] Execute()
        {
            List<string> list = CommandList.GetAllCommands();
            string res = "\nCommand list: \n";

            foreach(var command in list)
            {
                res = res + command + "\n";
            }

            byte[] data = new byte[res.Length];
            Array.Copy(Encoding.ASCII.GetBytes(res), data, res.Length);
            return data;
        }

        public Help()
        {
            Name = CommandList.HELP_NAME;
        }

        public bool IsValid(string input)
        {
            string name = input.ToLower();

            return Name == name;
        }
    }
}
