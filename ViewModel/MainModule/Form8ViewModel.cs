using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using AharHighLevel.ViewModel.Modals;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;

namespace AharHighLevel.ViewModel.MainModule
{
    class Form8ViewModel : BaseViewModel, IMouseEventHandler
    {
        private const int Id = 800;
        private List<short> __CSD = new List<short>() { 41, 40, 44, 43 };
        private int CSDIndex = 0;
    

        public EnumVariable Level1 { get; set; }
        public EnumVariable Level2 { get; set; }
        public Uint64Variable Status { get; set; }
        public ICommand SendForm8_1 { get; set; }
        public ICommand SendForm8_2 { get; set; }
        public decimal F0 { get; set; }
        public decimal F1 { get; set; }
        public bool InProcess { get; set; }

        private BaseViewModel vmTemp;
        public ICommand ErrorCommand { get; set; }
        private int _selectedTab;

        public int SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                if (_selectedTab == 0)
                {
                    CSDIndex = Level1.Value == 0 ? 0 : 1;
                }
                else
                {
                    CSDIndex = Level1.Value == 0 ? 2 : 3;
                }
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        private bool Form81Sent;

        public Form8ViewModel()
        {
            this.Initialize();
        }
        ~Form8ViewModel()
        {

        }
        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var FormEa = eventAggregator.GetEvent<FormDataEA>();

            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            ParameterDetailEa = eventAggregator.GetEvent<FormParameterDetailEa>();
            commandEa.Subscribe(CommandEaExecute, true);
            CustomPopupRequest = new InteractionRequest<INotification>();
            FormEa.Subscribe(this.FormEaHandler, true);
            AppStatics.FileSaved += FileSaved;
            AppStatics.Messenger.MessengerStatusChanged += MessengerStatusChanged;
            AckTimer.Elapsed += AckTimer_Elapsed;
            ErrorCommand = new RelayCommand(ErrorCommandExecute);
            SendForm8_1 = new RelayCommand(SendForm8_1Execute, o => { return AppStatics.Messenger.IsConnected; });
            SendForm8_2 = new RelayCommand(SendForm8_2Execute, o => { return AppStatics.Messenger.IsConnected && Form81Sent; });
            foreach (var prm in AppStatics.SaveParams.Where(a => a.FormId >= Id * 100 && a.FormId <= Id * 100 + 999))
            {
                if (prm is RealVariable param)
                {
                    AllParams.Add(new RealVariable()
                    {
                        Min = param.Min,
                        Max = param.Max,
                        HasMinMax = param.HasMinMax,
                        Resolution = param.Resolution,
                        IsReadOnly = param.IsReadOnly,
                        ReadOnly = param.IsReadOnly,
                        Unit = param.Unit,
                        CanChangeInRunMode = param.CanChangeInRunMode,
                        NetValue = decimal.Parse(param.Value ?? "0"),
                        Status = param.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init,
                        Label = param.Label,
                        PacketNumber = param.PacketNumber,
                        FormId = param.FormId,
                        PacketIndex = param.PacketIndex,
                    });
                }
                if (prm is BoolVariable param1)
                {
                    AllParams.Add(new BoolVariable()
                    {
                        IsReadOnly = param1.IsReadOnly,
                        Unit = param1.Unit,
                        ReadOnly = param1.IsReadOnly,
                        CanChangeInRunMode = param1.CanChangeInRunMode,
                        NetValue = param1.Value,
                        Status = param1.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init,
                        Label = param1.Label,
                        PacketNumber = param1.PacketNumber,
                        FormId = param1.FormId,
                        PacketIndex = param1.PacketIndex,
                        PacketSubIndex = param1.PacketSubIndex
                    });
                }
                if (prm is EnumVariable param2)
                {
                    AllParams.Add(new EnumVariable()
                    {
                        IsReadOnly = param2.IsReadOnly,
                        ReadOnly = param2.IsReadOnly,
                        Unit = param2.Unit,
                        CanChangeInRunMode = param2.CanChangeInRunMode,
                        Status = param2.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init,
                        Label = param2.Label,
                        PacketNumber = param2.PacketNumber,
                        NetValue = param2.Value,
                        FormId = param2.FormId,
                        PacketIndex = param2.PacketIndex,
                        PacketSubIndex = param2.PacketSubIndex,
                        SubIndexLength = param2.SubIndexLength,
                        Items = param2.Items.ToList()
                    });
                }
            }
            foreach (var itm in AllParams)
            {
                itm.Status = itm.IsValid
                    ? (itm.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init)
                    : VariableStatus.Wrong;
                switch (itm)
                {
                    case RealVariable real:
                        real.ValueChanged = TxtValueChanged;
                        break;
                    case BoolVariable Bool:
                        Bool.ValueChanged = TxtValueChanged;
                        break;
                    case EnumVariable Enum:
                        Enum.ValueChanged = EnumValueChanged;
                        break;
                }
                if (itm.PacketIndex + 4 > maxIndex)
                {
                    maxIndex = itm.PacketIndex + 4;
                }
            }
            foreach (var itm in AllParams.Where(a => a.FormId == 80112 || a.FormId == 80113))
            {
                itm.Status = VariableStatus.ReadOnly;
                itm.ReadOnly = true;

            }
            foreach (var itm in AllParams.Where(a => a.FormId == 80122 || a.FormId == 80123))
            {
                itm.Status = VariableStatus.ReadOnly;
                itm.ReadOnly = true;

            }
            Level1 = new EnumVariable()
            {
                IsReadOnly = false,
                ReadOnly = false,
                Unit = "",
                CanChangeInRunMode = true,
                ValueChanged = Level1Changed,
                Status = VariableStatus.Init,
                Label = "Level",
                NetValue = 0,
                Items = new List<string>() { "Low", "High" }
            };
            Level2 = new EnumVariable()
            {
                IsReadOnly = false,
                ReadOnly = true,
                Unit = "",
                CanChangeInRunMode = true,
                ValueChanged = Level2Changed,
                Status = VariableStatus.ReadOnly,
                Label = "Level",
                NetValue = 0,
                Items = new List<string>() { "Low", "High" }
            };
            Level2.Status = VariableStatus.ReadOnly;
            Status = new Uint64Variable()
            {
                Label = "Status",
                Value = 0,
                IsReadOnly = true,
                ValueChanged = StatusValueChanged
            };
     
           
        }
        private void MessengerStatusChanged(bool obj)
        {
            if (obj)
            {
                Loaded();
            }
        }
        private void ErrorCommandExecute(dynamic obj)
        {
            foreach (var itm in AllParams)
            {
                if (itm.Label == obj.Label.ToString())
                {
                    itm.IsValid = false;
                }
            }

            AppStatics.AddFaultForm(Id);
        }

