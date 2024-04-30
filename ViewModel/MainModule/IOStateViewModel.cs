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
    public class IOStateViewModel : BaseViewModel, IMouseEventHandler
    {

        private const int Id = 73;
        private const int __CSD = 35;
        public Uint64Variable Status { get; set; }

        public ICommand ErrorCommand { get; set; }


        public IOStateViewModel()
        {
            this.Initialize();
        }
        ~IOStateViewModel()
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
            AppStatics.CurrentParamsChanged += CurrentParamsChanged;
            AckTimer.Elapsed += AckTimer_Elapsed;
            AppStatics.Messenger.MessengerStatusChanged += MessengerStatusChanged;
            ErrorCommand = new RelayCommand(ErrorCommandExecute);
            foreach (var prm in AppStatics.SaveParams.Where(a => a.FormId >= Id * 10 && a.FormId <= Id * 10 + 9))
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
                 itm.Status = itm.IsValid ? (itm.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init) : VariableStatus.Wrong;
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
        private void CurrentParamsChanged()
        {
            foreach (var prm in AppStatics.CurrentParams.Where(a => a.FormId >= Id * 10 && a.FormId <= Id * 10 + 9 && !a.IsReadOnly))
            {
                if (prm is RealVariable param && AllParams.First(a =>
                        a.FormId == prm.FormId && a.PacketIndex == prm.PacketIndex &&
                        a.Label == prm.Label) is RealVariable real)
                {
                    real.ValueChanged = null;
                    real.Value = param.Value;
                    real.Status = VariableStatus.Loaded;
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
            AppStatics.AddChangeForm(Id);
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

        private void AckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {


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

        private void FileSaved()
        {
            foreach (var itm in AllParams)
            {
                 itm.Status = itm.IsValid ? (itm.IsReadOnly ? VariableStatus.ReadOnly : VariableStatus.Init) : VariableStatus.Wrong;
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
                var view = new CompareSettingsView(AllParams.Where(a => !a.IsReadOnly).ToList());

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
                foreach (var prm in AppStatics.SaveParams.Where(a => a.FormId >= Id * 10 && a.FormId <= Id * 10 + 9 && !a.IsReadOnly))
                {
                    if (prm is RealVariable param && AllParams.First(a =>
                            a.FormId == prm.FormId && a.PacketIndex == prm.PacketIndex &&
                            a.Label == prm.Label) is RealVariable real)
                    {
                        real.ValueChanged = null;
                        real.Value = param.Value;
                        real.Status = VariableStatus.Loaded;
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
                OnPropertyChanged(nameof(AllParams));
                AppStatics.RemoveChangeForm(Id);
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

        public void Loaded()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            AppStatics.ActiveForm = Id;
            var SendResult = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = __CSD,
                Destination = Devices.Ahar1,
                Source = Devices.HighLevelSystem,
                PacketType = PacketTypes.Command,
                DataNumber = 0,
                Data = null
            });
            if (SendResult)
            {
                AppStatics.FileHandler.GenerateLog(new[] { " => OpOm Data Requested." });
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
        private void TxtValueChanged(object obj)
        {
            if (obj is RealVariable real)
            {
                var param = AppStatics.CurrentParams.FirstOrDefault(a => a.FormId == real.FormId
                                                                         && a.PacketNumber == real.PacketNumber
                                                                         && a.Label == real.Label) as RealVariable;
                var isDecimal = decimal.TryParse(real.Value, out decimal result);
                if (param != null && isDecimal)
                    param.NetValue = result;

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
        public bool IsFormValid()
        {
            return AllParams.Aggregate(true, (current, itm) => current && itm.IsValid);
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
                        400)
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
            foreach (var itms in AllParams
                                                        .Where(a => !a.IsReadOnly)
                                                        .OrderBy(a => a.PacketNumber)
                                                        .GroupBy(a => a.PacketIndex))
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
                CSD = __CSD,
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Data,
                Source = Devices.HighLevelSystem,
                Data = new List<byte>(data),
                DataNumber = (byte)data.Length
            });
            if (SendResult)
            {
                AppStatics.FormSent = true;
                commandEa.Publish(AppCommands.CopyRamToRomToggle);
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
        }
        private void FormEaHandler(NetworkPacket data)
        {
            if (AppStatics.ActiveForm != Id) return;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var formStatusEa = eventAggregator.GetEvent<FormStatusEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            if (data.CSD == __CSD && data.PacketType == PacketTypes.Data)
            {
                foreach (var itm in AllParams.OrderBy(a => a.PacketNumber))
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
        }
    }
}
