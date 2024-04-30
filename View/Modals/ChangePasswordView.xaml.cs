using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AharHighLevel.ViewModel.Modals;

namespace AharHighLevel.View.Modals
{
    /// <summary>
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : UserControl
    {
        public ChangePasswordView()
        {
            InitializeComponent();
            DataContext = new ChangePasswordViewModel();
            Loaded += ChangeAharPasswordView_Loaded;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ChangeAharPasswordView_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = System.Windows.Window.GetWindow(this);
            window.Closing += window_Closing;
        }
        void window_Closing(object sender, global::System.ComponentModel.CancelEventArgs e)
        {
            if (DataContext is ChangePasswordViewModel dlvm && dlvm.InProcess)
            {
                e.Cancel = true;
            }
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null && DataContext is ChangePasswordViewModel vm)
            {
                vm.SetPasswords(TxtOld.Password, TxtNew.Password);
            }
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Window.GetWindow((DependencyObject)sender).DragMove();
        }
    }
}
