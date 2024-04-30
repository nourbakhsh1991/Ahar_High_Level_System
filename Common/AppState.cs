using AharHighLevel.EventAggregator;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace AharHighLevel
{
    public class AppState
    {
        public string Message { get; set; }
        public string ShortMessage { get; set; }
        public int State { get; set; }
        public bool SendAppState(IUnityContainer container)
        {
            if (container != null)
            {
                var eventAggregator = container.Resolve<IEventAggregator>();
                var appStateEvent = eventAggregator.GetEvent<AppStateEventAggregator>();
                appStateEvent.Publish(this);
                return true;
            }
            return false;
            
        }
    }
}
