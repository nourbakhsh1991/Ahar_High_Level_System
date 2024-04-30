using System.ComponentModel;
using System.Windows;
using AharHighLevel.Bootstrapper;
using AharHighLevel.EventAggregator;
using Prism.Events;
using System.Windows.Input;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using AharHighLevel.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using AharHighLevel.ViewModel.Modals;
using MaterialDesignThemes.Wpf;
using Prism.Interactivity.InteractionRequest;
using Application = System.Windows.Application;
using MessageBoxButtons = AharHighLevel.Common.MessageBoxButtons;

namespace AharHighLevel.ViewModel
{
    public class ShellViewModel : BaseViewModel
    {
        public ICommand Communication { get; internal set; }
        public ICommand LiveChartCommand { get; set; }
        public ICommand StartLiveTrendCommand { get; set; }
        public ICommand StopLiveTrendCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NewProjectCommand { get; set; }
        public ICommand OpenProjectCommand { get; set; }
        public ICommand CloseProjectCommand { get; set; }
        public ICommand SaveProjectCommand { get; set; }
        public ICommand SaveAsProjectCommand { get; set; }
        public ICommand EscKeyCommand { get; set; }
        public ICommand ExplorerPaneCommand { get; set; }
        public ICommand InformationBarCommand { get; set; }
        public ICommand OpenRecentCommand { get; set; }
        public ICommand SendDataCommand { get; set; }
        public ICommand ProjectInformationCommand { get; set; }
        public ICommand ConnectCommand { get; set; }
        public ICommand disconnectCommand { get; set; }
        public ICommand DownloadCommand { get; set; }
        public ICommand UploadCommand { get; set; }
        public ICommand CopyRamToRomCommand { get; set; }
        public ICommand AlarmEventCommand { get; set; }
        public ICommand ArchiveCommand { get; set; }
        public ICommand CompareSettingsCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public ICommand ChangeIpCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand PrintPageCommand { get; set; }
        public ICommand ResetFactoryCommand { get; set; }
        public ICommand RefreshLoadCommand { get; set; }
        public bool StartTrendVisibility { get; set; }
        public bool StopTrendVisibility { get; set; }
        public bool ChartObjectsVisibility { get; set; }
        public double MainScrollBarWidth
        {
            get { return 1563; }
        }
        public bool DelUplObjectsVisibility { get; set; }
        private BaseViewModel vmTemp;

        public InteractionRequest<INotification> CustomPopupRequest { get; set; }

        public object PopupContent { get; set; }

