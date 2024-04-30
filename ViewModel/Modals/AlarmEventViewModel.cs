using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using MaterialDesignThemes.Wpf;
using Prism.Events;
using Microsoft.Practices.Unity;

namespace AharHighLevel.ViewModel.Modals
{
    public class AlarmEventViewModel : BaseViewModel
    {
        public bool HasRecord { get; set; }
        public bool InProcess { get; set; }
        public ICommand CancelCommand { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public List<AlarmEventVariable> AlarmEvents { get; set; }
        private BaseViewModel vmTemp;
        public AlarmEventViewModel()
        {
            this.Initialize();


        }
        ~AlarmEventViewModel()
        {

        }

        private void Initialize()
        {
            InProcess = false;
            Height = 700;
            Width = 600;
            AlarmEvents = new List<AlarmEventVariable>();
            CancelCommand = new RelayCommand(CancelCommandExecute, (o) => !InProcess);
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(this.FormEaHandler, true);
        }

        public void Loaded()
        {

            AckTimer.Elapsed += AckTimer_Elapsed;
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += SendRequest;
            timer.Start();


        }

        private void CancelCommandExecute(object obj)
        {
            _notification.Result = MessageBoxButtons.Cancel;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }

        private void SendRequest(object sender, ElapsedEventArgs e)
        {

            (sender as Timer).Stop();
            App.Current.Dispatcher.Invoke(() =>
            {
                if (vmTemp!= null)
                {
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    vmTemp.FinishInteraction?.Invoke();
                }
                vmTemp = new MessageBoxViewModel("Waiting for list of alarms and events.", MessageBoxTypes.Loading, 0, "");



                var res = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 48,
                    Destination = Devices.Ahar1,
                    PacketType = PacketTypes.Command,
                    Source = Devices.HighLevelSystem,
                    Data = null,
                    DataNumber = 0
                });
                if (res)
                {
                    InProcess = true;
                    AckTimer.Interval = 30000;
                    AckTimer.Start();
                    if (AppStatics.IsProjectLoaded)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { " => Alarms &  Events Requested." });
                    }
                    var loading = new MessageBoxView()
                    {
                        DataContext = vmTemp
                    };
                    PopupContent = loading;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    });

                }
                else
                {
                    InProcess = false;
                    vmTemp.FinishInteraction?.Invoke();
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    var fail = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Process Failed.",
                            MessageBoxTypes.Error,
                            (int)MessageBoxButtons.Ok,
                            "Alarms &  Events")
                    };
                    PopupContent = fail;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    });
                }
            });
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventargs)
        {

        }

        private void AckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            AckTimer.Stop();
            InProcess = false;
            if (AppStatics.IsProjectLoaded)
            {
                AppStatics.FileHandler.GenerateLog(new[] { " => Alarms & Events Receive Failed." });

            }
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                (vmTemp as MessageBoxViewModel).Finished = true;
                vmTemp.FinishInteraction?.Invoke();
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Alarms & Events")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
                FinishInteraction?.Invoke();
            });


        }

        private void FormEaHandler(NetworkPacket obj)
        {

            if (obj.PacketType == PacketTypes.Data && obj.CSD == 58)
            {
                if (!Directory.Exists(AppStatics.projectFolder + "\\history\\"))
                {
                    Directory.CreateDirectory(AppStatics.projectFolder + "\\history\\");
                }

                var fileName = AppStatics.projectFolder + "\\history\\AlarmEvent_" + DateTime.Now.Ticks + ".txt";
                //File.Create(fileName);
                //App.Current.Dispatcher.Invoke(() =>
                //{
                AckTimer.Stop();
                //(vmTemp as MessageBoxViewModel).Finished = true;
                //vmTemp.FinishInteraction?.Invoke();
                using (StreamWriter swal = File.AppendText(fileName))
                {
                    AlarmEvents = new List<AlarmEventVariable>();
                    for (int i = 8 * 0; i < 8 * 1; i++)
                    {
                        var alarm = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8);
                        var isValid = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8 + 2);
                        var Time = BitConverter.ToUInt32(obj.Data.ToArray(), i * 8 + 4);
                        var active = isValid == 1;
                        if (alarm != 0xFFFF && ConfigParams.AllAlarmEvents != null)
                        {
                            var val = ConfigParams.AllAlarmEvents.FirstOrDefault(a => a.Code == alarm);
                            if (val != null)
                            {

                                AlarmEvents.Add(new AlarmEventVariable()
                                {
                                    Type = 1,
                                    Message = val.Message,
                                    Code = alarm,
                                    Time = Time,
                                    IsActive = active,
                                    IsInternal = val.IsInternal,
                                });


                                swal.WriteLine(new DateTime(Time).ToString("G") + " Alarm [" + (active ? "Active" : "Inactive") + "] => ");
                                swal.WriteLine("\t\t\tCode: " + alarm);
                                swal.WriteLine("\t\t\tDescription: " + val.Message);
                                swal.Flush();
                            }
                            else
                            {
                                AlarmEvents.Add(new AlarmEventVariable()
                                {
                                    Type = 4,
                                    Message = "unkhnown alarm",
                                    Code = alarm,
                                    Time = Time,
                                    IsActive = active,
                                    IsInternal = false,
                                });
                                swal.WriteLine(new DateTime(Time).ToString("G") + " Fault [" + (active ? "Active" : "Inactive") + "] => ");
                                swal.WriteLine("\t\t\tCode: " + alarm);
                                swal.WriteLine("\t\t\tDescription: unkhnown alarm");
                                swal.Flush();
                            }

                        }
                    }
                    for (int i = 8 * 1; i < 8 * 2; i++)
                    {
                        var alarm = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8);
                        var isValid = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8 + 2);
                        var Time = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8 + 4);
                        var active = isValid == 1;
                        if (alarm != 0xFFFF && ConfigParams.AllAlarmEvents != null)
                        {
                            var val = ConfigParams.AllAlarmEvents.FirstOrDefault(a => a.Code == alarm);
                            if (val != null)
                            {
                                AlarmEvents.Add(new AlarmEventVariable()
                                {
                                    Type = 2,
                                    Message = val.Message,
                                    Code = alarm,
                                    Time = Time,
                                    IsActive = active,
                                    IsInternal = val.IsInternal,
                                });
                                swal.WriteLine(new DateTime(Time).ToString("G") + " Fault [" + (active ? "Active" : "Inactive") + "] => ");
                                swal.WriteLine("\t\t\tCode: " + alarm);
                                swal.WriteLine("\t\t\tDescription: " + val.Message);
                                swal.Flush();
                            }
                            else
                            {
                                AlarmEvents.Add(new AlarmEventVariable()
                                {
                                    Type = 4,
                                    Message = "unkhnown fault",
                                    Code = alarm,
                                    Time = Time,
                                    IsActive = active,
                                    IsInternal = false,
                                });
                                swal.WriteLine(new DateTime(Time).ToString("G") + " Fault [" + (active ? "Active" : "Inactive") + "] => ");
                                swal.WriteLine("\t\t\tCode: " + alarm);
                                swal.WriteLine("\t\t\tDescription: unkhnown fault");
                                swal.Flush();
                            }

                        }
                    }
                    for (int i = 8 * 2; i < 8 * 3; i++)
                    {
                        var alarm = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8);
                        var isValid = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8 + 2);
                        var Time = BitConverter.ToUInt16(obj.Data.ToArray(), i * 8 + 4);
                        var active = isValid == 1;
                        if (alarm != 0xFFFF && ConfigParams.AllAlarmEvents != null)
                        {
                            var val = ConfigParams.AllAlarmEvents.FirstOrDefault(a => a.Code == alarm);
                            if (val != null)
                            {
                                AlarmEvents.Add(new AlarmEventVariable()
                                {
                                    Type = 3,
                                    Message = val.Message,
                                    Code = alarm,
                                    Time = Time,
                                    IsActive = active,
                                    IsInternal = val.IsInternal,
                                });
                                swal.WriteLine(new DateTime(Time).ToString("G") + " Event [" + (active ? "Active" : "Inactive") + "] => ");
                                swal.WriteLine("\t\t\tCode: " + alarm);
                                swal.WriteLine("\t\t\tDescription: " + val.Message);
                                swal.Flush();
                            }
                            else
                            {
                                AlarmEvents.Add(new AlarmEventVariable()
                                {
                                    Type = 4,
                                    Message = "unkhnown event",
                                    Code = alarm,
                                    Time = Time,
                                    IsActive = active,
                                    IsInternal = false,
                                });
                                swal.WriteLine(new DateTime(Time).ToString("G") + " Fault [" + (active ? "Active" : "Inactive") + "] => ");
                                swal.WriteLine("\t\t\tCode: " + alarm);
                                swal.WriteLine("\t\t\tDescription: unkhnown event");
                                swal.Flush();
                            }
                        }
                    }
                    InProcess = false;
                    HasRecord = AlarmEvents.Count > 0;
                    OnPropertyChanged(nameof(HasRecord));
                    OnPropertyChanged(nameof(AlarmEvents));
                    AppStatics.FileHandler.GenerateLog(new[] { " => Alarms & Events Received Successfully." });
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    vmTemp.FinishInteraction?.Invoke();

                }
                //});

            }
        }
    }
}
