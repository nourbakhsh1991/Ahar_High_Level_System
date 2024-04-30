using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AharHighLevel.Bootstrapper;
using AharHighLevel.Common;
using Microsoft.Practices.Unity;
using Prism.Events;
using SciChart.Charting.Visuals;

namespace AharHighLevel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                ThemeManager.AddAccent("base",
                    new Uri("pack://application:,,,/AharHighLevel;component/theme/basetheme.xaml"));
                ThemeManager.ChangeAppStyle(Application.Current,
                    ThemeManager.GetAccent("Base"),
                    ThemeManager.GetAppTheme("BaseLight"));
                var bootstrapper = new AppBootstrapper();
                if (AharHighLevel.Properties.Settings.Default.RecentFiles == null)
                {
                    AharHighLevel.Properties.Settings.Default.RecentFiles =
                        new System.Collections.Specialized.StringCollection();
                    AharHighLevel.Properties.Settings.Default.Save();
                }

                SciChartSurface.SetRuntimeLicenseKey("lwABAAEAAAByxXD8TmnWARAnbABDdXN0b21lcj1SZXphO09yZGVySWQ9QUJUMjAwODAzLTQzODItMTQ4NDU7U3Vic2NyaXB0aW9uVmFsaWRUbz0wMy1BdWctMjA0MTtQcm9kdWN0Q29kZT1TQy1XUEYtU0RLLUVOVEVSUFJJU0UAPHQczGEzCbn33/uKdr3UrNqjaWAFJO5KjTXRFj6zbHjhVGvH0akszFGEGmzxaFU=");

                base.OnStartup(e);
                bootstrapper.Run();

                bootstrapper.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish(
                    "{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'true'}");
                bootstrapper.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish(
                    "{'command':'ActivateView','ModuleName':'AppStateView','RegionName':'BottomRegion','IsActive':'true'}");
                var a = ConfigParams.AllParams;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AharHighLevel.Properties.Settings.Default.Save();
            base.OnExit(e);
        }
    }
}
