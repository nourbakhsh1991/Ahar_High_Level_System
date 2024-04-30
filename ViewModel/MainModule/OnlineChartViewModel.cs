using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.Network;
using AharHighLevel.View.Modals;
using AharHighLevel.ViewModel.Modals;
using FirstFloor.ModernUI.Presentation;
using LiveCharts.Geared;
using Prism.Events;
using SciChart.Charting.Common.Helpers;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChart.Core.Utility;
using Microsoft.Practices.Unity;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using MessageBoxButtons = AharHighLevel.Common.MessageBoxButtons;

namespace AharHighLevel.ViewModel.MainModule
{
    public class OnlineChartViewModel : BaseViewModel
    {
        private const int Id = -2;

        private BaseViewModel vmTemp;
        private readonly int WindowSize = 1000;
        private readonly IList<Color> _colors = new[]
        {
            Colors.White, Colors.Yellow, Color.FromArgb(255, 0, 128, 128), Color.FromArgb(255, 176, 196, 222),
            Color.FromArgb(255, 255, 182, 193), Colors.Purple, Color.FromArgb(255, 245, 222, 179),Color.FromArgb(255, 173, 216, 230),
            Color.FromArgb(255, 250, 128, 114), Color.FromArgb(255, 144, 238, 144), Colors.Orange, Color.FromArgb(255, 192, 192, 192),
            Color.FromArgb(255, 255, 99, 71), Color.FromArgb(255, 205, 133, 63), Color.FromArgb(255, 64, 224, 208), Color.FromArgb(255, 244, 164, 96)
        };
        private string _chartTitle = "";
        private string _xAxisTitle = "Time (ms)";
        private string _yAxisTitle = "Value (%)";
        private bool _enableZoom = true;
        private bool _enablePan;
        private ObservableCollection<LineRenderableSeriesViewModel> _renderableSeries;
        private ObservableCollection<IAxisViewModel> _yAxes = new ObservableCollection<IAxisViewModel>();
        public ObservableCollection<LineRenderableSeriesViewModel> RenderableSeries
        {
            get { return _renderableSeries; }
            set
            {
                _renderableSeries = value;
                OnPropertyChanged("RenderableSeries");
            }
        }
        public ObservableCollection<IAxisViewModel> YAxes { get { return _yAxes; } }
        public ScrollingViewportManager ViewPortManager { get; set; }
        public string ChartTitle
        {
            get { return _chartTitle; }
            set
            {
                _chartTitle = value;
                OnPropertyChanged("ChartTitle");
            }
        }
        public string XAxisTitle
        {
            get { return _xAxisTitle; }
            set
            {
                _xAxisTitle = value;
                OnPropertyChanged("XAxisTitle");
            }
        }
        public string YAxisTitle
        {
            get { return _yAxisTitle; }
            set
            {
                _yAxisTitle = value;
                OnPropertyChanged("YAxisTitle");
            }
        }
        public bool EnableZoom
        {
            get { return _enableZoom; }
            set
            {
                if (_enableZoom != value)
                {
                    _enableZoom = value;
                    OnPropertyChanged("EnableZoom");
                    if (_enableZoom) EnablePan = false;
                }
            }
        }
        public bool EnablePan
        {
            get { return _enablePan; }
            set
            {
                if (_enablePan != value)
                {
                    _enablePan = value;
                    OnPropertyChanged("EnablePan");
                    if (_enablePan) EnableZoom = false;
                }
            }
        }

