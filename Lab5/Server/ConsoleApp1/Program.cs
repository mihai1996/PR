using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static ServerSocket socket = new ServerSocket();
        static void Main(string[] args)
        {
            socket.Bind(9000);
            socket.Listen();
            socket.Accept();

            Console.ReadLine();
        }
    }
}
