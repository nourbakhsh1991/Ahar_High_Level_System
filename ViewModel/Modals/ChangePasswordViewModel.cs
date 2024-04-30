using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class ChangePasswordViewModel:BaseViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public bool InProcess { get; set; }

        public ICommand Change { get; set; }
        public ICommand Exit { get; set; }


        public int Width { get; set; }
        public int Height { get; set; }
        private BaseViewModel vmTemp;
        public ChangePasswordViewModel()
        {
            this.Initialize();
        }
        ~ChangePasswordViewModel()
        {

        }

        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(FormEaHandler, true);
            AckTimer.Elapsed += AckTimerOnElapsed;
            Width = 400;
            Height = 250;
            Change = new RelayCommand(ChangeExecute, CanChangeExecute);
            Exit = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.Cancel;
                _notification.Confirmed = false;
                FinishInteraction?.Invoke();
            }, o => !InProcess);
        }

        public void SetPasswords(string old,string New)
        {
            NewPassword = New;
            OldPassword = old;
        }

        private bool CanChangeExecute(object arg)
        {
            return AppStatics.Messenger != null && AppStatics.Messenger.IsConnected && !InProcess;
        }

        private void ChangeExecute(object obj)
        {
            var data = new List<byte>();
            data.AddRange(Encoding.ASCII.GetBytes(OldPassword));
            data.AddRange(Encoding.ASCII.GetBytes(NewPassword));
            var sent = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 39,
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
                vmTemp = new MessageBoxViewModel("Changing Ahar Password...", MessageBoxTypes.Loading, 0, "Password", 300);
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
                    DataContext = new MessageBoxViewModel("Network Failure.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Password")
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
                    var vw = new MessageBoxViewModel("Connection Failed (Timeout).", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Connect", 300);
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
            if (obj.CSD == 39 && obj.PacketType == PacketTypes.Status && InProcess && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                    var formStat = eventAggregator.GetEvent<FormStatusEa>();
                    formStat.Publish(254);
                    AckTimer.Stop();
                    InProcess = false;
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Ahar Password Changed.");
                        sw.Flush();
                        sw.Close();
                    }
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Ahar Password Successfully Changed", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok, "Ethernet")
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
                });
            }
        }
    }
}
