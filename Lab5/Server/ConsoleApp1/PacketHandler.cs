using ConsoleApp1.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            ushort packetLength = BitConverter.ToUInt16(packet, 0);
            byte[] data = new byte[packetLength];
            Array.Copy(packet,2, data, 0, packetLength);
            string commandName = Encoding.Default.GetString(data);
            var command = CommandList.GetCommand(commandName);

            if (command != null)
            {
                byte[] res = command.Execute();
                clientSocket.Send(res);
            }
            Console.WriteLine($"Packet received: Length: {packetLength} ");
        }
    }
}
