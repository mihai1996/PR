using System;
using System.Text;

namespace ConsoleApp1.Commands
{
    class FlipCoin:ICommand
    {
        public String Name { get; set; }

        public byte[] Execute()
        {
            Random rnd = new Random();
            byte face = (byte)rnd.Next(0, 2);
            string res = "";

            if (face == 0)
            {
                res = "head";
            }
            else
            {
                res = "tail";
            }

            byte[] data = new byte[res.Length];
            Array.Copy(Encoding.ASCII.GetBytes(res), data, res.Length);

            return data;
        }

        public FlipCoin()
        {
            Name = "/flip";
        }

        public bool IsValid(string input)
        {
            string name = input.ToLower();

            return Name == name;
        }
    }
}
