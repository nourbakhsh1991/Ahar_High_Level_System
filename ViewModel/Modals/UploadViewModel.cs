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
    public class UploadViewModel : BaseViewModel
    {
        public ICommand UploadCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private bool CancelCanExecute { get; set; }
        private bool UploadCanExecute { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool ShallReceiveData { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        private int packetCounter;
        private List<Tuple<int,List<byte>>> Datas { get; set; }

        public ObservableCollection<Tuple<string, int>> Tasks { get; set; }
        public UploadViewModel()
        {
            this.Initialize();


        }
        ~UploadViewModel()
        {

        }

        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(FormsDataEa, true);
            UploadCanExecute = true;
            CancelCanExecute = true;
            ShallReceiveData = false;
            Height = 500;
            Width = 400;
            UploadCommand = new RelayCommand(UploadCommandExecute, o => UploadCanExecute);
            CancelCommand = new RelayCommand(CancelCommandExecute, (o) => CancelCanExecute);
            Tasks = new ObservableCollection<Tuple<string, int>>();
            AckTimer.Elapsed += AckTimer_Elapsed;
        }

        private void FormsDataEa(NetworkPacket obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            var data = new List<byte>();
            if (obj.CSD == 49 && obj.PacketType == PacketTypes.Data && ShallReceiveData)
            {
                Datas.Add(new Tuple<int, List<byte>>(3, obj.Data));
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Pack 1 Received", 1));
                });
                packetCounter++;
                if (packetCounter>= 5 && AllPackagesRecived())
                {
                    UploadDone();
                }

            }
            if (obj.CSD == 50 && obj.PacketType == PacketTypes.Data && ShallReceiveData)
            {
                // packet 1
                Datas.Add(new Tuple<int, List<byte>>(1, obj.Data));
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Pack 2 Received", 1));
                });
                packetCounter++;
                if (packetCounter >= 5 && AllPackagesRecived())
                {
                    UploadDone();
                }
            }
            if (obj.CSD == 51 && obj.PacketType == PacketTypes.Data && ShallReceiveData)
            {
                // packet 2
                Datas.Add(new Tuple<int, List<byte>>(2, obj.Data));
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Pack 3 Received", 1));
                });
                packetCounter++;
                if (packetCounter >= 5 && AllPackagesRecived())
                {
                    UploadDone();
                }
            }
            if (obj.CSD == 52 && obj.PacketType == PacketTypes.Data && ShallReceiveData)
            {
                // packet 4
                Datas.Add(new Tuple<int, List<byte>>(4, obj.Data));
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Pack 4 Received", 1));
                });
                packetCounter++;
                if (packetCounter >= 5 && AllPackagesRecived())
                {
                    UploadDone();
                }
            }
            if (obj.CSD == 53 && obj.PacketType == PacketTypes.Data && ShallReceiveData)
            {
                // packet 5
                Datas.Add(new Tuple<int, List<byte>>(5, obj.Data));
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Pack 5 Received", 1));
                });
                packetCounter++;
                if (packetCounter >= 5 && AllPackagesRecived())
                {
                    UploadDone();
                }

            }
        }

        private void AckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ShallReceiveData = false;
            AckTimer.Stop();
            App.Current.Dispatcher.Invoke(() =>
            {
                Tasks.Add(new Tuple<string, int>("Failed(timeout).",-1));
                AppStatics.FileHandler.GenerateLog(new []
                {
                    " => Upload Failed (Timeout)." ,
                    "\t Title: " + Title,
                    "\t Description: " + Description
                });
                //AppStatics.Messenger.Disconnect();
                ShallReceiveData = false;
                UploadCanExecute = false;
                CancelCanExecute = true;
            });

        }

        private void CancelCommandExecute(object obj)
        {
            _notification.Result = MessageBoxButtons.Cancel;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }

        private void UploadCommandExecute(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            AppStatics.FileHandler.GenerateLog(new[]
            {
                " => Upload Started." ,
                "\t Title: " + Title,
                "\t Description: " + Description
            });
            
            ShallReceiveData = true;
            UploadCanExecute = false;
            CancelCanExecute = false;

            var res = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 56,
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Command,
                Source = Devices.HighLevelSystem,
                Data = null,
                DataNumber = 0
            });
            if (res)
            {
                AckTimer.Interval = 30000;
                Tasks.Add(new Tuple<string, int>("Receiving...", 0));
                packetCounter = 0;
                Datas = new List<Tuple<int, List<byte>>>();
                AckTimer.Start();
            }
            else
            {
                Tasks.Add(new Tuple<string, int>("Failed to receive.", -1));
                ShallReceiveData = false;
                UploadCanExecute = true;
                CancelCanExecute = true;
            }
        }

        private void PrepareDate(List<NetVariable> param, List<byte> data)
        {
            var counter = 0;
            var subCounter = 0;
            foreach (var itm in param)
            {
                if (itm is RealVariable real)
                {
                    real.NetValue = (decimal)BitConverter.ToSingle(data.ToArray(), counter * 4);
                    real.ReadOnly = real.IsReadOnly;
                    counter++;
                }
            }
            foreach (var itm in param)
            {
                if (itm is BoolVariable boolvar)
                {
                    var bit = BitConverter.ToInt32(data.ToArray(), counter);
                    boolvar.NetValue = (bit & 2.Pow(subCounter)) == 2.Pow(subCounter);
                    subCounter++;
                }
            }
            foreach (var itm in param)
            {
                if (itm is EnumVariable enumvar)
                {
                    var bit = BitConverter.ToInt32(data.ToArray(), counter);
                    var val = 0;
                    for (int i = 0; i < enumvar.SubIndexLength; i++)
                    {
                        val = val | (((bit & 2.Pow(subCounter + i)) == 2.Pow(subCounter + i)) ? 2.Pow(i) : 0);
                    }
                    enumvar.NetValue = val;
                    subCounter += enumvar.SubIndexLength;
                }
            }
        }

    private bool AllPackagesRecived()
        {
            return Datas != null && (Datas.Any(a => a.Item1 == 1) &&
                                     Datas.Any(a => a.Item1 == 2) &&
                                     Datas.Any(a => a.Item1 == 3) &&
                                     Datas.Any(a => a.Item1 == 4) &&
                                     Datas.Any(a => a.Item1 == 5));
        }

        private void UploadDone()
        {
            ShallReceiveData = false;
            CancelCanExecute = true;
            UploadCanExecute = true;
            if (!AllPackagesRecived())
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Tasks.Add(new Tuple<string, int>("Upload Failed.Wrong Packages.", -1));
                });
                AppStatics.FileHandler.GenerateLog(new[]
                {
                    " => Upload Failed.Wrong Packages." ,
                    "\t Title: " + Title,
                    "\t Description: " + Description
                });
                return;
            }
            var pack3 = new List<NetVariable>();
            // Real
            pack3.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex <= 10022 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            // Bool
            pack3.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20000 && a.MainIndex <= 20004 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            // Enum
            pack3.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30000 && a.MainIndex <= 30010 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

            PrepareDate(pack3, Datas.First(a => a.Item1 == 3).Item2);

            var pack1 = new List<NetVariable>();
            // Real
            pack1.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10023 && a.MainIndex <= 10067 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            // Bool
            pack1.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20005 && a.MainIndex <= 20010 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            // Enum
            pack1.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30011 && a.MainIndex <= 30014 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            
            PrepareDate(pack1, Datas.First(a => a.Item1 == 1).Item2);

            var pack2 = new List<NetVariable>();
            // Real
            pack2.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10068 && a.MainIndex <= 10110 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

            PrepareDate(pack2, Datas.First(a => a.Item1 == 2).Item2);

            var pack4 = new List<NetVariable>();
            // Real
            pack4.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10111 && a.MainIndex <= 10152 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            // Bool
            pack4.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20011 && a.MainIndex <= 20027 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
            // Enum
            pack4.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30015 && a.MainIndex <= 30017 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

            PrepareDate(pack4, Datas.First(a => a.Item1 == 4).Item2);

            var pack5 = new List<NetVariable>();
            // Real
            pack5.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10153 && a.MainIndex <= 10193 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

            PrepareDate(pack5, Datas.First(a => a.Item1 == 5).Item2);

            AppStatics.CurrentParamsChanged?.Invoke();

            App.Current.Dispatcher.Invoke(() =>
            {
                Tasks.Add(new Tuple<string, int>("Done.", 1));
            });
            AckTimer.Stop();
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
                prjName = "Upload_" + DateTime.Now.Ticks + ".Aul",
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
            AppStatics.FileHandler.GenerateLog(new[]
            {
                " => Upload Successfully.",
                "\t Title: " + Title,
                "\t Description: " + Description
            });

            var created = AppStatics.FileHandler.SaveUploadDataHandler(d);

        }
    }
}
