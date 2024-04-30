using System.Collections.Generic;
using System.Windows.Input;
using AharHighLevel.Bootstrapper;
using AharHighLevel.View.MainModule;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.ViewModel.LeftModule
{
    class LeftMenuViewModel : BaseViewModel
    {
        private IEnumerable<FormsMenuVM> _forms;
        public ICommand Form1Command { get; internal set; }
        public ICommand Form2Command { get; internal set; }
        public ICommand Form3Command { get; internal set; }
        public ICommand Form4Command { get; internal set; }
        public ICommand Form5Command { get; internal set; }
        public ICommand Form6Command { get; internal set; }
        public ICommand Form7Command { get; internal set; }
        public ICommand Form8Command { get; internal set; }
        public ICommand Form9Command { get; internal set; }
        public ICommand Form10Command { get; internal set; }
        public ICommand Form11Command { get; internal set; }
        public ICommand Form12Command { get; internal set; }
        public ICommand Form13Command { get; internal set; }
        public ICommand Form14Command { get; internal set; }

        public ICommand OpenViewCommand { get; set; }

        public IEnumerable<FormsMenuVM> Forms
        {
            get => _forms;
            set
            {
                _forms = value;
                OnPropertyChanged("Forms");
            }
        }


        public LeftMenuViewModel()
        {
            this.Initialize();
        }

        ~LeftMenuViewModel()
        {
        }

        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            // commands
            Form1Command = new RelayCommand(GotoForm1, CanGotoForm1);
            Form2Command = new RelayCommand(GotoForm2, CanGotoForm2);
            Form3Command = new RelayCommand(GotoForm3, CanGotoForm3);
            Form4Command = new RelayCommand(GotoForm4, CanGotoForm4);
            Form5Command = new RelayCommand(GotoForm5, CanGotoForm5);
            Form6Command = new RelayCommand(GotoForm6, CanGotoForm6);
            Form7Command = new RelayCommand(GotoForm7, CanGotoForm7);
            Form8Command = new RelayCommand(GotoForm8, CanGotoForm8);
            Form9Command = new RelayCommand(GotoForm9, CanGotoForm9);
            Form10Command = new RelayCommand(GotoForm10, CanGotoForm10);
            Form11Command = new RelayCommand(GotoForm11, CanGotoForm11);
            Form12Command = new RelayCommand(GotoForm12, CanGotoForm12);
            Form13Command = new RelayCommand(GotoForm13, CanGotoForm13);
            Form14Command = new RelayCommand(GotoForm14, CanGotoForm14);
            OpenViewCommand = new RelayCommand(OpenViewCommandExe, o => true);
            _forms = new[]
            {
                new FormsMenuVM
                {
                    Name = "Design",
                    Items = new[]
                    {
                        new FormVM("Power meter","Form1", typeof(Form1)),
                        new FormVM("AVR","Form2", typeof(Form2)),
                        new FormVM("FCR","Form3", typeof(Form3)),
                        new FormVM("Voltage feedback","Form4", typeof(Form4)),
                        new FormVM("PSS","Form5", typeof(Form5)),
                        new FormVM("CT","Form6", typeof(Form6)),
                        new FormVM("FPGA Calibration","Form7", typeof(Form7)),
                        new FormVM("Micro Calibration","Form8", typeof(Form8)),
                    }
                },
                new FormsMenuVM()
                {
                    Name = "Configure",
                    Items = new []
                    {
                        new FormVM("Information","ConfigureInformation", typeof(ConfigureInformation)),
                        new FormVM("Rated Data","ConfigureRd", typeof(ConfigureRd)),
                        new FormVM("System Data","ConfigureSd", typeof(ConfigureSd)),
                        new FormVM("Power Meter","ConfigurePm", typeof(ConfigurePm)),
                        new FormVM("Power Bridge","ConfigurePb", typeof(ConfigurePb))
                    }
                },
                new FormsMenuVM()
                {
                    Name = "SetPoint",
                    Items = new []
                    {
                        new FormVM("AVR","SptAv", typeof(SptAv)),
                        new FormVM("FCR","SptFc", typeof(SptFc)),
                        new FormVM("Startup","SptStatup", typeof(SptStatup)),
                    }
                },
                new FormsMenuVM()
                {
                    Name = "Controllers",
                    Items = new []
                    {
                        new FormVM("AVR","CtrlAv", typeof(CtrlAv)),
                        new FormVM("FCR","CtrlFc", typeof(CtrlFc)),
                        new FormVM("VAR","CtrlVar", typeof(CtrlVar)),
                        new FormVM("PF","CtrlPf", typeof(CtrlPf)),
                    }
                },
                new FormsMenuVM()
                {
                    Name = "Limiters",
                    Items = new []
                    {
                        new FormVM("Configure","LimConfigure", typeof(LimConfigure)),
                        new FormVM("UEL","LimUli", typeof(LimUli)),
                        new FormVM("OEL","LimOli", typeof(LimOli)),
                        new FormVM("SCL","LimSc", typeof(LimSc)),
                        new FormVM("V/F","LimVf", typeof(LimVf)),
                        new FormVM("Curves","LimCrv", typeof(LimCrv)),
                    }
                },
                new FormsMenuVM()
                {
                    Name = "Protection",
                    Items = new []
                    {
                        new FormVM("Configure","PrcConfigure", typeof(PrcConfigure)),
                        new FormVM("Power Bridge","PrcPb", typeof(PrcPb)),
                        new FormVM("Temperature","PrcTemp", typeof(PrcTemp)),
                        new FormVM("Supervision","PrcSrvn", typeof(PrcSrvn)),
                    }
                },
                new FormsMenuVM()
                {
                    Name = "PSS",
                    Items = new []
                    {
                        new FormVM("Configure","PsConfigure", typeof(PsConfigure)),
                        new FormVM("Parameter","PsParameter", typeof(PsParameter)),
                    }
                },
                new FormsMenuVM()
                {
                    Name = "Operation",
                    Items = new []
                    {
                        new FormVM("Operation Mode","OpOm", typeof(OpOm)),
                        new FormVM("System State","SystemState", typeof(SystemState)),
                        new FormVM("I/O State","IOState", typeof(IOState)),
                        new FormVM("System Alarms","SystemAlarmView", typeof(SystemAlarmView)),
                    }
                },
                new FormsMenuVM
                {
                    Name = "Charts",
                    Items = new[]
                    {
                        new FormVM("Online","LiveChart", typeof(OnlineChartView)),
                        new FormVM("Fast","EndlessChart", typeof(FastChartView)),
                    }
                }
            };
        }

        private void OpenViewCommandExe(object obj)
        {
            if (obj is FormsMenuVM) return;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'" + ((FormVM)obj).Name + "','RegionName':'MainRegion'}");

        }
        private void GotoForm1(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form1','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm1(object obj)
        {
            return true;
        }
        private void GotoForm2(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form2','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm2(object obj)
        {
            return true;
        }
        private void GotoForm3(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form3','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm3(object obj)
        {
            return true;
        }
        private void GotoForm4(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form4','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm4(object obj)
        {
            return true;
        }
        private void GotoForm5(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form5','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm5(object obj)
        {
            return true;
        }
        private void GotoForm6(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form6','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm6(object obj)
        {
            return true;
        }
        private void GotoForm7(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form7','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm7(object obj)
        {
            return true;
        }
        private void GotoForm8(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form8','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm8(object obj)
        {
            return true;
        }
        private void GotoForm9(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form9','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm9(object obj)
        {
            return true;
        }
        private void GotoForm10(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form10','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm10(object obj)
        {
            return true;
        }
        private void GotoForm11(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form11','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm11(object obj)
        {
            return true;
        }
        private void GotoForm12(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form12','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm12(object obj)
        {
            return true;
        }
        private void GotoForm13(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form13','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm13(object obj)
        {
            return true;
        }
        private void GotoForm14(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'Form14','RegionName':'MainRegion'}");

        }
        private bool CanGotoForm14(object obj)
        {
            return true;
        }
    }
}
