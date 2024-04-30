using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using AharHighLevel.Common;

namespace AharHighLevel.Converters
{
    public class ActiveAlarmToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stat = (bool)value;
            var tmp = (Application.Current.FindResource("NewGreenBrush") as SolidColorBrush);
            var SuccessBrush = new SolidColorBrush();
            SuccessBrush.Color = tmp.Color;
            SuccessBrush.Opacity = 1;
            var DangerBrush = (Application.Current.FindResource("DangerBrush") as SolidColorBrush);
           
            return stat ? (Brush)DangerBrush : (Brush)SuccessBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
