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
    public class ActiveAlarmEventsBackgroundBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var SuccessBrush = (Application.Current.FindResource("SuccessBrush") as SolidColorBrush);
            var WarningBrush = (Application.Current.FindResource("WarningBrush") as SolidColorBrush);
            var DangerBrush = (Application.Current.FindResource("DangerBrush") as SolidColorBrush);
            var TextBrush = (Application.Current.FindResource("TextBrush") as SolidColorBrush);
            var DisabledBrush = (Application.Current.FindResource("TextBrush") as SolidColorBrush);
            var ReadOnlyBrush = (Application.Current.FindResource("ReadOnlyBrush") as SolidColorBrush);
            
            if (value is AlarmEventVariable val)
            {
                switch (val.Type)
                {
                    case 1 when val.IsActive:
                        return WarningBrush;
                    case 2 when val.IsActive:
                        return DangerBrush;
                    case 3 when val.IsActive:
                        return ReadOnlyBrush;
                    case 4 :
                        return SuccessBrush;
                    default:
                        return Brushes.Transparent;
                }
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