        private void SendForm8_2Execute(object obj)
        {

            var confirm = new MessageBoxView()
            {
                DataContext = new MessageBoxViewModel("Are you sure?",
                    MessageBoxTypes.None,
                    (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No,
                    "Send",
                    400,
                    200)
            };
            PopupContent = confirm;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.No;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
            if (result != MessageBoxButtons.Yes) return;

            var SendResult = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = (short)(Level1.Value == 0 ? 7 : 6),
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Calibration,
                Source = Devices.HighLevelSystem,
                Data = null,
                DataNumber = 0
            });
            if (SendResult)
            {
                foreach (var itm in AllParams.Where(a => a.FormId == 80122 || a.FormId == 80123))
                {
                    if (itm is RealVariable real)
                    {
                        itm.ReadOnly = itm.IsReadOnly;
                        real.Value = real.Value;
                    }
                    else if (itm is EnumVariable Enum)
                    {
                        itm.ReadOnly = itm.IsReadOnly;
                        Enum.Value = Enum.Value;
                    }
                }

                Form81Sent = true;
                Level2.Status = VariableStatus.Init;
                Level2.ReadOnly = false;
                OnPropertyChanged("AllParams");
                OnPropertyChanged("Level2");
                var success = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Successfully Sent.",
                        MessageBoxTypes.Ok,
                        (int)MessageBoxButtons.Ok,
                        "Send")
                };
                PopupContent = success;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });

            }
            else
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Send")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
            }

            OnPropertyChanged("AllParams");
        }

        private void SendForm8_1Execute(object obj)
        {
 

            var confirm = new MessageBoxView()
            {
                DataContext = new MessageBoxViewModel("Are you sure?",
                    MessageBoxTypes.None,
                    (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No,
                    "Send",
                    400,
                    200)
            };
            PopupContent = confirm;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.No;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
            if (result != MessageBoxButtons.Yes) return;

            var SendResult = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = (short)(Level1.Value == 0 ? 4 : 3),
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Calibration,
                Source = Devices.HighLevelSystem,
                Data = null,
                DataNumber = 0
            });
            if (SendResult)
            {
                foreach (var itm in AllParams.Where(a => a.FormId == 80112 || a.FormId == 80113))
                {
                    if (itm is RealVariable real)
                    {
                        itm.ReadOnly = itm.IsReadOnly;
                        real.Value = real.Value;
                    }
                }

                Form81Sent = true;
                Level2.Status = VariableStatus.Init;
                Level2.ReadOnly = false;
                OnPropertyChanged("AllParams");
                OnPropertyChanged("Level2");
                var success = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Successfully Sent.",
                        MessageBoxTypes.Ok,
                        (int)MessageBoxButtons.Ok,
                        "Send")
                };
                PopupContent = success;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });

            }
            else
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Send")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
            }

            OnPropertyChanged("AllParams");
        }

        private void Level1Changed(object obj)
        {

        }
        private void Level2Changed(object obj)
        {

        }

        private void FileSaved()
        {
            foreach (var itm in AllParams)
            {
                itm.Status = itm.IsValid
                    ? (itm.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init)
                    : VariableStatus.Wrong;
            }
            OnPropertyChanged("AllParams");
        }
        private void CommandEaExecute(string str)
        {
            if (AppStatics.ActiveForm != Id) return;
            if (str == AppCommands.Send)
            {
                this.Send();
            }
            else if (str == AppCommands.FormLoadRefresh)
            {
                this.Loaded();
            }
            else if (str == AppCommands.CompareSettings)
            {
                var view = new CompareSettingsView(AllParams.Where(a =>
                    (SelectedTab == 0 && (a.FormId / 10) >= ((Id + 1) * 10) && (a.FormId / 10) <= ((Id + 1) * 10 + 9) && !a.IsReadOnly) ||
                    (SelectedTab == 1 && (a.FormId / 10) >= ((Id + 2) * 10) && (a.FormId / 10) <= ((Id + 2) * 10 + 9) && !a.IsReadOnly)).ToList());

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
            }
            if (str == AppCommands.CancelEdit)
            {
                foreach (var prm in AppStatics.SaveParams.Where(a => a.FormId >= Id * 100 && a.FormId <= Id * 100 + 999 && !a.IsReadOnly))
                {
                    if (prm is RealVariable param && AllParams.First(a =>
                            a.FormId == prm.FormId && a.PacketIndex == prm.PacketIndex &&
                            a.Label == prm.Label) is RealVariable real)
                    {
                        real.ValueChanged = null;
                        real.Value = param.Value;
                        real.Status = real.ReadOnly ? VariableStatus.ReadOnly : VariableStatus.Loaded;
                        real.ValueChanged = TxtValueChanged;

                    }
                    if (prm is BoolVariable param1 && AllParams.First(a =>
                            a.FormId == prm.FormId && a.PacketIndex == prm.PacketIndex &&
                            a.Label == prm.Label) is BoolVariable Bool)
                    {
                        Bool.ValueChanged = null;
                        Bool.Value = param1.Value;
                        Bool.Status = VariableStatus.Loaded;
                        Bool.ValueChanged = TxtValueChanged;
                    }
                    if (prm is EnumVariable param2 && AllParams.First(a =>
                            a.FormId == prm.FormId && a.PacketIndex == prm.PacketIndex &&
                            a.Label == prm.Label) is EnumVariable Enum)
                    {
                        Enum.ValueChanged = null;
                        Enum.Value = param2.Value;
                        Enum.Status = VariableStatus.Loaded;
                        Enum.ValueChanged = EnumValueChanged;
                    }
                }
                foreach (var itm in AllParams)
                {
                    itm.Status = itm.IsValid
                        ? (itm.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init)
                        : VariableStatus.Wrong;
                }
                OnPropertyChanged(nameof(AllParams));
                AppStatics.RemoveChangeForm(Id);
            }
        }

        public bool IsFormValid()
        {
            if (SelectedTab == 0)
                return AllParams.Where(a => ((a.FormId / 10) == 8011 && !a.IsReadOnly))
                    .Aggregate(true, (current, itm) => current && itm.IsValid);
            else
                return AllParams.Where(a => (a.FormId / 10) == 8012 && !a.IsReadOnly)
                    .Aggregate(true, (current, itm) => current && itm.IsValid);

        }

        public void Send()
        {
            if (!IsFormValid())
            {

                var nop = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Form Is Not Valid.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Form",
                        400,
                        200)
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
            var confirm = new MessageBoxView()
            {
                DataContext = new MessageBoxViewModel("Are you sure?",
                    MessageBoxTypes.None,
                    (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No,
                    "Send",
                    400,
                    200)
            };
            PopupContent = confirm;
            OnPropertyChanged(nameof(PopupContent));
            var result = MessageBoxButtons.No;
            CustomPopupRequest.Raise(new CustomNotification()
            {
                Title = "",
                Content = "",
            }, (notification) =>
            {
                if (notification is ICustomNotification custom)
                    result = custom.Result;
            });
            if (result != MessageBoxButtons.Yes) return;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            var data = new byte[maxIndex];
            var Items = SelectedTab == 0 ?
                (AllParams.Where(a => (a.FormId / 10) == 8011 && !a.IsReadOnly).OrderBy(a => a.PacketNumber)
                    .GroupBy(a => a.PacketIndex)) :
                (AllParams.Where(a => (a.FormId) == 80122 && !a.IsReadOnly).OrderBy(a => a.PacketNumber)
                    .GroupBy(a => a.PacketIndex));
            if(SelectedTab==1)
                data = new byte[8];
            foreach (var itms in Items)
            {
                foreach (var itm in itms)
                {
                    if (itms.Count() == 1 && itm is RealVariable real)
                    {
                        Array.Copy(BitConverter.GetBytes(float.Parse(real.Value)),
                            0, data, real.PacketIndex, 4);
                    }
                    else if (itm is BoolVariable boolVar)
                    {
                        var tmp = BitConverter.ToInt32(data, boolVar.PacketIndex);
                        tmp = (boolVar.Value ? (tmp | 2.Pow(boolVar.PacketSubIndex)) : tmp);
                        Array.Copy(BitConverter.GetBytes(tmp)
                            , 0, data, boolVar.PacketIndex, 4);
                    }
                    else if (itm is EnumVariable enumVar)
                    {
                        var tmp = BitConverter.ToInt32(data, enumVar.PacketIndex);
                        for (var i = 0; i < enumVar.SubIndexLength; i++)
                        {
                            tmp = ((enumVar.Value & 2.Pow(i)) > 0) ? (tmp | (2.Pow(i + enumVar.PacketSubIndex))) : tmp;
                        }
                        Array.Copy(BitConverter.GetBytes(tmp)
                            , 0, data, enumVar.PacketIndex, 4);
                    }
                }

            }

            var SendResult = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = __CSD[CSDIndex],
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Calibration,
                Source = Devices.HighLevelSystem,
                Data = new List<byte>(data),
                DataNumber = (byte)data.Length
            });
            if (SendResult)
            {
                InProcess = true;
                AckTimer.Start();
                vmTemp = new MessageBoxViewModel("Loading...", MessageBoxTypes.Loading, 0, "Form", 300);
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
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Send")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
            }

        }

        private void AckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
                    AppStatics.Messenger.Disconnect();
                    var vw = new MessageBoxViewModel("Send Final Data Failed.", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Form", 300);
                    AppStatics.FileHandler.GenerateLog(new[] { " => Connection failed (timeout)." });
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
                });

            }

        }

        public void MouseEnterCommand(object Sender, MouseEventArgs Args)
        {

            if (Sender is TextBox txtBox)
            {
                var item = AllParams.FirstOrDefault(a => a.Label == txtBox.Name);
                if (item == null || ParameterDetailEa == null) return;
                ParameterDetailEa.Publish(new Tuple<NetVariable, bool>(item, true));
            }
            else if (Sender is ComboBox cmbBox)
            {
                var item = AllParams.FirstOrDefault(a => a.Label == cmbBox.Name);
                if (item == null || ParameterDetailEa == null) return;
                ParameterDetailEa.Publish(new Tuple<NetVariable, bool>(item, true));
            }
        }

        public void MouseLeaveCommand(object Sender, MouseEventArgs Args)
        {
            if (Sender is TextBox txtBox)
            {
                var item = AllParams.FirstOrDefault(a => a.Label == txtBox.Name);
                if (item == null || ParameterDetailEa == null) return;
                ParameterDetailEa.Publish(new Tuple<NetVariable, bool>(item, false));
            }
            else if (Sender is ComboBox cmbBox)
            {
                var item = AllParams.FirstOrDefault(a => a.Label == cmbBox.Name);
                if (item == null || ParameterDetailEa == null) return;
                ParameterDetailEa.Publish(new Tuple<NetVariable, bool>(item, false));
            }
        }

        private void EnumValueChanged(object obj)
        {
            if (obj is EnumVariable Enum)
            {
                if (AppStatics.CurrentParams.FirstOrDefault(a => a.FormId == Enum.FormId
                                                                 && a.PacketNumber == Enum.PacketNumber
                                                                 && a.Label == Enum.Label) is EnumVariable param)
                    param.NetValue = Enum.Value;
                if (Enum.Label == "Select0" && Enum.Value == 1)
                {
                    var f0 = AllParams.FirstOrDefault(a => a.Label == "F0" && a.FormId == 80122) as RealVariable;
                    if (f0 != null)
                    {
                        F0 = decimal.Parse(f0.Value);
                        f0.Status = VariableStatus.ReadOnly;
                        f0.ReadOnly = true;
                    }

                  
                }
                else if (Enum.Label == "Select0" && Enum.Value == 0)
                {
                    var f0 = AllParams.FirstOrDefault(a => a.Label == "F0" && a.FormId == 80122) as RealVariable;
                    if (f0 != null)
                    {
                        f0.Status = VariableStatus.Init;
                        f0.ReadOnly = false;
                    }
                }
                if (Enum.Label == "Select1" && Enum.Value == 1)
                {
                    var f1 = AllParams.FirstOrDefault(a => a.Label == "F1" && a.FormId == 80122) as RealVariable;
                    if (f1 != null)
                    {
                        F1 = decimal.Parse(f1.Value);
                        f1.Status = VariableStatus.ReadOnly;
                        f1.ReadOnly = true;
                    }
                }
                else if(Enum.Label == "Select1" && Enum.Value == 0)
                {
                    var f1 = AllParams.FirstOrDefault(a => a.Label == "F1" && a.FormId == 80122) as RealVariable;
                    if (f1 != null)
                    {
                        f1.Status = VariableStatus.Init;
                        f1.ReadOnly = false;
                    }
                }

            }
            if (obj is EnumVariable Enum1 && Enum1.Status == VariableStatus.Changed)
            {
                AppStatics.AddChangeForm(Id);
            }

            if (IsFormValid())
            {
                AppStatics.RemoveFaultForm(Id);
            }
            OnPropertyChanged("AllParams");
        }
        private void StatusValueChanged()
        {
            foreach (var itm in AllParams)
            {
                // Run
                if (Status.Value == 3)
                    itm.ReadOnly = itm.IsReadOnly || !itm.CanChangeInRunMode;
                // Other Stats
                else
                    itm.ReadOnly = itm.IsReadOnly;
            }
        }
        public void Loaded()
        {
            AppStatics.ActiveForm = Id;
        }

        private void TxtValueChanged(object obj)
        {
            var select0 = AllParams.FirstOrDefault(a => a.Label == "Select0" && a.FormId == 80123) as EnumVariable;
            var select1 = AllParams.FirstOrDefault(a => a.Label == "Select1" && a.FormId == 80123) as EnumVariable;
            var f0 = AllParams.FirstOrDefault(a => a.Label == "F0" && a.FormId == 80122) as RealVariable;
            var f1 = AllParams.FirstOrDefault(a => a.Label == "F1" && a.FormId == 80122) as RealVariable;
            if (obj is RealVariable real)
            {
                if (f0 != null && select0 != null && real.Label == f0.Label && real.FormId == f0.FormId &&
                    select0.Value == 1 && real.IsValid && decimal.Parse(real.Value) != F0)
                {
                    real.Value = F0.ToString();
                    return;
                }
                if (f1 != null && select1 != null && real.Label == f1.Label && real.FormId == f1.FormId &&
                    select1.Value == 1 && real.IsValid && decimal.Parse(real.Value) != F1)
                {
                    real.Value = F1.ToString();
                    return;
                }
                var param = AppStatics.CurrentParams.FirstOrDefault(a => a.FormId == real.FormId
                                                                         && a.PacketNumber == real.PacketNumber
                                                                         && a.Label == real.Label) as RealVariable;
                var isDecimal = decimal.TryParse(real.Value, out decimal result);
                if (param != null && isDecimal)
                    param.NetValue = result;
                if (real.Label == "IFN" && real.FormId == 70121)
                {
                    EnumValueChanged(AllParams.FirstOrDefault(a => a.Label == "Range" && a.FormId == 70121));
                }

            }
            else if (obj is BoolVariable Bool)
            {
                if (AppStatics.CurrentParams.FirstOrDefault(a => a.FormId == Bool.FormId
                                                                 && a.PacketNumber == Bool.PacketNumber
                                                                 && a.Label == Bool.Label) is BoolVariable param)
                    param.NetValue = Bool.Value;

            }
            if (obj is NetVariable variable && variable.Status == VariableStatus.Changed)
            {
                AppStatics.AddChangeForm(Id);
            }

            if (IsFormValid())
            {
                AppStatics.RemoveFaultForm(Id);
            }
            OnPropertyChanged("AllParams");
        }


        public void FormEaHandler(NetworkPacket data)
        {
            if (AppStatics.ActiveForm != Id) return;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var formStatusEa = eventAggregator.GetEvent<FormStatusEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            if ((data.CSD == 20 || data.CSD == 21) && data.PacketType == PacketTypes.Calibration)
            {
                foreach (var itm in AllParams.Where(a => (a.FormId) == 80114).OrderBy(a => a.PacketNumber))
                {
                    if (itm is RealVariable real)
                    {
                        real.NetValue = (decimal)BitConverter.ToSingle(data.Data.ToArray(), itm.PacketIndex);
                        real.ReadOnly = real.IsReadOnly;
                        if (itm.PacketIndex + 4 > maxIndex && !itm.IsReadOnly)
                        {
                            maxIndex = itm.PacketIndex + 4;
                        }
                    }
                    else if (itm is BoolVariable boolvar)
                    {
                        var bit = BitConverter.ToInt32(data.Data.ToArray(), itm.PacketIndex);
                        boolvar.NetValue = (bit & 2.Pow(boolvar.PacketSubIndex)) == 2.Pow(boolvar.PacketSubIndex);
                        if (itm.PacketIndex + 4 > maxIndex && !itm.IsReadOnly)
                        {
                            maxIndex = itm.PacketIndex + 4;
                        }
                    }
                    else if (itm is EnumVariable enumvar)
                    {
                        var bit = BitConverter.ToInt32(data.Data.ToArray(), itm.PacketIndex);
                        var val = 0;
                        for (int i = 0; i < enumvar.SubIndexLength; i++)
                        {
                            val = val | (((bit & 2.Pow(enumvar.PacketSubIndex + i)) == 2.Pow(enumvar.PacketSubIndex + i)) ? 2.Pow(i) : 0);
                        }
                        enumvar.NetValue = val;
                        if (itm.PacketIndex + 4 > maxIndex && !itm.IsReadOnly)
                        {
                            maxIndex = itm.PacketIndex + 4;
                        }
                    }
                }
                Status.Value = data.Data.Last();
                formStatusEa.Publish((byte)Status.Value);
                OnPropertyChanged("Status");
                OnPropertyChanged("AllParams");
                commandEa.Publish(AppCommands.FormDataRefresh);
            }
            else if ((data.CSD == 23 || data.CSD == 24) && data.PacketType == PacketTypes.Calibration)
            {
                foreach (var itm in AllParams.Where(a => (a.FormId) == 80122).OrderBy(a => a.PacketNumber))
                {
                    if (itm is RealVariable real)
                    {
                        real.NetValue = (decimal)BitConverter.ToSingle(data.Data.ToArray(), itm.PacketIndex);
                        real.ReadOnly = real.IsReadOnly;
                        if (itm.PacketIndex + 4 > maxIndex && !itm.IsReadOnly)
                        {
                            maxIndex = itm.PacketIndex + 4;
                        }
                    }
                    else if (itm is BoolVariable boolvar)
                    {
                        var bit = BitConverter.ToInt32(data.Data.ToArray(), itm.PacketIndex);
                        boolvar.NetValue = (bit & 2.Pow(boolvar.PacketSubIndex)) == 2.Pow(boolvar.PacketSubIndex);
                        if (itm.PacketIndex + 4 > maxIndex && !itm.IsReadOnly)
                        {
                            maxIndex = itm.PacketIndex + 4;
                        }
                    }
                    else if (itm is EnumVariable enumvar)
                    {
                        var bit = BitConverter.ToInt32(data.Data.ToArray(), itm.PacketIndex);
                        var val = 0;
                        for (int i = 0; i < enumvar.SubIndexLength; i++)
                        {
                            val = val | (((bit & 2.Pow(enumvar.PacketSubIndex + i)) == 2.Pow(enumvar.PacketSubIndex + i)) ? 2.Pow(i) : 0);
                        }
                        enumvar.NetValue = val;
                        if (itm.PacketIndex + 4 > maxIndex && !itm.IsReadOnly)
                        {
                            maxIndex = itm.PacketIndex + 4;
                        }
                    }
                }
                Status.Value = data.Data.Last();
                formStatusEa.Publish((byte)Status.Value);
                OnPropertyChanged("Status");
                OnPropertyChanged("AllParams");
                commandEa.Publish(AppCommands.FormDataRefresh);
            }
            else if ((data.CSD == 52 || data.CSD == 53 || data.CSD == 55 || data.CSD == 56) && data.PacketType == PacketTypes.Calibration && InProcess && vmTemp != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {

                    AckTimer.Stop();
                    InProcess = false;
                    (vmTemp as MessageBoxViewModel).Finished = true;
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Successfully Sent.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok, "Form")
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
                    commandEa.Publish(AppCommands.FormDataRefresh);
                });
            }
        }
    }
}
