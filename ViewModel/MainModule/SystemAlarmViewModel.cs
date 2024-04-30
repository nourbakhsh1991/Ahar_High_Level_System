using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;

namespace AharHighLevel.ViewModel.MainModule
{
    public class SystemAlarmViewModel : BaseViewModel
    {
        private const int Id = 74;
        public new List<AlarmEventVariable> AllParams { get; set; } = new List<AlarmEventVariable>();
        public List<AlarmEventVariable> AlarmSystem { get; set; }
        public List<AlarmEventVariable> AlarmInternal { get; set; }
        public List<AlarmEventVariable> FaultsSystem { get; set; }
        public List<AlarmEventVariable> FaultsInternal { get; set; }
        public SystemAlarmViewModel()
        {
            this.Initialize();
        }

        ~SystemAlarmViewModel()
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
            AlarmSystem = new List<AlarmEventVariable>();
            AlarmInternal = new List<AlarmEventVariable>();
            FaultsSystem = new List<AlarmEventVariable>();
            FaultsInternal = new List<AlarmEventVariable>();
            AppStatics.Messenger.MessengerStatusChanged += MessengerStatusChanged;
            FormEa.Subscribe(this.FormEaHandler, true);

            foreach (var al in ConfigParams.AllAlarmEvents.Where(a => a.Type == 1 | a.Type == 4))
            {
                AllParams.Add(new AlarmEventVariable()
                {
                    Type = al.Type,
                    Time = al.Time,
                    Message = al != null ? al.Message : "",
                    Code = al.Code,
                    IsActive = false,
                    IsInternal = al != null ? al.IsInternal : false
                });
            }

            foreach (var al in ConfigParams.AllAlarmEvents.Where(a => a.Type == 2 | a.Type == 5))
            {
                AllParams.Add(new AlarmEventVariable()
                {
                    Type = al.Type,
                    Time = al.Time,
                    Message = al != null ? al.Message : "",
                    Code = al.Code,
                    IsActive = false,
                    IsInternal = al != null ? al.IsInternal : false
                });
            }


            for (int i = 0; i < AllParams.Count; i++)
            {
                AllParams[i].IsActive = false;
                if (AllParams[i].IsInternal && AllParams[i].Type == 1)
                {
                    AlarmInternal.Add(AllParams[i]);
                }
                else if (AllParams[i].IsInternal && AllParams[i].Type == 2)
                {
                    FaultsInternal.Add(AllParams[i]);
                }
                else if (!AllParams[i].IsInternal && AllParams[i].Type == 1)
                {
                    AlarmSystem.Add(AllParams[i]);
                }
                else if (!AllParams[i].IsInternal && AllParams[i].Type == 2)
                {
                    FaultsSystem.Add(AllParams[i]);
                }
            }
        }
        private void MessengerStatusChanged(bool obj)
        {
            if (obj)
            {
                Loaded();
            }
        }
        public void Loaded()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            AppStatics.ActiveForm = Id;
            sendEa.Publish(new NetworkPacket()
            {
                CSD = 36,
                Destination = Devices.Ahar1,
                Source = Devices.HighLevelSystem,
                PacketType = PacketTypes.Command,
                DataNumber = 0,
                Data = null
            });
            if (AppStatics.IsProjectLoaded)
            {
                if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                {
                    File.Create(AppStatics.projectFolder + "\\Log.txt");
                }

                using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => System Alarm Data Requested.");
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private void CommandEaExecute(string str)
        {
            if (AppStatics.ActiveForm != Id) return;

            else if (str == AppCommands.FormLoadRefresh)
            {
                this.Loaded();
            }
        }
        public void FormEaHandler(NetworkPacket data)
        {
            if (AppStatics.ActiveForm != Id) return;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var formStatusEa = eventAggregator.GetEvent<FormStatusEa>();
            var commandEa = eventAggregator.GetEvent<FormsCommands>();
            var index = 0;
            int j = 0;
            if (data.CSD == 36 && data.PacketType == PacketTypes.Data)
            {
                AlarmSystem = new List<AlarmEventVariable>();
                AlarmInternal = new List<AlarmEventVariable>();
                FaultsSystem = new List<AlarmEventVariable>();
                FaultsInternal = new List<AlarmEventVariable>();
                var alarm_1 = BitConverter.ToInt64(data.Data.ToArray(), 0);
                var alarm_2 = BitConverter.ToInt64(data.Data.ToArray(), 8);
                var fault_1 = BitConverter.ToInt64(data.Data.ToArray(), 16);
                var fault_2 = BitConverter.ToInt64(data.Data.ToArray(), 24);

                for (int i = 0; i < AllParams.Count; i++)
                {
                    ////chechout the activity
                    if (i < 63)
                    {
                        AllParams[i].IsActive = (alarm_1 & (long)Math.Pow(2, i)) > 0;
                    }
                    if (i == 63)
                    {
                        AllParams[i].IsActive = (alarm_1 & (long)Math.Pow(2, i) -1) > 0;
                    }
                    else if (i < 94)
                    {
                        AllParams[i].IsActive = (alarm_2 & (long)Math.Pow(2, i % 64)) > 0;
                    }
                }

                for (int i = 0; i < AllParams.Count; i++)
                {

                ////chechout the activity
                    if (i < 63)
                    {
                        AllParams[i+94].IsActive = (fault_1 & (long)Math.Pow(2, i)) > 0;
                    }
                    if (i == 63)
                    {
                        AllParams[i].IsActive = (fault_1 & (long)Math.Pow(2, i) -1) > 0;
                    }
                    else if (i < 94)
                    {
                        AllParams[i+94].IsActive = (fault_2 & (long)Math.Pow(2, i % 64)) > 0;
                    }
                }

                for (int i = 0; i < AllParams.Count; i++)
                {
                    if (AllParams[i].IsInternal && AllParams[i].Type == 1)
                    {
                        AlarmInternal.Add(AllParams[i]);
                    }
                    else if (AllParams[i].IsInternal && AllParams[i].Type == 2)
                    {
                        FaultsInternal.Add(AllParams[i]);
                    }
                    else if (!AllParams[i].IsInternal && AllParams[i].Type == 1)
                    {
                        AlarmSystem.Add(AllParams[i]);
                    }
                    else if (!AllParams[i].IsInternal && AllParams[i].Type == 2)
                    {
                        FaultsSystem.Add(AllParams[i]);
                    }
                }

                ////////////////////////
                ///set param in alarm or fault list
                ///
                //    if (AllParams[i].IsInternal && AllParams[i].Type == 1)
                //    {
                //        AlarmInternal.Add(AllParams[i]);
                //    }
                //    else if (!AllParams[i].IsInternal && AllParams[i].Type == 1)
                //    {
                //        AlarmSystem.Add(AllParams[i]);
                //    }
                //    else if (AllParams[i].IsInternal && AllParams[i].Type == 2)
                //    {
                //        FaultsInternal.Add(AllParams[i]);
                //    }
                //    else if (!AllParams[i].IsInternal && AllParams[i].Type == 2)
                //    {
                //        FaultsSystem.Add(AllParams[i]);
                //    }
                //}

            commandEa.Publish(AppCommands.FormDataRefresh);
            OnPropertyChanged("AlarmInternal");
            OnPropertyChanged("FaultsInternal");
            OnPropertyChanged("AlarmSystem");
            OnPropertyChanged("FaultsSystem");
            }

        }
    }
}