        public bool CopyRamToRomAlertVisibility
        {
            get
            {
                return AppStatics.FormSent;
            }
            set { AppStatics.FormSent = value; }
        }
        public Thickness RightBorderThickness { get; set; }
        public Visibility RightBorderVisibility { get; set; }
        public Visibility BottomGridVisibility { get; set; }
        public bool ExplorerPaneVisible { get; set; }
        public bool InformationBarVisible { get; set; }
        private bool _isCopyRamToRomActive;
        public bool IsDialogOpen { get; set; }
        public object DialogContent { get; set; }
        public List<string> RecentFiles { get; set; }
        //private NetworkMessenger _messenger;
        public string Title { get; set; }
        private bool _escKeyInProccess = false;
        public ShellViewModel()
        {
            this.Initialize();
        }
        private void Initialize()
        {

            Title = "Ahar High Level System";
            StartTrendVisibility = false;
            StopTrendVisibility = false;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var appStateEvent = eventAggregator.GetEvent<AppStateEventAggregator>();
            var viewRequestedEvent = eventAggregator.GetEvent<ViewRequestedEventAggregator>();
            var msgDataEa = eventAggregator.GetEvent<MessageBoxEa>();
            var FormsCommand = eventAggregator.GetEvent<FormsCommands>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            msgDataEa.Subscribe(MessageBoxDataHandler);
            sendEa.Subscribe(FormSendEaHandler);
            FormEa.Subscribe(FromEaDataHandler);
            FormsCommand.Subscribe(FormsCommandExecute);
            AckTimer.Elapsed += AckTimerOnElapsed;
            RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
            //_messenger = AppStatics.Container.Resolve<INetworkMessenger>() as NetworkMessenger;
            AppStatics.Messenger.PropertyChanged += MessengerOnPropertyChanged;
            viewRequestedEvent.Subscribe(ViewRequestedExe, true);
            appStateEvent.Subscribe(this.AppStateEventHandler, true);
            CustomPopupRequest = new InteractionRequest<INotification>();
            Communication = new RelayCommand(o =>
            {
                var nw = new NetworkSetting();
                PopupContent = nw;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                }, (notification) =>
                {

                });
                //nw.ShowDialog();

            }, o => true);
            LiveChartCommand = new RelayCommand(o =>
            {
                viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'LiveChart','RegionName':'MainRegion'}");

            }, o => true);
            // for gui sake


            StartLiveTrendCommand = new RelayCommand(StartLiveTrendExecute,(o => !AppStatics.ChartStarted && AppStatics.Messenger.IsConnected));
            StopLiveTrendCommand = new RelayCommand(StopLiveTrendExecute, (o => AppStatics.ChartStarted));
            ExitCommand = new RelayCommand(ExitCommandExecute);
            NewProjectCommand = new RelayCommand(NewProjectCommandExecute);
            OpenProjectCommand = new RelayCommand(OpenProjectCommandExecute);
            CloseProjectCommand = new RelayCommand(CloseProjectCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            SaveProjectCommand = new RelayCommand(SaveProjectCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            SaveAsProjectCommand = new RelayCommand(SaveAsProjectCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            EscKeyCommand = new RelayCommand(EscKeyCommandExecute);
            ExplorerPaneCommand = new RelayCommand(ExplorerPaneCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            InformationBarCommand = new RelayCommand(InformationBarCommandExecute);
            ConnectCommand = new RelayCommand(ConnectCommandExecute, CanConnectCommandExecute);
            disconnectCommand = new RelayCommand(DisconnectCommandExecute, CanDisconnectCommandExecute);
            UploadCommand = new RelayCommand(UploadCommandExecute, CanUploadCommandExecute);
            DownloadCommand = new RelayCommand(DownloadCommandExecute, CanDownloadCommandExecute);
            OpenRecentCommand = new RelayCommand(OpenRecentCommandExecute);
            ArchiveCommand = new RelayCommand(ArchiveCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            ProjectInformationCommand = new RelayCommand(ProjectInformationCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            SendDataCommand = new RelayCommand(SendDataCommandExecute,
                (obj) =>
                {
                    return AppStatics.IsProjectLoaded && AppStatics.Messenger.IsConnected && AppStatics.ActiveForm > 0;
                });
            CompareSettingsCommand = new RelayCommand(CompareSettingsCommandExecute,
                (obj) =>
                {
                    return AppStatics.IsProjectLoaded && AppStatics.Messenger.IsConnected && AppStatics.ActiveForm > 0;
                });
            ChangeIpCommand = new RelayCommand(ChangeIpCommandExecute, (obj) => { return AppStatics.IsProjectLoaded && AppStatics.Messenger.IsConnected; });
            HistoryCommand = new RelayCommand(HistoryCommandExecute, (obj) => { return AppStatics.IsProjectLoaded; });
            CopyRamToRomCommand = new RelayCommand(CopyRamToRomCommandExecute, (obj) => { return AppStatics.IsProjectLoaded && AppStatics.Messenger.IsConnected && !_isCopyRamToRomActive; });
            AlarmEventCommand = new RelayCommand(AlarmEventCommandExecute, o => AppStatics.Messenger.IsConnected);
            ChangePasswordCommand = new RelayCommand(ChangePasswordCommandExecute, (obj) => { return AppStatics.IsProjectLoaded && AppStatics.Messenger.IsConnected; });
            PrintPageCommand = new RelayCommand(PrintPageCommandExecute, (o) => { return AppStatics.IsProjectLoaded; });
            ResetFactoryCommand = new RelayCommand(ResetFactoryCommandExecute, (o) =>
            {
                return AppStatics.IsProjectLoaded;
            });
            RefreshLoadCommand = new RelayCommand(RefreshLoadCommandExecute, (obj) => { return AppStatics.IsProjectLoaded && AppStatics.Messenger.IsConnected; });
            if (RecentFiles.Count > 0)
                OpenRecentCommand.Execute(RecentFiles.First());
            //viewRequestedEvent.Publish("{'command':'ActivateView','ModuleName':'AppStateView','RegionName':'BottomRegion','IsActive':'true'}");
        }

        private void RefreshLoadCommandExecute(object obj)
        {
            try
            {
      
                if (AppStatics.ActiveForm <= 0) return;
                var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                var FormsCommand = eventAggregator.GetEvent<FormsCommands>();
                FormsCommand.Publish(AppCommands.FormLoadRefresh);
            }
            catch (Exception e)
            {

               
            }
        }

        public void SellClosing()
        {
            try
            {
                if (AppStatics.Messenger.IsConnected)
                {
                    AppStatics.Messenger.Disconnect();
                }

                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Closed.");
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch { }
        }

        private void ResetFactoryCommandExecute(object obj)
        {
            var view = new MessageBoxView()
            {
                DataContext = new MessageBoxViewModel("Are you sure?",
                    MessageBoxTypes.None, (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No, "Reset Factory", 400, 200)
            };
            PopupContent = view;
            var result = MessageBoxButtons.No;
            OnPropertyChanged(nameof(PopupContent));
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is CustomNotification custom && custom.Confirmed)
                    result = custom.Result;
            });
            if (result != MessageBoxButtons.Yes)
            {
                return;
            }
            var currentParams = AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex < 40000)
                .ToList();
            var defaultParams = ConfigParams.AllParams.Where(a => a.MainIndex >= 10000 && a.MainIndex < 40000)
                .ToList();
            foreach (var currentParam in currentParams)
            {
                if (currentParam is RealVariable param && defaultParams.First(a =>
                        a.FormId == currentParam.FormId && a.PacketIndex == currentParam.PacketIndex &&
                        a.Label == currentParam.Label) is RealVariable real)
                {

                    param.Value = real.Value;
                    param.Status = VariableStatus.Loaded;

                }
                if (currentParam is BoolVariable param1 && defaultParams.First(a =>
                        a.FormId == currentParam.FormId && a.PacketIndex == currentParam.PacketIndex &&
                        a.Label == currentParam.Label) is BoolVariable Bool)
                {
                    param1.Value = Bool.Value;
                    param1.Status = VariableStatus.Loaded;
                }
                if (currentParam is EnumVariable param2 && defaultParams.First(a =>
                        a.FormId == currentParam.FormId && a.PacketIndex == currentParam.PacketIndex &&
                        a.Label == currentParam.Label) is EnumVariable Enum)
                {
                    param2.Value = Enum.Value;
                    param2.Status = VariableStatus.Loaded;
                }
            }
            AppStatics.FileHandler.GenerateLog(new[] { " => Factory Reset Performed." });
            AppStatics.CurrentParamsChanged?.Invoke();
            view = new MessageBoxView()
            {
                DataContext = new MessageBoxViewModel("Successful.",
                    MessageBoxTypes.Ok, (int)MessageBoxButtons.Ok)
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


        private void PrintPageCommandExecute(object obj)
        {
            var np = new PrintPageView()
            {
                DataContext = new PrintPageViewModel() { PrintType = 0 }
            };
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.Cancel;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
        }

        private void ChangePasswordCommandExecute(object obj)
        {
            var np = new ChangePasswordView()
            {
                DataContext = new ChangePasswordViewModel()
            };
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.Cancel;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
        }

        private void ChangeIpCommandExecute(object obj)
        {
            var np = new ChangeAharIpView()
            {
                DataContext = new ChangeAharIpViewModel()
            };
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.Cancel;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
        }

        private void HistoryCommandExecute(object obj)
        {
            var np = new HistoryView()
            {
                DataContext = new HistoryViewModel()
            };
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.Cancel;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
        }

        private void CompareSettingsCommandExecute(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            commandEa.Publish(AppCommands.CompareSettings);
        }

        private void MessageBoxDataHandler(MessageBoxData obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormsCommand = eventAggregator.GetEvent<FormsCommands>();
            if (!obj.isResult)
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel(obj.Body, obj.Type, obj.Keys, obj.Title, obj.Id)
                };
                IsDialogOpen = true;
                DialogContent = view;
                OnPropertyChanged(nameof(IsDialogOpen));
                OnPropertyChanged(nameof(DialogContent));
            }
            else if (obj.isResult && obj.Result != MessageBoxButtons.Yes)
            {
                IsDialogOpen = false;
                DialogContent = null;
                OnPropertyChanged(nameof(IsDialogOpen));
                OnPropertyChanged(nameof(DialogContent));
            }

            if (obj.isResult && obj.Id == 10570 && obj.Result == MessageBoxButtons.Yes)
            {

                var loading = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Sending Request...", MessageBoxTypes.Loading, 0, "", 10571)
                };
                IsDialogOpen = true;
                DialogContent = loading;
                _isCopyRamToRomActive = true;
                var sendEa = eventAggregator.GetEvent<FormsSendEa>();
                AckTimer.Stop();
                AckTimer.Start();
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    sendEa.Publish(new NetworkPacket()
                    {
                        CSD = 57,
                        Destination = Devices.Ahar1,
                        PacketType = PacketTypes.Command,
                        Source = Devices.HighLevelSystem,
                        Data = null,
                        DataNumber = 0
                    });
                });
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Copy Ram To Rom Request Sent.");

                        sw.Flush();
                        sw.Close();
                    }
                }
                OnPropertyChanged(nameof(IsDialogOpen));
                OnPropertyChanged(nameof(DialogContent));
            }

            if (obj.isResult && obj.Result == MessageBoxButtons.Yes && obj.Id == 20000)
            {

                FormsCommand.Publish(AppCommands.Send);
            }
            if (!obj.isResult && obj.Id == 20001)
            {
                OnPropertyChanged(nameof(CopyRamToRomAlertVisibility));
            }

            if (obj.isResult && obj.Result == MessageBoxButtons.Yes && obj.Id == 20010)
            {

                FormsCommand.Publish(AppCommands.CancelEdit);
                _escKeyInProccess = false;

            }
        }

        private void AckTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isCopyRamToRomActive)
            {
                var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                var commandEa = eventAggregator.GetEvent<FormsCommands>();
                AckTimer.Stop();
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Copy Ram To Rom Failed.");
                        sw.Flush();
                        sw.Close();
                    }
                }
                var msgDataEa = eventAggregator.GetEvent<MessageBoxEa>();
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    vmTemp.FinishInteraction?.Invoke();
                    var fail = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Copy ram to rom process failed. \n timeout has occurred.",
                            MessageBoxTypes.Error,
                            (int)MessageBoxButtons.Ok,
                            "Copy Ram To Rom")
                    };
                    PopupContent = fail;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    });
                });

            }
        }

        private void FromEaDataHandler(NetworkPacket obj)
        {
            if (obj.PacketType == PacketTypes.Status && obj.CSD == 57 && _isCopyRamToRomActive)
            {
                AckTimer.Stop();
                App.Current.Dispatcher.Invoke(() =>
                {
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Copy ram to rom process has successfully done.",
                            MessageBoxTypes.Ok, (int)MessageBoxButtons.Ok)
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
                    if (AppStatics.IsProjectLoaded)
                    {
                        if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                        {
                            File.Create(AppStatics.projectFolder + "\\Log.txt");
                        }

                        using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                        {
                            sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Successful Copy Ram To Rom.");
                            sw.Flush();
                            sw.Close();
                        }
                    }
                    AppStatics.FormSent = false;
                    _isCopyRamToRomActive = false;
                    OnPropertyChanged(nameof(CopyRamToRomAlertVisibility));
                });

            }
        }

        private void FormSendEaHandler(NetworkPacket obj)
        {
            if (obj.CSD >= 1 && obj.CSD <= 36 && obj.PacketType == PacketTypes.Data)
            {
                AppStatics.FormSent = true;
                OnPropertyChanged(nameof(CopyRamToRomAlertVisibility));
            }
        }

        private async void CopyRamToRomCommandExecute(object obj)
        {


            var view = new MessageBoxView()
            {
                DataContext = new MessageBoxViewModel("Are you sure?",
                    MessageBoxTypes.None, (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No, "Copy Ram To Rom", 400, 200)
            };
            PopupContent = view;
            var result = MessageBoxButtons.No;
            OnPropertyChanged(nameof(PopupContent));
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is CustomNotification custom && custom.Confirmed)
                    result = custom.Result;
            });
            if (result != MessageBoxButtons.Yes)
            {
                return;
            }

            _isCopyRamToRomActive = true;
            AckTimer.Stop();
            AckTimer.Start();

            var sent = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 57,
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Command,
                Source = Devices.HighLevelSystem,
                Data = null,
                DataNumber = 0
            });
            if (sent)
            {
                vmTemp = new MessageBoxViewModel("Copy ram to rom procedure is underway…", MessageBoxTypes.Loading, 0, "");
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
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Copy Ram To Rom Request Sent.");
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            else
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Copy Ram To Rom")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
            }


            //var result = await DialogHost.Show(view, "RootDialog", (object sender, DialogClosingEventArgs args) =>
            //{
            //    if (args.Parameter is MessageBoxButtons.Yes)
            //    {
            //        args.Cancel();

            //        var loading = new MessageBoxView()
            //        {
            //            DataContext = new MessageBoxViewModel("Sending Request...", MessageBoxTypes.Loading, 0)
            //        };
            //        args.Session.UpdateContent(loading);
            //        Task.Delay(1000).ContinueWith((task) =>
            //        {
            //            Application.Current.Dispatcher.Invoke((Action)delegate
            //            {
            //                sendEa.Publish(new NetworkPacket()
            //                {
            //                    CSD = 57,
            //                    Destination = Devices.Ahar1,
            //                    PacketType = PacketTypes.Command,
            //                    Source = Devices.HighLevelSystem,
            //                    Data = null,
            //                    DataNumber = 0
            //                });
            //            });
            //            if (AppStatics.IsProjectLoaded)
            //            {
            //                if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
            //                {
            //                    File.Create(AppStatics.projectFolder + "\\Log.txt");
            //                }

            //                using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
            //                {
            //                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Copy Ram To Rom Request Sent.");
            //                }
            //            }
            //        });


            //    }
            //});
        }

        private void ArchiveCommandExecute(object obj)
        {
            var sfd = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Title = "Create a new project",
                Filter = "Ahar Archive (*.zip)|*.zip"
            };
            var hasFile = sfd.ShowDialog();
            if (hasFile == DialogResult.OK)
            {
                var filePath = sfd.FileName;
                System.IO.Compression.ZipFile.CreateFromDirectory(AppStatics.projectFolder, filePath);
            }
        }

        private void AlarmEventCommandExecute(object obj)
        {
            var view = new AlarmEventView();
            PopupContent = view;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.Cancel;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
            //view.ShowDialog();
        }

        private void ProjectInformationCommandExecute(object obj)
        {
            var view = new ProjectInformationModal();
            view.ShowDialog();
        }

        private void FormsCommandExecute(string obj)
        {
            var str = obj.Split('&');
            if (str == null || str.Length == 0) return;

            if (str[0] == AppCommands.StartLoading && str.Length > 1)
            {
                var view = new LoadingView(str[1]);
                //show the dialog
                var result = DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
            else if (str[0] == AppCommands.StartLoading && str.Length == 1)
            {
                var view = new LoadingView("");
                //show the dialog
                var result = DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
            else if (str[0] == AppCommands.EndLoading)
            {
                DialogHost.CloseDialogCommand.Execute(null, null);
            }
            else if (str[0] == AppCommands.CopyRamToRomToggle)
            {
                OnPropertyChanged(nameof(CopyRamToRomAlertVisibility));
            }
        }

        private async void SendDataCommandExecute(object arg)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormsCommand = eventAggregator.GetEvent<FormsCommands>();
            //var msgDataEa = eventAggregator.GetEvent<MessageBoxEa>();
            //msgDataEa.Publish(new MessageBoxData()
            //{
            //    Body = "Are you sure?",
            //    Type = MessageBoxTypes.None,
            //    Keys = (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No,
            //    Title = "Send",
            //    Id = 20000
            //});
            FormsCommand.Publish(AppCommands.Send);
            //var view = new MessageBoxView()
            //{
            //    DataContext = new MessageBoxViewModel("Are you sure?", MessageBoxTypes.None, (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No)
            //};
            //var result = await DialogHost.Show(view, "RootDialog", (object sender, DialogClosingEventArgs args) =>
            // {
            //     if (args.Parameter is MessageBoxButtons.Yes)
            //     {
            //         args.Cancel();

            //         var loading = new MessageBoxView()
            //         {
            //             DataContext = new MessageBoxViewModel("Sending Form...", MessageBoxTypes.Loading, 0)
            //         };
            //         args.Session.UpdateContent(loading);
            //         Task.Delay(1000).ContinueWith((task) =>
            //         {
            //             Application.Current.Dispatcher.Invoke((Action)delegate
            //            {
            //                FormsCommand.Publish(AppCommands.Send);
            //            });
            //         });


            //     }
            // });

        }
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {

        }
        private void OpenRecentCommandExecute(object arg)
        {



            // DialogHost.Show(new LoadingView("Test"));
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var LoadProjectEvent = eventAggregator.GetEvent<LoadProjectEventAggregator>();
            var folderPath = (string)arg;
            if (folderPath.EndsWith("\\"))
            {
                folderPath = folderPath.Substring(0, folderPath.Length - 1);
            }
            var prjName = "\\project.APrj";
            var paramName = "\\params.APrm";
            var history = "\\history\\";

            dynamic d = new
            {
                Status = ProjectDataStatus.Open,
                folderPath,
                prjName,
                paramName,
                history,
            };
            if (!Directory.Exists(folderPath))
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Folder Doesn't Exist.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
                {
                    Properties.Settings.Default.RecentFiles.Remove(folderPath);
                }
                Properties.Settings.Default.Save();
                RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
                OnPropertyChanged(nameof(RecentFiles));
                LoadProjectEvent.Publish(false);
                return;
            }

            if (!File.Exists(folderPath + prjName))
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Selected folder don't contain any project file.Please select different path.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
                {
                    Properties.Settings.Default.RecentFiles.Remove(folderPath);
                }
                Properties.Settings.Default.Save();
                RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
                OnPropertyChanged(nameof(RecentFiles));
                LoadProjectEvent.Publish(false);
                return;
            }
            AharProjectType created = AppStatics.FileHandler.OpenProjectDataHandler(d);
            if (created == null)
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Corrupted File Detected.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Wrong File", 350, 250)
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
                return;
            }
            AppStatics.NewProjectOpend();
            AppStatics.projectFolder = folderPath;
            AppStatics.Project = created;
            if (AppStatics.IsProjectLoaded)
            {
                Title = "Ahar High Level System  [" + AppStatics.projectFolder + "]";
                if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                {
                    File.Create(AppStatics.projectFolder + "\\Log.txt");
                }

                using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Opened.");
                    sw.Flush();
                    sw.Close();
                }
            }
            OnPropertyChanged(nameof(Title));
            AppStatics.FileOpened?.Invoke();
            if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
            {
                Properties.Settings.Default.RecentFiles.Remove(folderPath);
            }
            Properties.Settings.Default.RecentFiles.Insert(0, folderPath);
            Properties.Settings.Default.Save();
            RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
            OnPropertyChanged(nameof(RecentFiles));
            LoadProjectEvent.Publish(false);
            AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'true'}");

        }
        private bool CanDownloadCommandExecute(object arg)
        {
            return AppStatics.Messenger.IsConnected;
        }

        private void DownloadCommandExecute(object obj)
        {
            var np = new DownloadView();
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {

            });
            //np.ShowDialog();
            //if (AppStatics.IsProjectLoaded)
            //{
            //    Title += "[" + AppStatics.projectFolder + "]";
            //}
            //OnPropertyChanged(nameof(Title));
            //RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
            //OnPropertyChanged(nameof(RecentFiles));
        }

        private bool CanUploadCommandExecute(object arg)
        {
            return AppStatics.Messenger.IsConnected;
        }

        private void UploadCommandExecute(object obj)
        {
            var np = new UploadView();
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {

            });
        }

        private void MessengerOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "IsConnected")
            //{
            //    MessengerConnected = (bool)sender;
            //}
        }

        private bool CanDisconnectCommandExecute(object arg)
        {

            return AppStatics.Messenger.IsConnected;
        }

        private void DisconnectCommandExecute(object obj)
        {
            if (AppStatics.Messenger != null)
            {
                AppStatics.Messenger.Disconnect();
            }
        }
        private bool CanConnectCommandExecute(object arg)
        {
            return !AppStatics.Messenger.IsConnected && AppStatics.IsProjectLoaded;
        }

        private void ConnectCommandExecute(object obj)
        {
            var con = new NetworkSetting();

            PopupContent = con;
            OnPropertyChanged(nameof(PopupContent));
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {

            });
            //con.ShowDialog();
        }

        private void InformationBarCommandExecute(object obj)
        {
            if (InformationBarVisible)
            {
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'AppStateView','RegionName':'BottomRegion','IsActive':'true'}");
            }
            else
            {
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'AppStateView','RegionName':'BottomRegion','IsActive':'false'}");
            }
        }

        private void ExplorerPaneCommandExecute(object obj)
        {
            if (ExplorerPaneVisible)
            {
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'true'}");
                ExplorerPaneVisible = true;
            }
            else
            {
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'false'}");
                ExplorerPaneVisible = false;
            }
        }

        private async void EscKeyCommandExecute(object obj)
        {

            try
            {
                if (_escKeyInProccess) return;
                _escKeyInProccess = true;
                if (AppStatics.ActiveForm <= 0) return;
                var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                var FormsCommand = eventAggregator.GetEvent<FormsCommands>();
                var msgDataEa = eventAggregator.GetEvent<MessageBoxEa>();
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Are you sure you want to discard changes?",
                        MessageBoxTypes.None, (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No, "Esc Changes")
                };
                PopupContent = view;
                var result = MessageBoxButtons.No;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                }, (notification) =>
                {
                    if (notification is CustomNotification custom && custom.Confirmed)
                        result = custom.Result;
                });
                if (result != MessageBoxButtons.Yes)
                {
                    _escKeyInProccess = false;
                    return;
                }
                FormsCommand.Publish(AppCommands.CancelEdit);
                _escKeyInProccess = false;

            }
            catch (Exception e)
            {

                _escKeyInProccess = false;
            }

        }

        private void NewProjectCommandExecute(object obj)
        {
            if (!CheckCopyRamToRom()) return;
            if (!CheckSaveFile()) return;
            var np = new NewProjectModal()
            {
                DataContext = new NewProjectViewModel()
            };
            PopupContent = np;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.Cancel;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
            // np.ShowDialog();
            if (result != MessageBoxButtons.Ok) return;
            if (AppStatics.IsProjectLoaded)
            {
                Title = "Ahar High Level System [" + AppStatics.projectFolder + "]";
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'true'}");
                var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                var LoadProjectEvent = eventAggregator.GetEvent<LoadProjectEventAggregator>();
                LoadProjectEvent.Publish(false);
            }
            OnPropertyChanged(nameof(Title));
            RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
            OnPropertyChanged(nameof(RecentFiles));

        }
        private void OpenProjectCommandExecute(object obj)
        {
            if (!CheckCopyRamToRom()) return;
            if (!CheckSaveFile()) return;
            var ofd = new System.Windows.Forms.FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };
            var result = ofd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var folderPath = ofd.SelectedPath;
                if (folderPath.EndsWith("\\"))
                {
                    folderPath = folderPath.Substring(0, folderPath.Length - 1);
                }
                var prjName = "\\project.APrj";
                var paramName = "\\params.APrm";
                var history = "\\history\\";

                dynamic d = new
                {
                    Status = ProjectDataStatus.Open,
                    folderPath,
                    prjName,
                    paramName,
                    history,
                };
                if (!Directory.Exists(folderPath))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Folder Doesn't Exist.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                    return;
                }

                if (!File.Exists(folderPath + prjName))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Selected folder don't contain any project file.Please select different path.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                    return;
                }
                AharProjectType created = AppStatics.FileHandler.OpenProjectDataHandler(d);
                if (created == null)
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Corrupted File Detected.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Wrong File", 350, 250)
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
                    return;
                }
                AppStatics.NewProjectOpend();
                AppStatics.projectFolder = folderPath;
                AppStatics.Project = created;
                if (AppStatics.IsProjectLoaded)
                {
                    Title = "Ahar High Level System  [" + AppStatics.projectFolder + "]";
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Opened.");
                        sw.Flush();
                        sw.Close();
                    }
                }
                var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                var LoadProjectEvent = eventAggregator.GetEvent<LoadProjectEventAggregator>();
                LoadProjectEvent.Publish(false);
                OnPropertyChanged(nameof(Title));
                AppStatics.FileOpened?.Invoke();
                if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
                {
                    Properties.Settings.Default.RecentFiles.Remove(folderPath);
                }
                Properties.Settings.Default.RecentFiles.Insert(0, folderPath);
                Properties.Settings.Default.Save();
                RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
                OnPropertyChanged(nameof(RecentFiles));
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'true'}");
            }
        }
        private void CloseProjectCommandExecute(object obj)
        {
            if (!CheckCopyRamToRom()) return;
            if (!CheckSaveFile()) return;
            if (AppStatics.IsProjectLoaded)
            {
                var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                var LoadProjectEvent = eventAggregator.GetEvent<LoadProjectEventAggregator>();
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Closed.");
                        sw.Flush();
                        sw.Close();
                    }
                }
                LoadProjectEvent.Publish(false);
                AppStatics.ProjectClosed();
                Title = "Ahar High Level System";
                OnPropertyChanged(nameof(Title));
                AppStatics.Container.Resolve<IEventAggregator>().GetEvent<ViewRequestedEventAggregator>().Publish("{'command':'ActivateView','ModuleName':'LeftMenuView','RegionName':'RightRegion','IsActive':'false'}");
            }
        }
        private void SaveProjectCommandExecute(object obj)
        {
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
                folderPath,
                prjName,
                paramName,
                history,
                project = prj
            };
            if (!Directory.Exists(folderPath))
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Folder Doesn't Exist.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                return;
            }


            bool created = AppStatics.FileHandler.SaveProjectDataHandler(d);
            if (!created)
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Can not Save the Project.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Wrong File", 350, 250)
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
                return;
            }
            AppStatics.projectFolder = folderPath;
            AppStatics.IsProjectLoaded = true;
            AppStatics.ClearChangeForm();
            AppStatics.FileSaved?.Invoke();
            if (AppStatics.IsProjectLoaded)
            {
                Title = "Ahar High Level System [" + AppStatics.projectFolder + "]";
                if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                {
                    File.Create(AppStatics.projectFolder + "\\Log.txt");
                }

                using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Saved.");
                    sw.Flush();
                    sw.Close();
                }
            }
            OnPropertyChanged(nameof(Title));
            if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
            {
                Properties.Settings.Default.RecentFiles.Remove(folderPath);
            }
            Properties.Settings.Default.RecentFiles.Insert(0, folderPath);
            Properties.Settings.Default.Save();
            RecentFiles = AharHighLevel.Properties.Settings.Default.RecentFiles.Cast<string>().ToList();
            OnPropertyChanged(nameof(RecentFiles));

        }

        private void SaveAsProjectCommandExecute(object obj)
        {
            var ofd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var folderPath = ofd.SelectedPath;
                if (folderPath.EndsWith("\\"))
                {
                    folderPath = folderPath.Substring(0, folderPath.Length - 1);
                }

                var prjName = "\\project.APrj";
                var paramName = "\\params.APrm";
                var prjLog = "\\Log.txt";
                var history = "\\history\\";

                var prj = new AharProjectType()
                {
                    Description = AppStatics.Project.Description,
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
                    folderPath,
                    prjName,
                    paramName,
                    history,
                    project = prj
                };
                if (!Directory.Exists(folderPath))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Folder Doesn't Exist.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                    return;
                }

                if (File.Exists(folderPath + prjName) || File.Exists(folderPath + paramName))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Selected folder contains another project.Please select different path.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
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
                    return;
                }

                var created = AppStatics.FileHandler.SaveProjectAsDataHandler(d);
                if (!created)
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Can not Save the Project.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Wrong File", 350, 250)
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
                    return;
                }
                using (StreamWriter sw = File.CreateText(folderPath + prjLog))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Created.");
                    sw.WriteLine("\tProject Number: " + prj.ProjectNumber);
                    sw.WriteLine("\tProject Description:" + prj.Description);
                    sw.Flush();
                    sw.Close();
                }
                AppStatics.NewProjectOpend();
                AppStatics.projectFolder = folderPath;
                AppStatics.IsProjectLoaded = true;
                AppStatics.Project = prj;
                if (AppStatics.IsProjectLoaded)
                {
                    Title = "Ahar High Level System  [" + AppStatics.projectFolder + "]";
                }
                OnPropertyChanged(nameof(Title));
                if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
                {
                    Properties.Settings.Default.RecentFiles.Remove(folderPath);
                }

                Properties.Settings.Default.RecentFiles.Insert(0, folderPath);
                Properties.Settings.Default.Save();


            }
        }

        private void ExitCommandExecute(object obj)
        {
            if (obj is Window window)
            {
                if (!CheckCopyRamToRom()) return;
                if (!CheckSaveFile()) return;
                window.Close();
            }
        }

        private void StopLiveTrendExecute(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var fc = eventAggregator.GetEvent<FormsCommands>();
            fc.Publish("StopLiveTrend");
        }

        private void StartLiveTrendExecute(object obj)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var fc = eventAggregator.GetEvent<FormsCommands>();
            fc.Publish("StartLiveTrend");
        }

        private void ViewRequestedExe(string s)
        {
            dynamic command = JsonConvert.DeserializeObject(s);
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            if (command.command == "ActivateView")
            {
                try
                {
                    string module = command.ModuleName.ToString();
                    if (command.RegionName == "MainRegion")
                    {

                        Title = "Ahar High Level System - " + module;
                        if (AppStatics.IsProjectLoaded)
                        {
                            Title += "[" + AppStatics.projectFolder + "]";
                        }
                        OnPropertyChanged(nameof(Title));
                    }

                    bool IsActive = bool.Parse((string.IsNullOrEmpty(command.IsActive.ToString()) ? false : command.IsActive.ToString()));
                    switch (module)
                    {
                        case "LeftMenuView":
                            if (IsActive && AppStatics.IsProjectLoaded)
                            {
                                RightBorderThickness = new Thickness(0, 0, 1, 0);
                                RightBorderVisibility = Visibility.Visible;
                                ExplorerPaneVisible = true;

                            }
                            else
                            {
                                RightBorderThickness = new Thickness(0, 0, 0, 0);
                                RightBorderVisibility = Visibility.Collapsed;
                                ExplorerPaneVisible = false;
                            }
                            OnPropertyChanged(nameof(RightBorderThickness));
                            OnPropertyChanged(nameof(RightBorderVisibility));
                            OnPropertyChanged(nameof(ExplorerPaneVisible));
                            break;
                        case "AppStateView":
                            if (IsActive)
                            {
                                BottomGridVisibility = Visibility.Visible;
                                InformationBarVisible = true;

                            }
                            else
                            {
                                BottomGridVisibility = Visibility.Collapsed;
                                InformationBarVisible = false;
                            }
                            OnPropertyChanged(nameof(BottomGridVisibility));
                            OnPropertyChanged(nameof(InformationBarVisible));
                            break;
                    }
                }
                catch { }
            }
            if (command.command != "ActivateView") return;
            if (command.ModuleName.ToString() == "LiveChart" )
            {
                StartTrendVisibility = true;
                StopTrendVisibility = true;
            }
            else if (command.ModuleName.ToString() == "EndlessChart")
            {
                StartTrendVisibility = true;
                StopTrendVisibility = false;
            }
            else
            {
                StartTrendVisibility = false;
                StopTrendVisibility = false;
            }
            OnPropertyChanged(nameof(StartTrendVisibility));
            OnPropertyChanged(nameof(StopTrendVisibility));
        }

        private void AppStateEventHandler(AppState s)
        {

        }

        private bool CheckCopyRamToRom()
        {
            if (AppStatics.IsProjectLoaded)
            {
                if (AppStatics.FormSent)
                {
                    var confirm = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Data has been sent and no CopyRamToRom performed.start CopyRamToRom operation?",
                            MessageBoxTypes.None,
                            (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No | (int)MessageBoxButtons.Cancel,
                            "Copy Ram To Rom",
                            500,
                            200)
                    };
                    PopupContent = confirm;
                    OnPropertyChanged(nameof(PopupContent));
                    var result = MessageBoxButtons.Cancel;
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {
                        if (notification is ICustomNotification custom)
                            result = custom.Result;
                    });
                    switch (result)
                    {
                        case MessageBoxButtons.Cancel:
                            return false;
                        case MessageBoxButtons.No:
                            return true;
                        case MessageBoxButtons.Yes:
                            CopyRamToRomCommand.Execute(null);
                            return true;
                        default:
                            return false;
                    }
                }

            }

            return true;
        }
        private bool CheckSaveFile()
        {
            if (AppStatics.IsProjectLoaded)
            {
                if (AppStatics.ProjectChanged)
                {
                    var confirm = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Forms data has been changed.Save Project?",
                            MessageBoxTypes.None,
                            (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No | (int)MessageBoxButtons.Cancel,
                            "Save",
                            500,
                            200)
                    };
                    PopupContent = confirm;
                    OnPropertyChanged(nameof(PopupContent));
                    var result = MessageBoxButtons.Cancel;
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {
                        if (notification is ICustomNotification custom)
                            result = custom.Result;
                    });
                    switch (result)
                    {
                        case MessageBoxButtons.Cancel:
                            return false;
                        case MessageBoxButtons.No:
                            return true;
                        case MessageBoxButtons.Yes:
                            SaveProjectCommand.Execute(null);
                            return true;
                        default:
                            return false;
                    }
                }

            }

            return true;
        }

    }
}
