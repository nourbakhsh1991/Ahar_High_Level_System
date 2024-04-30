using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AharHighLevel.Converters
{
    public class ColorOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(float.TryParse(parameter.ToString(), out var opacity)) || opacity > 1 || opacity < 0)
                throw new Exception("Invalid Opacity Value.");
            Color color = ((Color)value);
            color.A = (byte)(opacity * 255);
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
