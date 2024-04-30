using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;

namespace AharHighLevel.Common
{
    public class ChartItem
    {
        public ChartItem()
        {
            Values =  new ChartValues<ObservableValue>();
        }
        public RealVariable Variable { get; set; }
        public Action VisibilityChanged { get; set; }
        public Action<ChartItem> CSDChanged { get; set; }
        public int SelectedRange { get; set; }
        private bool _visible;
        private int _csd { get; set; }
        public int CSD
        {
            get => _csd;
            set
            {
                if (_csd == value) return;
                _csd = value;
                CSDChanged?.Invoke(this);
            }
        }
        public DoubleCollection LineType { get; set; }
        public int LineStroke { get; set; }
        public NamedColor LineColor { get; set; }
        public bool Visible
        {
            get => _visible;
            set
            {
                if (_visible == value) return;
                _visible = value;
                VisibilityChanged?.Invoke();
            }
        }
        public ChartValues<ObservableValue> Values { get; set; }
    }
}
