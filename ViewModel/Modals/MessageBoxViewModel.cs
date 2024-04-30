using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using FirstFloor.ModernUI.Presentation;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;

namespace AharHighLevel.ViewModel.Modals
{
    public class MessageBoxViewModel : BaseViewModel
    {
        public MessageBoxTypes Type { get; set; }
        public string Message { get; set; }
        public int Buttons { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand YesCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public int Id { get; set; }
        public string Caption { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Finished { get; set; }


        public MessageBoxViewModel(string message, MessageBoxTypes type = MessageBoxTypes.None, int buttons = 1, string caption = "", int width=400,int height=300)
        {
            this.Initialize(message, type, buttons, caption,width, height);

            AckTimer.Interval = 100;
            AckTimer.Elapsed += AckTimer_Elapsed;
            AckTimer.Start();
        }

        private void AckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Finished)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    _notification.Confirmed = false;
                    FinishInteraction?.Invoke();
                    AckTimer.Stop();
                });
                
            }
        }

        ~MessageBoxViewModel()
        {

        }

        private void Initialize(string message, MessageBoxTypes type, int buttons, string caption = "", int width=400,int height = 300)
        {
            Message = message;
            Type = type;
            Buttons = buttons;
            Caption = caption;
            Width = width;
            Height = height;
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var msgDataEa = eventAggregator.GetEvent<MessageBoxEa>();
            _notification = new CustomNotification();
            OkCommand = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.Ok;
                _notification.Confirmed = true;
                FinishInteraction?.Invoke();
            });
            NoCommand = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.No;
                _notification.Confirmed = true;
                FinishInteraction?.Invoke();
            });
            YesCommand = new RelayCommand(o => {
                _notification.Result = MessageBoxButtons.Yes;
                _notification.Confirmed = true;
                FinishInteraction?.Invoke();
            });
            CancelCommand = new RelayCommand(o => {
                _notification.Result = MessageBoxButtons.Cancel;
                _notification.Confirmed = true;
                FinishInteraction?.Invoke();
            });
        }
    }
}
