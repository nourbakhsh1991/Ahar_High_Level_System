using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Bootstrapper;
using AharHighLevel.View.MainModule;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace AharHighLevel.Modules
{
    class RightModules : IModule
    {

        private IUnityContainer moduleContainer;

        private readonly string moduleName = "RightModules";

        public RightModules(IUnityContainer container)
        {
            moduleContainer = container;
        }

        ~RightModules()
        {
            var eventAggregator = moduleContainer.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Unsubscribe(ViewRequestedEventHandler);
        }

        public void Initialize()
        {
            var regionManager = moduleContainer.Resolve<IRegionManager>();
            var eventAggregator = moduleContainer.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Subscribe(this.ViewRequestedEventHandler, true);
        }


        public void ViewRequestedEventHandler(string s)
        {
            dynamic Command = JsonConvert.DeserializeObject(s);
            var regionManager = moduleContainer.Resolve<IRegionManager>();
            if (Command.command != "ActivateView" || (Command.RegionName == null)) return;
            var moduleServices = moduleContainer.Resolve<IModuleServices>();
            if (Command.RegionName.ToString() == "RightRegion")
                moduleServices.ActivateView(Command.ModuleName.ToString(), Command.RegionName.ToString());
            

        }
    }
}
