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

namespace AharHighLevel.UserControls
{
    /// <summary>
    /// Interaction logic for StrokeThicknessPicker.xaml
    /// </summary>
    public partial class StrokeThicknessPicker : UserControl
    {
        public  List<double> Thicks { get; set; }
        public StrokeThicknessPicker()
        {
            InitializeComponent();
            DataContext = this;
            Thicks = new List<double>
            {
                1,
                2,
                3,
                4,
                5
            };
        }
        public double SelectedThickness
        {
            get => (double)GetValue(SelectedThicknessProperty);
            set => SetValue(SelectedThicknessProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedThicknessProperty =
            DependencyProperty.Register("SelectedThickness", typeof(double), typeof(StrokeThicknessPicker), new UIPropertyMetadata(null));


    }
}
