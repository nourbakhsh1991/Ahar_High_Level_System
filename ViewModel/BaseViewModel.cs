using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Validation;
using Framework.ComponentModel;
using Microsoft.Practices.Unity;
using Prism.Interactivity.InteractionRequest;

namespace AharHighLevel.ViewModel
{
    public class BaseViewModel : ValidationErrorContainer, INotifyPropertyChanged, IInteractionRequestAware
    {
        protected Timer AckTimer = new Timer(AppStatics.AckTimeout);
        protected int maxIndex = 0;
        public InteractionRequest<INotification> CustomPopupRequest { get; set; } = new InteractionRequest<INotification>();

        public object PopupContent { get; set; }
        public FormParameterDetailEa ParameterDetailEa { get; set; }
        public List<NetVariable> AllParams { get; set; } = new List<NetVariable>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected ICustomNotification _notification;

        public INotification Notification
        {
            get { return _notification; }
            set
            {
                _notification = value as ICustomNotification;
                OnPropertyChanged(nameof(Notification));
            }
        }
        public Action FinishInteraction { get; set; }

    }
}
