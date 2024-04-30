using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    class Uint32Variable : NetVariable
    {
        public Action ValueChanged { get; set; }
        private UInt32 _value;
        public UInt32 Value
        {
            get
            {
                return _value;

            }
            set
            {
                _value = value;
                if (_value > Max && HasMinMax)
                    _value = Max;
                if (_value < Min && HasMinMax)
                    _value = Min;
                Status = VariableStatus.Changed;
                ValueChanged?.Invoke();
            }
        }
        public UInt32 Min { get; set; }
        public UInt32 Max { get; set; }
        public bool HasMinMax { get; set; }

        public Uint32Variable()
        {
            HasMinMax = false;
            Min = UInt32.MinValue;
            Max = UInt32.MaxValue;
        }
        public Uint32Variable(UInt32 value)
        {
            this.Value = value;
            HasMinMax = false;
            Min = UInt32.MinValue;
            Max = UInt32.MaxValue;
        }
        public Uint32Variable(UInt32 value, UInt32 min, UInt32 max)
        {
            this.Value = value;
            HasMinMax = true;
            this.Min = min;
            this.Max = max;
            if (value > max)
                value = max;
            if (value < min)
                value = min;
        }
    }
    public class Uint16Variable : NetVariable
    {
        public Action ValueChanged { get; set; }
        private UInt16 _value;
        public UInt16 Value
        {
            get
            {
                return _value;

            }
            set
            {
                _value = value;
                if (_value > Max && HasMinMax)
                    _value = Max;
                if (_value < Min && HasMinMax)
                    _value = Min;
                Status = VariableStatus.Changed;
                ValueChanged?.Invoke();
            }
        }
        public UInt16 Min { get; set; }
        public UInt16 Max { get; set; }
        public bool HasMinMax { get; set; }

        public Uint16Variable()
        {
            HasMinMax = false;
            Min = UInt16.MinValue;
            Max = UInt16.MaxValue;
        }
        public Uint16Variable(UInt16 value)
        {
            this.Value = value;
            HasMinMax = false;
            Min = UInt16.MinValue;
            Max = UInt16.MaxValue;
        }
        public Uint16Variable(UInt16 value, UInt16 min, UInt16 max)
        {
            this.Value = value;
            HasMinMax = true;
            this.Min = min;
            this.Max = max;
            if (value > max)
                value = max;
            if (value < min)
                value = min;
        }
        private UInt16 _netValue;
        public int PacketNumber { get; set; }
        public UInt16 NetValue
        {
            get => _netValue;
            set
            {
                bool changed = _value != _netValue;
                _netValue = value;

                if (_netValue > Max && HasMinMax)
                    _netValue = Max;
                if (_netValue < Min && HasMinMax)
                    _netValue = Min;
                if (!changed)
                {
                    _value = _netValue;
                    Status = VariableStatus.Loaded;
                    ValueChanged?.Invoke();
                }
            }
        }
    }
}
