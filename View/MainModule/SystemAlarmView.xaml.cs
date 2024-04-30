using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AharHighLevel.Common;
using AharHighLevel.Converters;
using AharHighLevel.ViewModel.MainModule;
using MaterialDesignThemes.Wpf;

namespace AharHighLevel.View.MainModule
{
    /// <summary>
    /// Interaction logic for SystemAlarmView.xaml
    /// </summary>
    public partial class SystemAlarmView : UserControl
    {
        public SystemAlarmView()
        {
            InitializeComponent();
            DataContext = new SystemAlarmViewModel();
            Loaded += (sender, args) =>
            {
                var vm = DataContext as SystemAlarmViewModel;
                if (vm == null)
                    return;
                vm.Loaded();
            };
            CreateForm();
        }

        private void CreateForm()
        {
            var vm = DataContext as SystemAlarmViewModel;
            if (vm == null)
                return;
            var ItmCounter = 0;
          
          
        }
    }
}
