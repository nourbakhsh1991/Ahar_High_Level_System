using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class EnumVariable : NetVariable
    {
        public Action<object> ValueChanged { get; set; }
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                Status = IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Changed;
                ValueChanged?.Invoke(this);
            }
        }

        public EnumVariable()
        {
            Items = new List<string>();
        }
        public EnumVariable(int value)
        {
            this.Value = value;
            Items = new List<string>();
        }

        private int _netValue;
        public int PacketSubIndex { get; set; }
        public int SubIndexLength { get; set; }

        public List<string> Items { get; set; }
        public int NetValue
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

        public override object Clone()
        {
            var Net = (NetVariable)base.Clone();
            var Enum = new EnumVariable
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
                PacketSubIndex = PacketSubIndex,
                Items = new List<string>()
            };
            Enum.Items.AddRange(Items.Select(a => a));
            Enum.SubIndexLength = SubIndexLength;
            return Enum;
        }
    }
}
