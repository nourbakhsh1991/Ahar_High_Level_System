using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.View.Bottom;
using AharHighLevel.View.LeftModule;
using AharHighLevel.View.MainModule;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.Bootstrapper
{
    public class ModuleServices : IModuleServices
    {
        private readonly IUnityContainer m_Container;
        private static Dictionary<string, Dictionary<string, object>> views = new Dictionary<string, Dictionary<string, object>>();

        public ModuleServices(IUnityContainer container)
        {
            m_Container = container;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var LoadProjectEvent = eventAggregator.GetEvent<LoadProjectEventAggregator>();
            LoadProjectEvent.Subscribe(LoadProjectEventHandler, true);
        }
        public void LoadProjectEventHandler(bool val)
        {
            if(!val)
            {
                var regionManager = m_Container.Resolve<IRegionManager>();
                regionManager.Regions["MainRegion"].RemoveAll();
                ModuleServices.views.Clear();
            }
        }

        public void ActivateView(string viewName, string regionName = "MainRegion")
        {
            var regionManager = m_Container.Resolve<IRegionManager>();
            
            // غیر فعال کردن ویو
            IRegion workspaceRegion = regionManager.Regions[regionName];
            var views = workspaceRegion.Views;
            //foreach (var view in views)
            //{
            //    workspaceRegion.Deactivate(view);
            //}
            var region = ModuleServices.views.FirstOrDefault(a => a.Key == regionName);
            KeyValuePair<string, object> view = new KeyValuePair<string, object>(null, null);
            if (region.Value != null)
            {
                view = region.Value.FirstOrDefault(a => a.Key == viewName);
            }
            workspaceRegion.RemoveAll();
            if (region.Value != null && view.Value != null)
            {
                regionManager.Regions[regionName].Add(view.Value, viewName);
            }
            else
            {
                switch (viewName)
                {
                    case "LeftMenuView":
                        regionManager.Regions[regionName].Add(new LeftMenuView(), "LeftMenuView");
                        break;
                    case "Form1":
                        regionManager.Regions[regionName].Add(new Form1(), "Form1");
                        break;
                    case "Form2":
                        regionManager.Regions[regionName].Add(new Form2(), "Form2");
                        break;
                    case "Form3":
                        regionManager.Regions[regionName].Add(new Form3(), "Form3");
                        break;
                    case "Form4":
                        regionManager.Regions[regionName].Add(new Form4(), "Form4");
                        break;
                    case "Form5":
                        regionManager.Regions[regionName].Add(new Form5(), "Form5");
                        break;
                    case "Form6":
                        regionManager.Regions[regionName].Add(new Form6(), "Form6");
                        break;
                    case "Form7":
                        regionManager.Regions[regionName].Add(new Form7(), "Form7");
                        break;
                    case "Form8":
                        regionManager.Regions[regionName].Add(new Form8(), "Form8");
                        break;
                    case "LiveChart":
                        regionManager.Regions[regionName].Add(new OnlineChartView(), "LiveChart");
                        break;
                    case "EndlessChart":
                        regionManager.Regions[regionName].Add(new FastChartView(), "EndlessChart");
                        break;
                    case "AppStateView":
                        regionManager.Regions[regionName].Add(new AppStateView(), "AppStateView");
                        break;
                    case "ConfigureRd":
                        regionManager.Regions[regionName].Add(new ConfigureRd(), "ConfigureRd");
                        break;
                    case "ConfigureSd":
                        regionManager.Regions[regionName].Add(new ConfigureSd(), "ConfigureSd");
                        break;
                    case "ConfigurePm":
                        regionManager.Regions[regionName].Add(new ConfigurePm(), "ConfigurePm");
                        break;
                    case "ConfigurePb":
                        regionManager.Regions[regionName].Add(new ConfigurePb(), "ConfigurePb");
                        break;
                    case "SptAv":
                        regionManager.Regions[regionName].Add(new SptAv(), "SptAv");
                        break;
                    case "SptFc":
                        regionManager.Regions[regionName].Add(new SptFc(), "SptFc");
                        break;
                    case "SptStatup":
                        regionManager.Regions[regionName].Add(new SptStatup(), "SptStatup");
                        break;
                    case "CtrlAv":
                        regionManager.Regions[regionName].Add(new CtrlAv(), "CtrlAv");
                        break;
                    case "CtrlFc":
                        regionManager.Regions[regionName].Add(new CtrlFc(), "CtrlFc");
                        break;
                    case "CtrlPf":
                        regionManager.Regions[regionName].Add(new CtrlPf(), "CtrlPf");
                        break;
                    case "CtrlVar":
                        regionManager.Regions[regionName].Add(new CtrlVar(), "CtrlVar");
                        break;
                    case "LimConfigure":
                        regionManager.Regions[regionName].Add(new LimConfigure(), "LimConfigure");
                        break;
                    case "LimUli":
                        regionManager.Regions[regionName].Add(new LimUli(), "LimUli");
                        break;
                    case "LimOli":
                        regionManager.Regions[regionName].Add(new LimOli(), "CtrlVar");
                        break;
                    case "LimSc":
                        regionManager.Regions[regionName].Add(new LimSc(), "LimSc");
                        break;
                    case "LimVf":
                        regionManager.Regions[regionName].Add(new LimVf(), "LimVf");
                        break;
                    case "PrcConfigure":
                        regionManager.Regions[regionName].Add(new PrcConfigure(), "PrcConfigure");
                        break;
                    case "PrcPb":
                        regionManager.Regions[regionName].Add(new PrcPb(), "PrcPb");
                        break;
                    case "PrcTemp":
                        regionManager.Regions[regionName].Add(new PrcTemp(), "PrcTemp");
                        break;
                    case "PrcSrvn":
                        regionManager.Regions[regionName].Add(new PrcSrvn(), "PrcSrvn");
                        break;
                    case "PsConfigure":
                        regionManager.Regions[regionName].Add(new PsConfigure(), "PsConfigure");
                        break;
                    case "PsParameter":
                        regionManager.Regions[regionName].Add(new PsParameter(), "PsParameter");
                        break;
                    case "OpOm":
                        regionManager.Regions[regionName].Add(new OpOm(), "OpOm");
                        break;
                    case "ConfigureInformation":
                        regionManager.Regions[regionName].Add(new ConfigureInformation(), "ConfigureInformation");
                        break;
                    case "SystemAlarmView":
                        regionManager.Regions[regionName].Add(new SystemAlarmView(), "SystemAlarmView");
                        break;
                    case "LimCrv":
                        regionManager.Regions[regionName].Add(new LimCrv(), "LimCrv");
                        break;
                    case "SystemState":
                        regionManager.Regions[regionName].Add(new SystemState(), "SystemState");
                        break;
                    case "IOState":
                        regionManager.Regions[regionName].Add(new IOState(), "IOState");
                        break;

                }
            }

            if (region.Value == null)
            {
                ModuleServices.views.Add(regionName, new Dictionary<string, object>());
            }
            if (view.Value == null)
            {
                ModuleServices.views[regionName].Add(viewName, workspaceRegion.Views.First());
            }
            //فعال کردن ویو انتخاب شده
            //var viewToActivate = regionManager.Regions[regionName].GetView(viewName);
            //  regionManager.Regions[regionName].Activate(viewToActivate);
        }
    }
}
