using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AharHighLevel.Validation
{
    class RealRangeRule : ValidationRule
    {
        public string Name
        {
            get;
            set;
        }

        decimal min = decimal.MinValue;
        public decimal Min
        {
            get { return min; }
            set { min = value; }
        }

        decimal max = decimal.MaxValue;
        public decimal Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!String.IsNullOrEmpty((string)value))
            {
                if (Name.Length == 0)
                    Name = "Field";
                try
                {
                    if (((string)value).Length > 0)
                    {
                        decimal val = decimal.Parse((String)value);
                        if (val > max)
                            return new ValidationResult(false, Name + " must be <= " + Max + ".");
                        if (val < min)
                            return new ValidationResult(false, Name + " must be >= " + Min + ".");
                    }
                }
                catch (Exception)
                {
                    // Try to match the system generated error message so it does not look out of place.
                    return new ValidationResult(false, Name + " is not in a correct numeric format.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
