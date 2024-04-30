using MahApps.Metro.Controls;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using AharHighLevel.Models;
using AharHighLevel.Modules;
using AharHighLevel.Network;
using AharHighLevel.ProjectData;
using Microsoft.Practices.Unity;
using AharHighLevel.Common;

namespace AharHighLevel.Bootstrapper
{
    class AppBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            AppStatics.Container = Container;
            AppStatics.FileHandler = new FileHandler();
            AppStatics.Messenger = new NetworkMessenger();
            var shell = new Shell();
            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(MainModule));
            moduleCatalog.AddModule(typeof(BottomModule));
            moduleCatalog.AddModule(typeof(RightModules));
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IModuleServices, ModuleServices>();
            //Container.RegisterType<INetworkMessenger, NetworkMessenger>();
            //Container.RegisterType<IFileHandler, FileHandler>();
        }
    }
}
