using System.Windows.Media;
using SciChart.Charting.Model.DataSeries;

namespace AharHighLevel.ViewModel
{
    public class ChartDataViewModel:BaseViewModel
    {
        private readonly int _size;
        private Color _color;
        private IXyDataSeries<double, double> _channelDataSeries;

        public ChartDataViewModel(int size, Color color)
        {
            _size = size;
            Stroke = color;

            // Add an empty First In First Out series. When the data reaches capacity (int size) then old samples
            // will be pushed out of the series and new appended to the end. This gives the appearance of 
            // a scrolling chart window
            ChannelDataSeries = new XyDataSeries<double, double>() { FifoCapacity = _size };

            // Pre-fill with NaN up to size. This stops the stretching effect when Fifo series are filled with AutoRange
            for (int i = 0; i < _size; i++)
                ChannelDataSeries.Append(i, double.NaN);
        }

        public string ChannelName { get; set; }

        public Color Stroke
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Stroke");
            }
        }

        public IXyDataSeries<double, double> ChannelDataSeries
        {
            get { return _channelDataSeries; }
            set
            {
                _channelDataSeries = value;
                OnPropertyChanged("ChannelDataSeries");
            }
        }

        public void Reset()
        {
            _channelDataSeries.Clear();
        }
    }
}
