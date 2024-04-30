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
using AharHighLevel.ViewModel.MainModule;

namespace AharHighLevel.View.MainModule
{
    /// <summary>
    /// Interaction logic for FastChartView.xaml
    /// </summary>
    public partial class FastChartView : UserControl
    {
        public FastChartView()
        {
            InitializeComponent();
            DataContext = new FastChartViewModel();
            Loaded += (sender, args) =>
            {
                var vm = DataContext as FastChartViewModel;
                if (vm == null)
                    return;
                vm.Loaded();
            };
            Unloaded += (sender, args) =>
            {
                var vm = DataContext as FastChartViewModel;
                if (vm == null)
                    return;
                vm.Unloaded();
            };
        }
    }
}
