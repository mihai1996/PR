using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Message
    {
        public static byte[] CreateMessage(string command)
        {
            byte[] packet = new byte[command.Length + 3];
            byte[] packetLength = BitConverter.GetBytes((ushort)command.Length);
            Array.Copy(packetLength, packet, 2);
            Array.Copy(Encoding.ASCII.GetBytes(command), 0, packet, 2, command.Length);

            return packet;
        }
    }
}
