using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using FirstFloor.ModernUI.Presentation;
using Prism.Events;
using Microsoft.Practices.Unity;

namespace AharHighLevel.ViewModel.Modals
{
    public class CompareSettingsViewModel : BaseViewModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ICommand Exit { get; set; }
        public ObservableCollection<CompareVariable> Parameters { get; set; }
        public CompareSettingsViewModel(List<NetVariable> param)
        {
            this.Initialize(param);


        }
        ~CompareSettingsViewModel()
        {

        }

        private void Initialize(List<NetVariable> param)
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            Width = 800;
            Height = 500;
            Exit = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.Cancel;
                _notification.Confirmed = false;
                FinishInteraction?.Invoke();
            });
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            Parameters = new ObservableCollection<CompareVariable>()
           {
               new CompareVariable(){Label = "Label", SavedValue = "Saved" , NetValue = "Ahar"}
           };
            foreach (var variable in param)
            {
                if (variable is RealVariable real)
                {
                    var saved = AppStatics.SaveParams.FirstOrDefault(a =>
                        (a is RealVariable real1) && real1.FormId == real.FormId && real1.Label == real.Label) as RealVariable;
                    if (saved == null || real.NetValue.ToString() == saved.Value)
                        continue;
                    Parameters.Add(new CompareVariable()
                    {
                        Label = real.Label,
                        NetValue = real.NetValue.ToString(),
                        SavedValue = saved.Value
                    });
                }
                else if (variable is EnumVariable Enum)
                {
                    var saved = AppStatics.SaveParams.FirstOrDefault(a =>
                        (a is EnumVariable Enum1) && Enum1.FormId == Enum.FormId && Enum1.Label == Enum.Label) as EnumVariable;
                    if (saved == null || Enum.NetValue == saved.Value)
                        continue;
                    Parameters.Add(new CompareVariable()
                    {
                        Label = Enum.Label,
                        NetValue = Enum.Items[Enum.NetValue],
                        SavedValue = saved.Items[saved.Value]
                    });
                }
                else if (variable is BoolVariable Bool)
                {
                    var saved = AppStatics.SaveParams.FirstOrDefault(a =>
                        (a is BoolVariable Bool1) && Bool1.FormId == Bool.FormId && Bool1.Label == Bool.Label) as BoolVariable;
                    if (saved == null || Bool.NetValue== saved.Value)
                        continue;
                    Parameters.Add(new CompareVariable()
                    {
                        Label = Bool.Label,
                        NetValue = Bool.NetValue.ToString(),
                        SavedValue = saved.Value.ToString()
                    });
                }
            }
        }
    }
}
