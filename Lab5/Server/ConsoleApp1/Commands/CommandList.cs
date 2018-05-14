using System.Collections.Generic;

namespace ConsoleApp1.Commands
{
    class CommandList
    {
        public static List<ICommand> Commands = new List<ICommand>();
        public static readonly string HELP_NAME = @"/help";

        static CommandList()
        {
            Commands.Add(new Time());
            Commands.Add(new FlipCoin());
            Commands.Add(new NumberGenerator());
            Commands.Add(new Hello());

            Commands.Add(new Help());
        }

        public static ICommand GetCommand(string name)
        {
            foreach(var command in Commands)
            {
                if (command.IsValid(name))
                {
                    return command;
                }
            }

            return GetCommand(HELP_NAME);
        }

        public static List<string> GetAllCommands()
        {
            List<string> list = new List<string>();

            foreach (var command in Commands)
            {
                list.Add(command.Name);
            }

            return list;
        }
    }
}
