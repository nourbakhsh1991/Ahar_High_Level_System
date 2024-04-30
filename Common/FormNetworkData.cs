using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class FormNetworkData
    {
        public PacketTypes PacketType { get; set; }
        public int FormId { get; set; }
        public byte[] Data { get; set; }
    }
}
