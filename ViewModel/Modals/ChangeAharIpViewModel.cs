using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.ViewModel.Modals
{
    public class ChangeAharIpViewModel : BaseViewModel
    {
        public string Ip { get; set; }
        public int Port { get; set; }

        public bool InProcess { get; set; }

        public ICommand Change { get; set; }
        public ICommand Exit { get; set; }
        public int Addr1 { get; set; }
        public int Addr2 { get; set; }

        public ICommand Send { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        private BaseViewModel vmTemp;
        public ChangeAharIpViewModel()
        {
            this.Initialize();
        }
        ~ChangeAharIpViewModel()
        {

        }

        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(FormEaHandler, true);
            Ip = AharHighLevel.Properties.Settings.Default.ip;
            Port = AharHighLevel.Properties.Settings.Default.port;
            AckTimer.Elapsed += AckTimerOnElapsed;
            Width = 500;
            Height = 320;
            Change = new RelayCommand(ChangeExecute, CanChangeExecute);
            Exit = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.Cancel;
                _notification.Confirmed = false;
                FinishInteraction?.Invoke();
            }, o => !InProcess);
        }

        private bool CanChangeExecute(object arg)
        {
            return AppStatics.Messenger != null && AppStatics.Messenger.IsConnected && !InProcess;
        }

        private void ChangeExecute(object obj)
        {
            var data = new List<byte>();
            var ipParts = Ip.Split('.');
            foreach (var part in ipParts)
            {
                data.Add(byte.Parse(part));
            }
            data.AddRange(BitConverter.GetBytes(Port));
            data.AddRange(BitConverter.GetBytes(Addr1));
            data.AddRange(BitConverter.GetBytes(Addr2));
            var sent = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 59,
                PacketType = PacketTypes.Data,
                Source = Devices.HighLevelSystem,
                Destination = Devices.Ahar1,
                Data = data,
                DataNumber = (byte)data.Count
            });
            if (sent)
            {
                InProcess = true;
                AckTimer.Start();
                vmTemp = new MessageBoxViewModel("Changing Ethernet Address...", MessageBoxTypes.Loading, 0, "Ethernet", 300);
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
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Changing of IP address failed.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Ethernet")
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

        private void AckTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (InProcess && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    vmTemp.FinishInteraction?.Invoke();
                    vmTemp = null;
                    InProcess = false;
                    AckTimer.Stop();
                    //AppStatics.Messenger.Disconnect();
                    var vw = new MessageBoxViewModel("Changing of IP address failed.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Connect", 300);
                    var view = new MessageBoxView()
                    {
                        DataContext = vw
                    };
                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Connection failed (timeout).");
                        sw.Flush();
                        sw.Close();
                    }
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
            if (obj.CSD == 59 && obj.PacketType == PacketTypes.Status && InProcess && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    if (!Directory.Exists(AppStatics.projectFolder + "\\history\\"))
                    {
                        Directory.CreateDirectory(AppStatics.projectFolder + "\\history\\");
                    }

                    var Time = DateTime.Now.Ticks;
                    var fileName = AppStatics.projectFolder + "\\history\\ConnectionSetting_" + Time + ".txt";
                    using (StreamWriter swal = File.AppendText(fileName))
                    {

                        swal.WriteLine(new DateTime(Time).ToString("G") + " Old Ip Address  => " + AppStatics.Messenger.GetIpAddress());
                        swal.WriteLine(new DateTime(Time).ToString("G") + " New Ip Address  => " + Ip + ":" + Port);
                        swal.WriteLine(new DateTime(Time).ToString("G") + " Profibus Address 1  => " + Addr1);
                        swal.WriteLine(new DateTime(Time).ToString("G") + " Profibus Address 2  => " + Addr2);
                        swal.Flush();
                        swal.Close();
                    }

                    var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                    var formStat = eventAggregator.GetEvent<FormStatusEa>();
                    formStat.Publish(254);
                    AckTimer.Stop();
                    InProcess = false;
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    AppStatics.FileHandler.GenerateLog(new[]
                    {
                        " => Connection setting Changed.",
                        "\tIp:" + Ip,
                        "\tPort: " + Port,
                        "\tProfibus Address 1: "+Addr1,
                        "\tProfibus Address 2: "+Addr2,
                    });
                    AharHighLevel.Properties.Settings.Default.ip = Ip;
                    AharHighLevel.Properties.Settings.Default.port = Port;
                    AharHighLevel.Properties.Settings.Default.Save();
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Connection Settings has successfully changed.Please Reconnect.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok, "Ethernet")
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
                    _notification.Result = MessageBoxButtons.Ok;
                    _notification.Confirmed = true;
                    FinishInteraction?.Invoke();
                });
            }
        }
    }
}
