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
    class StatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stat = (VariableStatus) value;
            var SuccessBrush = (Application.Current.FindResource("SuccessBrush") as SolidColorBrush);
            var DangerBrush = (Application.Current.FindResource("DangerBrush") as SolidColorBrush);
            var TextBrush = (Application.Current.FindResource("TextBrush") as SolidColorBrush);
            var DisabledBrush = (Application.Current.FindResource("TextBrush") as SolidColorBrush);
            var ReadOnlyBrush = (Application.Current.FindResource("ReadOnlyBrush") as SolidColorBrush);

            if (stat == VariableStatus.Init)
                return new SolidColorBrush()
                {
                    Color = TextBrush.Color,
                    Opacity = 0
                };
            if (stat == VariableStatus.Changed)
                return new SolidColorBrush()
                {
                    Color = SuccessBrush.Color,
                    Opacity = .7
                };
            if (stat == VariableStatus.Wrong)
                return new SolidColorBrush()
                {
                    Color = DangerBrush.Color,
                    Opacity = .21
                };
            if (stat == VariableStatus.Loaded)
                return new SolidColorBrush()
                {
                    Color = TextBrush.Color,
                    Opacity = 0
                };
            if (stat == VariableStatus.ReadOnly)
                return new SolidColorBrush()
                {
                    Color = TextBrush.Color,
                    Opacity = .1
                };

            return new SolidColorBrush()
            {
                Color = TextBrush.Color,
                Opacity = 0
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
