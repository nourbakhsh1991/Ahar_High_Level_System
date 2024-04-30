using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AharHighLevel.Common
{
    public interface IDataProvider
    {
        XyValues GetHistoricalData();
        void SubscribeUpdates(Action<XyValues> onDataUpdated);
    }
    public struct XyValues
    {
        public IList<double> XValues;
        public IList<double> YValues;
    }
    public class DummyDataProvider : IDataProvider
    {
        private Random _random;
        private double _last;
        private readonly double _bias = 0.01;
        private int _i = 0;

        public DummyDataProvider(int seed)
        {
            _random = new Random(seed);
        }
        public XyValues GetHistoricalData()
        {
            const int initialDataCount = 1000;
            return GenerateRandomWalk(initialDataCount);

        }
        public XyValues GetHistoricalData(int seed)
        {
            const int initialDataCount = 1000;
            return GenerateRandomWalk(initialDataCount);
        }
        public void SubscribeUpdates(Action<XyValues> onDataUpdated)
        {
            // Don't do this in design mode! Or you will get an Out of memory exception in XAML Designer
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode) return;
            // Subcribes to updates and pushes to viewmodels
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += (s, e) =>
            {
                var xyValues = GenerateRandomWalk(10);
                onDataUpdated(xyValues);
            };
            timer.Start();
        }
        private XyValues GenerateRandomWalk(int count)
        {
            XyValues values = new XyValues()
            {
                XValues = new List<double>(),
                YValues = new List<double>(),
            };
            for (int i = 0; i < count; i++)
            {
                var sign = _random.NextDouble() > .5 ? 1 : -1;
                var val = (_random.NextDouble() - 0.5 + sign * _bias) * 5;
                double next = _last > 75 ? _last - Math.Abs(val) : (_last < -75 ? _last + Math.Abs(val) : _last + val);
                _last = next;
                values.XValues.Add(_i++);
                values.YValues.Add(next);
            }
            return values;
        }
    }
}
