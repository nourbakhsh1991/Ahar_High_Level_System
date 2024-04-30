using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AharHighLevel.Converters
{
    public class FormScrollBarSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double val && int.TryParse(parameter.ToString(), out int prm))
            {
                if (prm == 1)
                {
                    if (val > AppStatics.MinFormWidth) return val;
                    return AppStatics.MinFormWidth ;
                }
                else
                {
                    if (val > AppStatics.MinFormHeight) return val;
                    return AppStatics.MinFormHeight;
                }
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