        public List<dynamic> Names { get; set; }
        public ObservableCollection<ChartItem> Items { get; set; }
        public ObservableCollection<decimal> Mins { get; set; }
        public ObservableCollection<decimal> Maxs { get; set; }
        public bool IsReading { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand ExportDataCommand { get; set; }
        public int TotalCounter { get; set; }

        public List<NamedColor> NColors { get; set; }
        public List<string> Ranges { get; set; }

        public OnlineChartViewModel()
        {

            this.Initialize();
        }
        ~OnlineChartViewModel()
        {

        }

        private void Initialize()
        {
            ViewPortManager = new ScrollingViewportManager(WindowSize);
            AllParams = ConfigParams.TrendParams.Where(a => !a.IsReadOnly).ToList();
            AppStatics.ActiveForm = Id;
            AckTimer.Interval = 30000;
            AckTimer.Elapsed += AckTimerOnElapsed;
            Names = new List<dynamic>();
            foreach (var itm in AllParams)
            {
                Names.Add(new { Name = itm.Label, Value = itm.MainIndex });
            }
            ReadCommand = new RelayCommand(ReadCommandExecute);
            StopCommand = new RelayCommand(StopCommandExecute);
            ClearCommand = new RelayCommand(ClearCommandExecute);
            ExportDataCommand = new RelayCommand(ExportDataCommandExecute, o => !IsReading);
            NColors = new List<NamedColor>();
            AppStatics.Messenger.MessengerStatusChanged += MessengerStatusChanged;
            foreach (var color in _colors)
            {
                NColors.Add(new NamedColor()
                {
                    Name = color.ToString(),
                    Value = new SolidColorBrush(color)
                });
            }
            CreateChartAxis();
            Items = new ObservableCollection<ChartItem>();
            Mins = new ObservableCollection<decimal>();
            Maxs = new ObservableCollection<decimal>();
            for (int i = 0; i < 8; i++)
            {
                Items.Add(new ChartItem()
                {
                    CSD = AllParams[i].MainIndex,
                    Visible = false,
                    LineType = new DoubleCollection(),
                    LineStroke = 1,
                    LineColor = NColors[i],
                    VisibilityChanged = VisibilityChanged,
                    CSDChanged = CsdChanged,
                    Variable = AllParams[i] as RealVariable
                }
                );
                Mins.Add((AllParams[i] as RealVariable).Min);
                Maxs.Add((AllParams[i] as RealVariable).Max);
            }
            Ranges = new List<string>()
            {
                "   [0 , 100]",
                "   [0 , 200]",
                "   [-100 , 100]",
            };

            RenderableSeries = new ObservableCollection<LineRenderableSeriesViewModel>();
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var fc = eventAggregator.GetEvent<FormsCommands>();
            fc.Subscribe(FormsCommandsEA, true);
            var FormEa = eventAggregator.GetEvent<FormDataEA>();
            FormEa.Subscribe(FormEaHandler, true);
        }
        private void CreateChartAxis()
        {
            YAxes.Add(new NumericAxisViewModel()
            {
                AutoRange = AutoRange.Never,
                VisibleRange = new DoubleRange(0,100),
                AxisTitle = "Value [0 , 100] (%)",
                Id = "L1",
                AxisAlignment = AxisAlignment.Right,
            });
            YAxes.Add(new NumericAxisViewModel()
            {
                AutoRange = AutoRange.Never,
                VisibleRange = new DoubleRange(0, 200),
                AxisTitle = "Value [0 , 200] (%)",
                Id = "L2",
                AxisAlignment = AxisAlignment.Right,
            });
            YAxes.Add(new NumericAxisViewModel()
            {
                AutoRange = AutoRange.Never,
                VisibleRange = new DoubleRange(-100, 100),
                AxisTitle = "Value [-100 , 100] (%)",
                Id = "L3",
                AxisAlignment = AxisAlignment.Right,
            });
        }
        private void AckTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (IsReading)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    AckTimer.Stop();
                    //AppStatics.Messenger.Disconnect();
                    var vw = new MessageBoxViewModel("Connection Failed (Timeout).", MessageBoxTypes.Error, (int)MessageBoxButtons.Ok, "Connect", 300);
                    var view = new MessageBoxView()
                    {
                        DataContext = vw
                    };
                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Connection failed (timeout).");
                        sw.Flush();
                        sw.Close();
                    }
                    PopupContent = view;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {

                    });
                });

            }
        }
        private void CsdChanged(ChartItem itm)
        {
            itm.Variable = AllParams.First(a => a.MainIndex == itm.CSD) as RealVariable;
            var index = Items.IndexOf(itm);
            Mins[index] = itm.Variable.Min;
            Maxs[index] = itm.Variable.Max;
            OnPropertyChanged(nameof(Mins));
            OnPropertyChanged(nameof(Maxs));
        }
        private void VisibilityChanged()
        {
            if (IsReading) return;
            RenderableSeries = new ObservableCollection<LineRenderableSeriesViewModel>();
            var counter = 1;
            foreach (var chartItem in Items)
            {
                var str = "000000" + Convert.ToString(chartItem.CSD, 2);
                str = str.Substring(str.Length - 6);
                var lineData = new XyDataSeries<double, double>()
                {
                    SeriesName = chartItem.Variable.Label,
                    FifoCapacity = 90000,
                    
                };
                var chartId = "L" + (chartItem.SelectedRange + 1);
                if (chartItem.Visible)
                {
                    RenderableSeries.Add(new LineRenderableSeriesViewModel()
                    {
                        YAxisId = chartId,
                        StrokeThickness = chartItem.LineStroke,
                        Stroke = chartItem.LineColor.Value.Color,
                        DataSeries = lineData,
                        StyleKey = "LineSeriesStyle"
                    });
                }
            }
        }
        private void ExportDataCommandExecute(object obj)
        {
            var sfd = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Title = "Export",
                Filter = "CSV (*.csv)|*.csv"
            };
            var hasFile = sfd.ShowDialog();
            if (hasFile == DialogResult.OK)
            {
                var filePath = sfd.FileName;
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    if (RenderableSeries == null || RenderableSeries.Count == 0) return;
                    sw.Write("index,");
                    for (int i = 0; i < RenderableSeries.Count; i++)
                    {
                        sw.Write(RenderableSeries[i].DataSeries.SeriesName);
                        sw.Write(i != RenderableSeries.Count - 1 ? "," : "\r");
                    }

                    var lenData = RenderableSeries.Count > 0 ?
                        (RenderableSeries[0].DataSeries.ChangeCount < RenderableSeries[0].DataSeries.Count) ? RenderableSeries[0].DataSeries.ChangeCount : RenderableSeries[0].DataSeries.Count :
                        0;
                    for (int j = 0; j < lenData; j++)
                    {
                        sw.Write((j + 1) + ",");
                        for (int i = 0; i < RenderableSeries.Count; i++)
                        {
                            sw.Write((RenderableSeries[i].DataSeries as XyDataSeries<double, double>).YValues[j]);
                            sw.Write(i != RenderableSeries.Count - 1 ? "," : "\r");
                        }
                    }
                    sw.Flush();
                    sw.Close();

                }
            }


        }
        private void StopCommandExecute1(object obj)
        {
            IsReading = false;
            AppStatics.ChartStarted = false;
        }

        private void ClearCommandExecute(object obj)
        {
            foreach (var seriesView in RenderableSeries)
            {
                seriesView.DataSeries.Clear();
            }
            LastIndex = 0;
        }

        private int LastIndex = 0;
        private void ReadCommandExecute1(object obj)
        {
            if (IsReading) return;
            ClearCommandExecute(obj);
            IsReading = true;
            AppStatics.ChartStarted = true;
            Action readFromTread = () =>
            {
                while (IsReading)
                {
                    Thread.Sleep(1);

                    foreach (var seriesView in RenderableSeries)
                    {
                        var last = seriesView.DataSeries.LatestYValue;

                        var val = GenerateRandomWalk(5, (double?)last ?? 0, LastIndex);
                        (seriesView.DataSeries as XyDataSeries<double, double>).Append(val.XValues, val.YValues);
                    }

                    LastIndex++;
                }
            };

            Task.Factory.StartNew(readFromTread);
        }
        // TODO Net Request

        private void StopCommandExecute(object obj)
        {
            if (AppStatics.ActiveForm != Id) return;
            if (!IsReading) return;
            AppStatics.ChartStarted = false;
            if (!AppStatics.Messenger.IsConnected)
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Network is not connected. ",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Online chart")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
                return;
            }
            var data = new byte[16];
            var index = 0;
            for (int i = index; i < 16; i++)
            {
                data[i] = 0xFF;
            }
            AckTimer.Stop();
            AckTimer.Start();

            var sent = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 50,
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Command,
                Source = Devices.HighLevelSystem,
                Data = data.ToList(),
                DataNumber = 16
            });
            if (sent)
            {

                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Online Chart Request Ended.");
                        sw.Flush();
                        sw.Close();
                    }
                }
                IsReading = false;
            }
            else
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Online chart")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
            }
        }
        private void MessengerStatusChanged(bool obj)
        {
            if (!obj && IsReading && AppStatics.ActiveForm == Id)
            {
                AckTimer.Stop();
                IsReading = false;
                AppStatics.ChartStarted = false;
                if (vmTemp is MessageBoxViewModel vmbase)
                {
                    vmbase.Finished = true;
                }
            }

        }

        public void Loaded()
        {

            AppStatics.ActiveForm = Id;
        }
        public void Unloaded()
        {
            if (StopCommand.CanExecute(null))
                StopCommand.Execute(null);

        }
        // TODO Net Request
        private void ReadCommandExecute(object obj)
        {
            if (AppStatics.ActiveForm != Id) return;
            if (IsReading) return;
            if (!Items.Any(a => a.Visible))
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("At least one parameter must be selected.",
                        MessageBoxTypes.Warning,
                        (int)MessageBoxButtons.Ok,
                        "Online chart",
                        400,220)
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
                return;
            }
            AppStatics.ChartStarted = true;
            if (!AppStatics.Messenger.IsConnected)
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Network is not connected. ",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "Online chart")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
                return;
            }

            RenderableSeries = new ObservableCollection<LineRenderableSeriesViewModel>();
            var counter = 1;
            foreach (var chartItem in Items)
            {
                var str = "000000" + Convert.ToString(chartItem.CSD, 2);
                str = str.Substring(str.Length - 6);
                var lineData = new XyDataSeries<double, double>()
                {
                    SeriesName = chartItem.Variable.Label,
                    FifoCapacity = 90000,

                };
                var chartId = "L" + (chartItem.SelectedRange + 1);
                if (chartItem.Visible)
                {
                    RenderableSeries.Add(new LineRenderableSeriesViewModel()
                    {
                        YAxisId = chartId,
                        StrokeThickness = chartItem.LineStroke,
                        Stroke = chartItem.LineColor.Value.Color,
                        DataSeries = lineData,
                        StyleKey = "LineSeriesStyle"
                    });
                }
            }

            var data = new byte[16];
            var index = 0;
            foreach (var itm in Items)
            {
                if (itm.Visible)
                {
                    var value = (UInt16)(itm.CSD - 40000);
                    Array.Copy(BitConverter.GetBytes(value), 0, data, index, 2);
                    index += 2;
                }
            }

            for (int i = index; i < 16; i++)
            {
                data[i] = 0xFF;
            }
            AckTimer.Stop();
            AckTimer.Start();

            var sent = AppStatics.Messenger.SendData(new NetworkPacket()
            {
                CSD = 50,
                Destination = Devices.Ahar1,
                PacketType = PacketTypes.Command,
                Source = Devices.HighLevelSystem,
                Data = data.ToList(),
                DataNumber = 16
            });
            if (sent)
            {

                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Online Chart Request Sent.");
                        sw.Flush();
                        sw.Close();
                    }
                }

                TotalCounter = 0;
                IsReading = true;
            }
            else
            {
                var fail = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel("Process Failed.",
                        MessageBoxTypes.Error,
                        (int)MessageBoxButtons.Ok,
                        "fast chart")
                };
                PopupContent = fail;
                OnPropertyChanged(nameof(PopupContent));
                CustomPopupRequest.Raise(new CustomNotification()
                {
                    Title = "",
                    Content = "",
                });
                AppStatics.ChartStarted = false;
            }

        }

        private Random _random = new Random();
        private readonly double _bias = 0.01;
        // this fucntion is for Demo only
        private XyValues GenerateRandomWalk(int count, double _last, int _index)
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

                values.XValues.Add(_index);
                values.YValues.Add(next);
            }
            return values;
        }
        private void FormsCommandsEA(string obj)
        {
            if (obj == "StartLiveTrend")
            {
                ReadCommandExecute(null);
            }
            else if (obj == "StopLiveTrend")
            {
                StopCommandExecute(null);
            }
        }
        private void FormEaHandler(NetworkPacket obj)
        {
            if (AppStatics.ActiveForm != Id) return;
            if (obj.CSD == 50 && obj.PacketType == PacketTypes.Data && IsReading)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    //AckTimer.Stop();
                    //AckTimer.Start();
                    var index = 0;
                    var no = 0;
                    if (obj.Data.Count == 16)
                    {
                        var data = new byte[16];
                        var isFinished = true;
                        var tmpIndex = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            var value = (BitConverter.ToUInt16(obj.Data.ToArray(), tmpIndex));
                            if (value != 0xff)
                            {
                                isFinished = false;
                                break;
                            }
                            tmpIndex += 2;
                        }

                        if (isFinished)
                        {
                            AppStatics.ChartStarted = false;
                            AppStatics.FileHandler.GenerateLog(new[] { " => Online Chart Request Ended." });
                            IsReading = false;
                            return;
                        }
                    }
                    foreach (var itm in Items)
                    {
                        if (itm.Visible)
                        {
                            var count = BitConverter.ToInt32(obj.Data.ToArray(),index * 24);//  obj.Data[index * 21];
                            for (int i = 0; i < count/4; i++)
                            {
                                var val = BitConverter.ToSingle(obj.Data.ToArray(), (index * 24) + 4 + (i * 4));
                                (RenderableSeries[index].DataSeries as XyDataSeries<double, double>).Append(
                                    (TotalCounter + count) * 20, val);
                            }

                            no = count;
                            index++;
                        }
                    }

                    TotalCounter += no;

                });
            }
        }

    }
}
