using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.ViewModel.Modals
{
    public class DownloadViewModel : BaseViewModel
    {
        public ICommand DownloadCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private bool CancelCanExecute { get; set; }
        private bool DownloadCanExecute { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool ShallReceiveData { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public ObservableCollection<Tuple<string, int>> Tasks { get; set; }
        public DownloadViewModel()
        {
            this.Initialize();


        }
        ~DownloadViewModel()
        {

        }

        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(FormsDataEa, true);
            DownloadCanExecute = true;
            CancelCanExecute = true;
            ShallReceiveData = false;
            Height = 500;
            Width = 400;
            DownloadCommand = new RelayCommand(DownloadCommandExecute, o => DownloadCanExecute);
            CancelCommand = new RelayCommand(CancelCommandExecute, (o) => CancelCanExecute);
            Tasks = new ObservableCollection<Tuple<string, int>>();
            AckTimer.Elapsed += AckTimer_Elapsed;
        }

        private void FormsDataEa(NetworkPacket obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            var data = new List<byte>();
            if (obj.CSD == 49 && obj.PacketType == PacketTypes.Status && ShallReceiveData)
            {
                AckTimer.Stop();
                // packet 1

                var pack1 = new List<NetVariable>();
                // Real
                pack1.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10023 && a.MainIndex <= 10067 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                // Bool
                pack1.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20005 && a.MainIndex <= 20010 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                // Enum
                pack1.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30011 && a.MainIndex <= 30014 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                data = PrepareDate(pack1);
                var res = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 50,
                    Destination = Devices.Ahar1,
                    PacketType = PacketTypes.Data,
                    Source = Devices.HighLevelSystem,
                    Data = data,
                    DataNumber = (byte) data.Count
                });
                if (res)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Pack 1 Sent", 1));
                    });
                    AckTimer.Interval = 30000;
                    AckTimer.Start();
                }
                else
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Failed to send.", -1));
                    });
 
                    ShallReceiveData = false;
                    DownloadCanExecute = true;
                    CancelCanExecute = true;
                }
            }
            if (obj.CSD == 50 && obj.PacketType == PacketTypes.Status && ShallReceiveData)
            {
                AckTimer.Stop();
                // packet 2

                var pack2 = new List<NetVariable>();
                // Real
                pack2.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10068 && a.MainIndex <= 10110 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                data = PrepareDate(pack2);
                var res = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 51,
                    Destination = Devices.Ahar1,
                    PacketType = PacketTypes.Data,
                    Source = Devices.HighLevelSystem,
                    Data = data,
                    DataNumber = (byte)data.Count
                });
                if (res)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Pack 2 Sent", 1));
                    });
                    AckTimer.Interval = 30000;
                    AckTimer.Start();
                }
                else
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Failed to send.", -1));
                    });
                    ShallReceiveData = false;
                    DownloadCanExecute = true;
                    CancelCanExecute = true;
                }
            }
            if (obj.CSD == 51 && obj.PacketType == PacketTypes.Status && ShallReceiveData)
            {
                AckTimer.Stop();
                // packet 4

                var pack4 = new List<NetVariable>();
                // Real
                pack4.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10111 && a.MainIndex <= 10152 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                // Bool
                pack4.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20011 && a.MainIndex <= 20027 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                // Enum
                pack4.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30015 && a.MainIndex <= 30017 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                data = PrepareDate(pack4);
                var res = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 52,
                    Destination = Devices.Ahar1,
                    PacketType = PacketTypes.Data,
                    Source = Devices.HighLevelSystem,
                    Data = data,
                    DataNumber = (byte)data.Count
                });
                if (res)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Pack 3 Sent", 1));
                    });
                    AckTimer.Interval = 30000;
                    AckTimer.Start();
                }
                else
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Failed to send.", -1));
                    });
                    ShallReceiveData = false;
                    DownloadCanExecute = true;
                    CancelCanExecute = true;
                }
            }
            if (obj.CSD == 52 && obj.PacketType == PacketTypes.Status && ShallReceiveData)
            {
                AckTimer.Stop();
                // packet 5

                var pack5 = new List<NetVariable>();
                // Real
                pack5.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10153 && a.MainIndex <= 10193 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                data = PrepareDate(pack5);
                var res = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 53,
                    Destination = Devices.Ahar1,
                    PacketType = PacketTypes.Data,
                    Source = Devices.HighLevelSystem,
                    Data = data,
                    DataNumber = (byte)data.Count
                });
                if (res)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Pack 4 Sent", 1));
                    });
                    AckTimer.Interval = 30000;
                    AckTimer.Start();
                }
                else
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Tasks.Add(new Tuple<string, int>("Failed to send.", -1));
                    });
                    ShallReceiveData = false;
                    DownloadCanExecute = true;
                    CancelCanExecute = true;
                }
            }
            if (obj.CSD == 53 && obj.PacketType == PacketTypes.Status && ShallReceiveData)
            {
                AckTimer.Stop();
                ShallReceiveData = false;
                CancelCanExecute = true;
                DownloadCanExecute = true;
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Pack 5 Sent", 1));
                    Tasks.Add(new Tuple<string, int>("Download operation has successfully done.", 1));
                });
                var folderPath = AppStatics.projectFolder;
                if (folderPath.EndsWith("\\"))
                {
                    folderPath = folderPath.Substring(0, folderPath.Length - 1);
                }
                var prjName = "\\project.APrj";
                var paramName = "\\params.APrm";
                var history = "\\history\\";
                var prj = new AharProjectType()
                {
                    Description = AppStatics.Project.Description ?? "",
                    ProjectNumber = AppStatics.Project.ProjectNumber,
                    UnitNumber = AppStatics.Project.UnitNumber,
                    UnitCapacity = AppStatics.Project.UnitCapacity,
                    EmployerName = AppStatics.Project.EmployerName,
                    InstallationDate = AppStatics.Project.InstallationDate,
                    LastModify = DateTime.UtcNow.Ticks,
                    Device = Common.SystemInformation.GetDeviceInformation(),
                    Username = Common.SystemInformation.GetUserInformation(),

                };
                dynamic d = new
                {
                    Status = ProjectDataStatus.Create,
                    folderPath = folderPath + history,
                    prjName = "Download_" + DateTime.Now.Ticks + ".Adl",
                    Title,
                    Description,
                    project = prj
                };
                if (!Directory.Exists(folderPath))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Folder Doesn't Exist.Please Reset The Program.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
                    };
                    DialogHost.Show(view, "RootDialog",
                        (object sender, DialogClosingEventArgs args) => { });
                    return;
                }

                if (!Directory.Exists(folderPath + history))
                {
                    Directory.CreateDirectory(folderPath + history);
                }
                AppStatics.FileHandler.GenerateLog(new []
                {
                    " => Download Successfully." ,
                    "\t Title: " + Title,
                    "\t Description: " + Description
                });
               
                var created = AppStatics.FileHandler.SaveDownloadDataHandler(d);


            }
        }

        private void AckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ShallReceiveData = false;
            AckTimer.Stop();
            App.Current.Dispatcher.Invoke(() =>
            {
                Tasks.Add(new Tuple<string, int>("Download operation failed. \n timeout has occurred", -1));
                AppStatics.FileHandler.GenerateLog(new[]
                {
                    " => Download Failed (Timeout)." ,
                    "\t Title: " + Title,
                    "\t Description: " + Description
                });

                //AppStatics.Messenger.Disconnect();
                ShallReceiveData = false;
                DownloadCanExecute = false;
                CancelCanExecute = true;
            });

        }

        private void CancelCommandExecute(object obj)
        {
            _notification.Result = MessageBoxButtons.Cancel;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }

        private void DownloadCommandExecute(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            if (AppStatics.HasSettingFault())
            {
                var nop = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Form(s) Is Not Valid.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Download",
                        400,
                        250)
                };
                PopupContent = nop;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                }, (notification) =>
                {
                });
                return;
            }
            AppStatics.FileHandler.GenerateLog(new[]
            {
                " => Download Started." ,
                "\t Title: " + Title,
                "\t Description: " + Description
            });

            var data = new List<byte>();
            ShallReceiveData = true;
            DownloadCanExecute = false;
            CancelCanExecute = false;
            // packet 3
            {
                var pack3 = new List<NetVariable>();
                // Real
                pack3.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex <= 10022 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                // Bool
                pack3.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20000 && a.MainIndex <= 20004 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                // Enum
                pack3.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30000 && a.MainIndex <= 30010 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                data = PrepareDate(pack3);
                var res = AppStatics.Messenger.SendData(new NetworkPacket()
                {
                    CSD = 49,
                    Destination = Devices.Ahar1,
                    PacketType = PacketTypes.Data,
                    Source = Devices.HighLevelSystem,
                    Data = data,
                    DataNumber = (byte)data.Count
                });
                if (res)
                {
                    AckTimer.Interval = 30000;
                    Tasks.Add(new Tuple<string, int>("Download operation is underway…", 0));
                    AckTimer.Start();
                }
                else
                {
                    AckTimer.Interval = 30000;
                    Tasks.Add(new Tuple<string, int>("Failed to send.", -1));
                    ShallReceiveData = false;
                    DownloadCanExecute = true;
                    CancelCanExecute = true;
                    AckTimer.Start();
                }

               

            }
            //commandEa.Publish(AppCommands.StartLoading + "&Sending Data ...");
            //AckTimer.Start();
        }

        private List<byte> PrepareDate(List<NetVariable> param)
        {
                var data = new List<byte>();
                var counter = 0;
                foreach (var itm in param)
                {
                    if (itm is RealVariable Real)
                    {
                        data.AddRange(BitConverter.GetBytes(float.Parse(Real.Value)));
                        counter++;
                    }
                }
                var value = 0;
                var subCounter = 0;
                foreach (var itm in param)
                {
                    if (itm is BoolVariable Bool)
                    {
                        value = (Bool.Value ? (value | 2.Pow(subCounter++)) : value);
                    }
                }
                foreach (var itm in param)
                {
                    if (itm is EnumVariable Enum)
                    {
                        var tmp = value;
                        for (var i = 0; i < Enum.SubIndexLength; i++)
                        {
                            value = ((Enum.Value & 2.Pow(i)) > 0) ? (value | (2.Pow(i + subCounter))) : value;
                        }
                    }
                }
                data.AddRange(BitConverter.GetBytes(value));

                return data;
            }
        }
    }
