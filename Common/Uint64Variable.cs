using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class Uint64Variable : NetVariable
    {
        public Action ValueChanged { get; set; }
        private UInt64 _value;
        public UInt64 Value
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
        public UInt64 Min { get; set; }
        public UInt64 Max { get; set; }
        public bool HasMinMax { get; set; }

        public Uint64Variable()
        {
            HasMinMax = false;
            Min = UInt64.MinValue;
            Max = UInt64.MaxValue;
        }
        public Uint64Variable(UInt64 value)
        {
            this.Value = value;
            HasMinMax = false;
            Min = UInt64.MinValue;
            Max = UInt64.MaxValue;
        }
        public Uint64Variable(UInt64 value, UInt64 min, UInt64 max)
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
}
