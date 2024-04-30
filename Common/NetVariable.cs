using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class NetVariable : ICloneable
    {
        public int FormId { get; set; }
        public bool ReadOnly { get; set; }
        public bool IsReadOnly { get; set; }
        public VariableStatus Status { get; set; }
        public string Label { get; set; }
        public string Unit { get; set; }
        public bool CanChangeInRunMode { get; set; }
        public int MainIndex { get; set; }
        public bool IsValid { get; set; } = true;
        public bool HasError => !IsValid;
        public int PacketNumber { get; set; }
        public int PacketIndex { get; set; }

        public virtual object Clone()
        {
            var Net = new NetVariable
            {
                Label = Label,
                MainIndex = MainIndex,
                IsReadOnly = IsReadOnly,
                PacketIndex = PacketIndex,
                Status = Status,
                FormId = FormId,
                IsValid = IsValid,
                CanChangeInRunMode = CanChangeInRunMode,
                PacketNumber = PacketNumber,
                ReadOnly = ReadOnly,
                Unit = Unit
            };
            return Net;
        }
    }
}
