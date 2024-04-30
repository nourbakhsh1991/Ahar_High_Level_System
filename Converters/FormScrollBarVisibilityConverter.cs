using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;

namespace AharHighLevel.Converters
{
    public class FormScrollBarVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double val && int.TryParse(parameter.ToString(), out int prm))
            {
                if (prm == 1)
                {
                    if (val > AppStatics.MinFormWidth) return ScrollBarVisibility.Disabled;
                    return ScrollBarVisibility.Visible;
                }
                else
                {
                    if (val > AppStatics.MinFormHeight) return ScrollBarVisibility.Disabled;
                    return ScrollBarVisibility.Visible;
                }
            }

            return ScrollBarVisibility.Disabled;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
