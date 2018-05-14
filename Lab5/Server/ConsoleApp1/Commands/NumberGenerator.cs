using System;
using System.Text;

namespace ConsoleApp1.Commands
{
    class NumberGenerator:ICommand
    {
        public String Name { get; set; }

        public byte[] Execute()
        {
            Random rnd = new Random();
            int number = rnd.Next(Int32.MinValue, Int32.MaxValue);
            string result = number.ToString();
            byte[] data = new byte[result.Length];
            Array.Copy(Encoding.ASCII.GetBytes(result), data, result.Length);

            return data;
        }

        public NumberGenerator()
        {
            Name = "/random";
        }

        public bool IsValid(string input)
        {
            string name = input.ToLower();

            return Name == name;
        }
    }
}
