using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class BoolVariable : NetVariable
    {
        public Action<object> ValueChanged { get; set; }
        private bool _value;
        public bool Value
        {
            get
            {
                return _value;

            }
            set
            {
                _value = value;
                Status = VariableStatus.Changed;
                ValueChanged?.Invoke(this);
            }
        }

        private bool _netValue;
        public bool NetValue
        {
            get => _netValue;
            set
            {
                bool changed = _value != _netValue;
                _netValue = value;
                if (!changed && Status != VariableStatus.Changed)
                {
                    _value = _netValue;
                    Status = IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Loaded;
                    ValueChanged?.Invoke(this);
                }
            }
        }

        public int PacketSubIndex { get; set; }
        public BoolVariable()
        {
        }
        public BoolVariable(bool value)
        {
            this.Value = value;
        }

        public override object Clone()
        {
            var Net = (NetVariable)base.Clone();
            var Bool = new BoolVariable
            {
                MainIndex = Net.MainIndex,
                Status = Net.Status,
                PacketIndex = Net.PacketIndex,
                PacketNumber = Net.PacketNumber,
                Unit = Net.Unit,
                FormId = Net.FormId,
                IsValid = Net.IsValid,
                Label = Net.Label,
                IsReadOnly = Net.IsReadOnly,
                CanChangeInRunMode = Net.CanChangeInRunMode,
                _value = _value,
                _netValue = _netValue,
                PacketSubIndex = PacketSubIndex
            };
            return Bool;
        }
    }
}
