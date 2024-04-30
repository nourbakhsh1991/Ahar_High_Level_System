using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AharHighLevel.ViewModel.Modals;

namespace AharHighLevel.View.Modals
{
    /// <summary>
    /// Interaction logic for AlarmEventView.xaml
    /// </summary>
    public partial class AlarmEventView 
    {
        public AlarmEventView()
        {
            InitializeComponent();
            DataContext = new AlarmEventViewModel();
            Loaded += (sender, args) => { };
            Loaded += AlarmEventView_Loaded;
        }
        private void AlarmEventView_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as AlarmEventViewModel)?.Loaded();
            Window window = System.Windows.Window.GetWindow(this);
            window.Closing += window_Closing;
        }
        void window_Closing(object sender, global::System.ComponentModel.CancelEventArgs e)
        {
            if (DataContext is AlarmEventViewModel dlvm && dlvm.InProcess)
            {
                e.Cancel = true;
            }
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            System.Windows.Window.GetWindow((DependencyObject)sender).DragMove();
        }
    }
}
