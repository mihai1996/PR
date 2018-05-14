using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    class Time:ICommand
    {
        public String Name { get; set; }

        public byte[] Execute()
        {
            string time = DateTime.UtcNow.ToString();
            byte[] data = new byte[time.Length];
            Array.Copy(Encoding.ASCII.GetBytes(time), data, time.Length);
            return data;
        }

        public Time()
        {
            Name = "/time";
        }

        public bool IsValid(string input)
        {
            string name = input.ToLower();

            return Name == name;
        }
    }
}
