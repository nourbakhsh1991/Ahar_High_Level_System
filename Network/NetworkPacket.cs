using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Common;

namespace AharHighLevel.Network
{
    public class NetworkPacket
    {
        public PacketTypes PacketType { get; set; }
        public short CSD { get; set; }
        public Devices Source { get; set; }
        public Devices Destination { get; set; }
        public byte DataNumber { get; set; }
        public List<byte> Data { get; set; }
    }
}
