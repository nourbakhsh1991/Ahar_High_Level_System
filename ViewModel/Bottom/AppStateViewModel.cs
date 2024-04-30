using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using AharHighLevel.Bootstrapper;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.ProjectData;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.ViewModel.Bottom
{
    class AppStateViewModel : BaseViewModel
    {
        private long lastRefresh;
        //private NetworkMessenger _messenger;
        public string AppStateShortMessage { get; set; }
        public string RangeText { get; set; }
        public string AppStateMessage { get; set; }
        public string FormStatus { get; set; }
        public Brush StatusBrush { get; set; }
        public bool IsConnected { get; set; }
        public Brush BackGround { get; set; }
        public int RefreshIndex { get; set; }
        public string ParameterDetail { get; set; }

        public AppStateViewModel()
        {
            this.Initialize();

        }

        ~AppStateViewModel()
        {

        }

        private void Initialize()
        {
            RefreshIndex = 0;
            FormStatus = "Waiting for connection...";
            BackGround = Application.Current.FindResource("DangerBrush") as SolidColorBrush;
            //_messenger = AppStatics.Container.Resolve<INetworkMessenger>() as NetworkMessenger;
            lastRefresh = DateTime.Now.Ticks;
            StatusBrush = Application.Current.FindResource("HighlightBrush") as SolidColorBrush;
            AppStateMessage = "Disconnected";
            AppStateShortMessage = "Disconnected";
            OnPropertyChanged(nameof(BackGround));
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            var formStat = eventAggregator.GetEvent<FormStatusEa>();
            var AppStateEvent = eventAggregator.GetEvent<AppStateEventAggregator>();
            var commandsEa = eventAggregator.GetEvent<FormsCommands>();
            commandsEa.Subscribe(CommandEaHandler);
            ParameterDetailEa = eventAggregator.GetEvent<FormParameterDetailEa>();
            ParameterDetailEa.Subscribe(ParameterDetailEaHandler, true);
            AppStateEvent.Subscribe(this.AppStateEventHandler, true);
            formStat.Subscribe(FormStatusEaHandler, true);
            // commands

        }

        private void CommandEaHandler(string obj)
        {
            if (obj == AppCommands.FormDataRefresh)
            {
                if (AppStatics.Messenger.IsConnected)
                {
                    RefreshIndex++;
                    if (RefreshIndex > 13)
                        RefreshIndex = 1;

                }
                else
                {
                    AppStatics.Messenger.Disconnect();
                    RefreshIndex = 0;
                }
                OnPropertyChanged(nameof(RefreshIndex));
            }
        }
        

        private void ParameterDetailEaHandler(Tuple<NetVariable, bool> obj)
        {
            if (obj.Item2)
            {
                if (obj.Item1 is RealVariable real)
                {
                    ParameterDetail = "[Name]: " + real.Label;
                    if (real.HasMinMax)
                    {
                        ParameterDetail += ";      [Min]: " + real.Min;
                        ParameterDetail += ";      [Max]: " + real.Max;
                    }

                    if (real.Resolution != 0)
                    {
                        ParameterDetail += ";      [Resolution]: " + real.Resolution;
                    }
                }
                else if (obj.Item1 is EnumVariable Enum)
                {
                    ParameterDetail = "[Name]: " + Enum.Label;
                    ParameterDetail += ";      [Values]: ";
                    foreach (var itm in Enum.Items)
                    {
                        ParameterDetail += itm+" ,";
                    }

                    ParameterDetail = ParameterDetail.Substring(0, ParameterDetail.Length - 1);
                }
                else
                {
                    ParameterDetail = "[Name]: " + obj.Item1.Label;
                }
            }
            else
            {
                ParameterDetail = "";
            }

            OnPropertyChanged(nameof(ParameterDetail));
        }

        private void FormStatusEaHandler(byte obj)
        {

            switch (obj)
            {
                case 254:
                    FormStatus = "Waiting for connection...";
                    StatusBrush = Application.Current.FindResource("HighlightBrush") as SolidColorBrush;
                    RefreshIndex = 0;
                    break;
                case 255:
                    FormStatus = "Just Connected";
                    StatusBrush = Application.Current.FindResource("HighlightBrush") as SolidColorBrush;
                    RefreshIndex = 1;
                    break;
                //case 0:
                //    FormStatus = "SelfTest";
                //    StatusBrush = Application.Current.FindResource("HighlightBrush") as SolidColorBrush;
                //    break;
                //case 1:
                //    FormStatus = "Setting";
                //    StatusBrush = Application.Current.FindResource("WarningBrush") as SolidColorBrush;
                //    break;
                //case 2:
                //    FormStatus = "Standby";
                //    StatusBrush = Application.Current.FindResource("HighlightBrush") as SolidColorBrush;
                //    break;
                //case 3:
                //    FormStatus = "Run";
                //    StatusBrush = Application.Current.FindResource("SuccessBrush") as SolidColorBrush;
                //    break;
                //case 4:
                //    FormStatus = "Error";
                //    StatusBrush = Application.Current.FindResource("DangerBrush") as SolidColorBrush;
                //    break;
                default:
                    FormStatus = obj.ToString();
                    StatusBrush = Application.Current.FindResource("HighlightBrush") as SolidColorBrush;
                    break;
            }
            OnPropertyChanged(nameof(FormStatus));
            OnPropertyChanged(nameof(StatusBrush));
            OnPropertyChanged(nameof(RefreshIndex));
        }

        private void AppStateEventHandler(AppState s)
        {
            try
            {
                if (s.State == (int) AppStates.SocketConnected)
                {
                    BackGround = Application.Current.FindResource("BaseBlueBrush") as SolidColorBrush;
                    IsConnected = true;
                }
                else
                {
                    BackGround = Application.Current.FindResource("DangerBrush") as SolidColorBrush;
                    IsConnected = false;
                }

                AppStateMessage = s.Message;
                AppStateShortMessage = s.ShortMessage;
                OnPropertyChanged(nameof(AppStateShortMessage));
                OnPropertyChanged(nameof(AppStateMessage));
                OnPropertyChanged(nameof(BackGround));
                OnPropertyChanged(nameof(IsConnected));
            }
            catch { }
        }

    }
}
