using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Bootstrapper;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace AharHighLevel.Modules
{
    class MainModule : IModule
    {

        private readonly IUnityContainer moduleContainer;

        private readonly string moduleName = "SelfTestModule";

        public MainModule(IUnityContainer container)
        {
            moduleContainer = container;
        }

        ~MainModule()
        {
            var eventAggregator = moduleContainer.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Unsubscribe(ViewRequestedEventHandler);
        }

        public void Initialize()
        {
            var regionManager = moduleContainer.Resolve<IRegionManager>();
            //regionManager.Regions["MainRegion"].Add(new SelfTestView(moduleContainer), "SelfTestView");

            var eventAggregator = moduleContainer.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Subscribe(this.ViewRequestedEventHandler, true);
        }

        public void ViewRequestedEventHandler(string s)
        {
            dynamic Command = JsonConvert.DeserializeObject(s);
            if (Command.command != "ActivateView") return;
            var moduleServices = moduleContainer.Resolve<IModuleServices>();
            if (Command.RegionName != null && Command.RegionName.ToString() == "MainRegion")
                moduleServices.ActivateView(Command.ModuleName.ToString(), Command.RegionName.ToString());
            else if (Command.RegionName == null)
                moduleServices.ActivateView(Command.ModuleName.ToString());
        }
    }
}
