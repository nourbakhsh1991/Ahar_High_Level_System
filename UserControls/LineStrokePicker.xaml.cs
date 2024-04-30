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
    /// Interaction logic for LineStrokePicker.xaml
    /// </summary>
    public partial class LineStrokePicker : UserControl
    {
        public List<DoubleCollection> Dashes { get; set; }
        public LineStrokePicker()
        {
            InitializeComponent();
            DataContext = this;
            Dashes = new List<DoubleCollection>();

            Dashes.Add(new DoubleCollection());
            Dashes[0].Add(1);
            Dashes[0].Add(1);

            Dashes.Add(new DoubleCollection());
            Dashes[1].Add(1);
            Dashes[1].Add(5);

            Dashes.Add(new DoubleCollection());
            Dashes[2].Add(5);
            Dashes[2].Add(1);

            Dashes.Add(new DoubleCollection());
            Dashes[3].Add(.25);
            Dashes[3].Add(1);

            Dashes.Add(new DoubleCollection());
            Dashes[4].Add(1);
            Dashes[4].Add(2);
            Dashes[4].Add(4);

            Dashes.Add(new DoubleCollection());
            Dashes[5].Add(4);
            Dashes[5].Add(2);
            Dashes[5].Add(1);
        }
        public DoubleCollection SelectedDash
        {
            get => (DoubleCollection)GetValue(SelectedDashProperty);
            set => SetValue(SelectedDashProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDashProperty =
            DependencyProperty.Register("SelectedDash", typeof(DoubleCollection), typeof(LineStrokePicker), new UIPropertyMetadata(null));

    }
}
