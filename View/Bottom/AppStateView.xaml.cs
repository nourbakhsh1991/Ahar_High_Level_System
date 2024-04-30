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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AharHighLevel.ViewModel.Bottom;
using Microsoft.Practices.Unity;

namespace AharHighLevel.View.Bottom
{
    /// <summary>
    /// Interaction logic for AppStateView.xaml
    /// </summary>
    public partial class AppStateView : UserControl
    {
        public AppStateView()
        {
            InitializeComponent();
            DataContext = new AppStateViewModel();
        }
    }
}
