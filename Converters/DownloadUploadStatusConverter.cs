using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace AharHighLevel.Converters
{
    public class DownloadUploadStatusConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is int val)
            {
                switch (val)
                {
                    case -1:
                        return PackIconMaterialKind.Close;
                    case 0:
                        return PackIconMaterialKind.TimerSand;
                    case 1:
                        return PackIconMaterialKind.Check;
                }
            }

            return PackIconMaterialKind.Help;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
