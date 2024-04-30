using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class AlarmEventVariable
    {
        public ushort Code { get; set; }
        public string Message { get; set; }
        public uint Time { get; set; }
        public int Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsInternal { get; set; }
        public string PrintMessage => ((Type == 1) ? "AlarmCode" : (Type == 2 ? "FaultCode" : "EventCode")) + Code + " > " + Message;
    }
}
