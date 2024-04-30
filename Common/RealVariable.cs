using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class RealVariable : NetVariable
    {
        public Action<object> ValueChanged { get; set; }
        private string Error = "";

        public string Tooltip
        {
            get
            {
                var str = "Label: " + Label + "\r\n";
                if (HasMinMax)
                {
                    str += "Min: " + Min + "\r\n";
                    str += "Max: " + Max + "\r\n";
                }
                str += "Resolution: " + Resolution + "\r\n";
                str += "Valid: " + IsValid + "\r\n";
                if (HasError)
                {
                    str += "Error: " + Error + "\r\n";
                }

                return str;
            }
        }

        private decimal _value;
        private string _realValue;
        public string Value
        {
            get => _realValue ?? (_realValue = _value.ToString());
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Count(a=>a=='.') == 1 && value.Last()=='.')
                {
                    value += '0';
                }
                IsValid = true;
                _realValue = value;
                Status = VariableStatus.Changed;
                if (string.IsNullOrEmpty(value))
                {
                    IsValid = false;
                    Error = Label + "is require.";
                    Status = VariableStatus.Wrong;
                    ValueChanged?.Invoke(this);
                    return;
                }
                var isDecimal = decimal.TryParse(value, out decimal res);

                if (isDecimal)
                {
                    _value = res;
                    if (_value > Max && HasMinMax)
                    {
                        //_value = Max;
                        IsValid = false;
                        Error = Label + "must be <= " + Max;
                        Status = VariableStatus.Wrong;
                    }

                    if (_value < Min && HasMinMax)
                    {
                        //_value = Min;
                        IsValid = false;
                        Error = Label + "must be >= " + Min;
                        Status = VariableStatus.Wrong;
                    }
                    if (Resolution > 0)
                    {
                        _value = ResolutionService.SetResolution(_value, Resolution);// decimal.Round(_value, Resolution);
                        if (IsValid)
                        {
                            _realValue = _value.ToString();
                        }
                    }
                    ValueChanged?.Invoke(this);
                }
                else
                {
                    IsValid = false;
                    Error = Label + "needs to be Real.";
                    Status = VariableStatus.Wrong;
                    ValueChanged?.Invoke(this);
                }

            }
        }

        private decimal _netValue;

        public decimal NetValue
        {
            get => _netValue;
            set
            {
                bool changed = _value != _netValue;
                _netValue = value;
                //if (_netValue > Max && HasMinMax)
                //{
                //    Error = Label + "must be <= " + Max;
                //    Status = VariableStatus.Wrong;
                //}

                //if (_netValue < Min && HasMinMax)
                //{
                //    Error = Label + "must be >= " + Min;
                //    Status = VariableStatus.Wrong;
                //}
                if (Resolution > 0)
                    _netValue = ResolutionService.SetResolution(_netValue, Resolution);// decimal.Round(_netValue, Resolution);
                if (!changed && Status != VariableStatus.Changed)
                {
                    Value = _netValue.ToString();
                    _realValue = _value.ToString();
                    Status = IsValid
                        ? (IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init)
                        : VariableStatus.Wrong;

                    ValueChanged?.Invoke(this);
                }
            }
        }
        public decimal Resolution { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public bool HasMinMax { get; set; }

        public RealVariable()
        {
            HasMinMax = false;
            Min = decimal.MinValue;
            Max = decimal.MaxValue;
        }
        public RealVariable(decimal value)
        {
            this.Value = value.ToString();
            HasMinMax = false;
            Min = decimal.MinValue;
            Max = decimal.MaxValue;
        }

        public RealVariable(RealVariable real)
        {
            Value = real.Value;
            _netValue = real.NetValue;
            HasMinMax = real.HasMinMax;
            Min = real.Min;
            Max = real.Max;
            PacketNumber = real.PacketNumber;
            Resolution = real.Resolution;
            ValueChanged = real.ValueChanged;
            Label = real.Label;
            IsValid = real.IsValid;
            ReadOnly = real.ReadOnly;
            CanChangeInRunMode = real.CanChangeInRunMode;
            Status = real.Status;
            Unit = real.Unit;
        }
        public RealVariable(decimal value, decimal min, decimal max)
        {
            this.Value = value.ToString();
            HasMinMax = true;
            this.Min = min;
            this.Max = max;
            if (value > max)
                value = max;
            if (value < min)
                value = min;
        }

        public void IgnoreChanges()
        {
            _value = _netValue;
        }

        public override object Clone()
        {
            var Net = (NetVariable)base.Clone();
            var Real = new RealVariable
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
                Error = Error,
                _value = _value,
                _netValue = _netValue,
                _realValue = _realValue,
                HasMinMax = HasMinMax,
                Min = Min,
                Max = Max,
                Resolution = Resolution
            };
            return Real;
        }
    }
}
