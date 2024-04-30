using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using AharHighLevel.Common;
using MahApps.Metro.IconPacks;

namespace AharHighLevel.Converters
{
    public class AlarmEventsIconKindConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AlarmEventVariable val)
            {
                switch (val.Type)
                {
                    case 1:
                        return PackIconMaterialKind.AlertCircle;
                    case 2:
                        return PackIconMaterialKind.AlertCircle;
                    case 3:
                        return PackIconMaterialKind.AvTimer;
                    default:
                        return Brushes.Transparent;
                }
            }
            else
            {
                return PackIconMaterialKind.Help;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
