using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    interface ICommand
    {
        string Name { get; set; }
        byte[] Execute();

        bool IsValid(string input);
    }
}
