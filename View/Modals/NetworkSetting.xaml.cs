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
using Microsoft.Practices.Unity;
using Microsoft.Win32;

namespace AharHighLevel.View.Modals
{
    /// <summary>
    /// Interaction logic for NetworkSetting.xaml
    /// </summary>
    public partial class NetworkSetting 
    {
        
        public NetworkSetting()
        {
            InitializeComponent();
            var nsvm = new NetworkSettingViewModel();
            TxtPassword.PasswordChanged += nsvm.PasswordChanged;
            DataContext = nsvm;
        }

       
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Window.GetWindow((DependencyObject)sender).DragMove();
        }
    }
}
