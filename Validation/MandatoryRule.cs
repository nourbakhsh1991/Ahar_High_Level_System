using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AharHighLevel.Validation
{
    public class MandatoryRule : ValidationRule
    {
        public string Name
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty((string)value))
            {
                if (Name.Length == 0)
                    Name = "Field";
                return new ValidationResult(false, Name + " is mandatory.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
