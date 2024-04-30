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
using AharHighLevel.Common;
using AharHighLevel.ViewModel.Modals;

namespace AharHighLevel.View.Modals
{
    /// <summary>
    /// Interaction logic for CompareSettingsView.xaml
    /// </summary>
    public partial class CompareSettingsView 
    {
        public CompareSettingsView(List<NetVariable> param)
        {
            InitializeComponent();
            DataContext = new CompareSettingsViewModel(param);
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            System.Windows.Window.GetWindow((DependencyObject)sender).DragMove();
        }
    }

}
