using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AharHighLevel.Validation
{
    public class NumberRule : ValidationRule
    {
        public string Name
        {
            get;
            set;
        }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!String.IsNullOrEmpty((string)value))
            {
                if (Name.Length == 0)
                    Name = "Field";
                try
                {
                    Regex regex = new Regex("^-?\\d*(\\.\\d+)?$");
                   var res = regex.IsMatch((string)value);
                   if (!res)
                       return new ValidationResult(false, Name + " Must Be Numeric ");
               
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
