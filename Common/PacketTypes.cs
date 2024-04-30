using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public enum PacketTypes
    {
        Data = 0,
        Command = 64,
        Status = 192,
        Calibration = 128,
        None = 255
    }
}
