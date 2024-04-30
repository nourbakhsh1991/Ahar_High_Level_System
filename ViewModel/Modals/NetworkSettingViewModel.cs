using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AharHighLevel.Bootstrapper;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.ViewModel.Modals
{
    class NetworkSettingViewModel : BaseViewModel
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        private string _password;
        private bool waitingConnection;
        public bool IpPortVisible { get; set; }
        public string Caption { get; set; }

        private BaseViewModel vmTemp;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //private NetworkMessenger _messenger;

        public ICommand Save { get; set; }
        public ICommand Connect { get; set; }
        public ICommand Exit { get; set; }
        public string PM { get; set; }

        public ICommand Send { get; set; }

        public decimal Addr1 { get; set; }
        public decimal Addr2 { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public NetworkSettingViewModel()
        {
            this.Initialize();
        }
        ~NetworkSettingViewModel()
        {

        }
        private void Initialize()
        {
            IpPortVisible = true;
            Caption = "Connect";
            _password = "123"; // TODO Set To ""
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(FormEaHandler, true);
            Ip = AharHighLevel.Properties.Settings.Default.ip;
            Port = AharHighLevel.Properties.Settings.Default.port;
            AckTimer.Elapsed += AckTimer_Elapsed;
            //_messenger = AppStatics.Container.Resolve<INetworkMessenger>() as NetworkMessenger;
            OnPropertyChanged(nameof(Ip));
            OnPropertyChanged(nameof(Port));
            Width = 450;
            Height = 350;
            Save = new RelayCommand(SaveExe, CanSave);
            Connect = new RelayCommand(ConnectExecute, CanConnectExecute);
            Send = new RelayCommand(SendExecute, CanSendExecute);
            Exit = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.Cancel;
                _notification.Confirmed = false;
                FinishInteraction?.Invoke();
            });
        }

        private void SendExecute(object obj)
        {
            var data = new List<byte>();
            data.AddRange(BitConverter.GetBytes((float)Addr1));
            data.AddRange(BitConverter.GetBytes((float)Addr2));
            var sent = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 58,
                PacketType = PacketTypes.Command,
                Source = Devices.HighLevelSystem,
                Destination = Devices.Ahar1,
                Data = data,
                DataNumber = (byte)data.Count
            });
            if (sent)
            {
                waitingConnection = true;
                AckTimer.Start();
                vmTemp = new MessageBoxViewModel("Profibus addresses configuration is underway…", MessageBoxTypes.Loading, 0, "Profibus", 400,220);
                var view = new MessageBoxView()
                {
                    DataContext = vmTemp
                };
                PopupContent = view;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                }, (notification) =>
                {

                });
            }
            else
            {
                waitingConnection = true;
                AckTimer.Start();
                vmTemp = new MessageBoxViewModel("Configuration of profibus addresses failed.",
                    MessageBoxTypes.Error,
                    (int)MessageBoxButtons.Ok, "Profibus", 300);
                var view = new MessageBoxView()
                {
                    DataContext = vmTemp
                };
                PopupContent = view;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                }, (notification) =>
                {

                });
                AppStatics.Messenger.Disconnect();
            }
        }

        public void PasswordChanged(object sender, RoutedEventArgs args)
        {
            _password = (sender as PasswordBox).Password;
        }

        private void AckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (waitingConnection && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    vmTemp.FinishInteraction?.Invoke();
                    vmTemp = null;
                    waitingConnection = false;
                    AckTimer.Stop();
                    AppStatics.Messenger.Disconnect();
                    var vw = new MessageBoxViewModel("Connection Failed (timeout).", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Connect", 450,270);
                    var view = new MessageBoxView()
                    {
                        DataContext = vw
                    };
                    AppStatics.FileHandler.GenerateLog(new[] { " => Connection failed (timeout) after socket connection." });

                    PopupContent = view;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {

                    });
                });

            }
        }

        private void FormEaHandler(NetworkPacket obj)
        {
            if (obj.CSD == 0 && obj.PacketType == PacketTypes.Status && waitingConnection && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                    var formStat = eventAggregator.GetEvent<FormStatusEa>();
                    formStat.Publish(254);
                    AckTimer.Stop();
                    AppStatics.Messenger.Disconnect();
                    Save.Execute(null);
                    waitingConnection = false;
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    AppStatics.FileHandler.GenerateLog(new[] { " => Connection Failed, Wrong password has entered." });

                    var state = new AppState
                    {
                        Message = $"connected to address:{Ip} port:{Port} protocol type: {ProtocolType.Tcp}",
                        ShortMessage = $"Connected",
                        State = (int)AppStates.SocketConnected
                    };
                    state.SendAppState(AppStatics.Container);
                });
            }
            if (obj.CSD == 1 && obj.PacketType == PacketTypes.Status && waitingConnection && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                    var formStat = eventAggregator.GetEvent<FormStatusEa>();
                    formStat.Publish(255);
                    AckTimer.Stop();
                    Save.Execute(null);
                    waitingConnection = false;
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    AppStatics.FileHandler.GenerateLog(new[] { " => Connected Successfully." });

                    var state = new AppState
                    {
                        Message = $"connected to address:{Ip} port:{Port} protocol type: {ProtocolType.Tcp}",
                        ShortMessage = $"Connected",
                        State = (int)AppStates.SocketConnected
                    };
                    state.SendAppState(AppStatics.Container);
                    _notification.Result = MessageBoxButtons.Cancel;
                    _notification.Confirmed = false;
                    FinishInteraction?.Invoke();
                });
            }
            if (obj.CSD == 58 && obj.PacketType == PacketTypes.Status && waitingConnection && vmTemp != null && (vmTemp is MessageBoxViewModel vm))
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    AckTimer.Stop();
                    waitingConnection = false;
                    vm.Finished = true;
                    AppStatics.FileHandler.GenerateLog(new[] { " => Profibus addresses has successfully configured." });

                    _notification.Result = MessageBoxButtons.Ok;
                    _notification.Confirmed = true;
                    FinishInteraction?.Invoke();
                });

            }
        }

        private bool CanConnectExecute(object arg)
        {
            return AppStatics.Messenger != null && !AppStatics.Messenger.IsConnected;
        }
        private bool CanSendExecute(object arg)
        {
            return AppStatics.Messenger != null && AppStatics.Messenger.IsConnected;
        }

        private void ConnectExecute(object obj)
        {
            if (AppStatics.Messenger == null)
                AppStatics.Messenger = new NetworkMessenger();

            AppStatics.Messenger.Address = IPAddress.Parse(Ip);
            AppStatics.Messenger.Port = Port;
            var res = AppStatics.Messenger.Connect();
            if (res == 1)
            {
                AppStatics.FileHandler.GenerateLog(new[] { " => Socket Connected.Sending Password..." });
     
                var pass = (string)obj;

                var sent = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 37,
                    PacketType = PacketTypes.Command,
                    Source = Devices.HighLevelSystem,
                    Destination = Devices.Ahar1,
                    Data = Encoding.ASCII.GetBytes(_password).ToList(),
                    DataNumber = (byte)Encoding.ASCII.GetBytes(_password).Length
                });
                if (sent)
                {
                    waitingConnection = true;
                    AckTimer.Start();
                    vmTemp = new MessageBoxViewModel("Connecting...", MessageBoxTypes.Loading, 0, "Connect", 300,220);
                    var view = new MessageBoxView()
                    {
                        DataContext = vmTemp
                    };
                    PopupContent = view;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {

                    });
                }
                else
                {
                    AppStatics.Messenger.Disconnect();
                }


            }
            else
            {
                vmTemp = null;
                var vw = new MessageBoxViewModel("Connection Failed, Check Connection.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Connect", 400,250);
                var view = new MessageBoxView()
                {
                    DataContext = vw
                };
                PopupContent = view;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                }, (notification) =>
                {

                });
            }
        }

        private void SaveExe(object obj)
        {
            AharHighLevel.Properties.Settings.Default.ip = Ip;
            AharHighLevel.Properties.Settings.Default.port = Port;
            AharHighLevel.Properties.Settings.Default.Save();
        }
        private bool CanSave(object obj)
        {
            return true;
        }

    }
}
