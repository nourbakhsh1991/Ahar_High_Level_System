using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using AharHighLevel.Common;
using AharHighLevel.ViewModel.MainModule;

namespace AharHighLevel.View.MainModule
{
    /// <summary>
    /// Interaction logic for OnlineChartView.xaml
    /// </summary>
    public partial class OnlineChartView : UserControl
    {


        public OnlineChartView()
        {

            InitializeComponent();
            DataContext = new OnlineChartViewModel();
            Loaded += (sender, args) =>
            {
                var vm = DataContext as OnlineChartViewModel;
                if (vm == null)
                    return;
                vm.Loaded();
            };
            Unloaded += (sender, args) =>
            {
                var vm = DataContext as OnlineChartViewModel;
                if (vm == null)
                    return;
                vm.Unloaded();
            };
        }





    }
}
