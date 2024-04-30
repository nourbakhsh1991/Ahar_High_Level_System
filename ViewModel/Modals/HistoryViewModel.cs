using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Unity;

namespace AharHighLevel.ViewModel.Modals
{
    public class HistoryViewModel : BaseViewModel
    {

        public int Width { get; set; }
        public int Height { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand ApplyCommand { get; set; }
        public bool HasRecord { get; set; }
        public ObservableCollection<HistoryVariable> HistoryCollection { get; set; }
        public HistoryViewModel()
        {
            this.Initialize();
        }
        ~HistoryViewModel()
        {

        }
        private void Initialize()
        {
            HistoryCollection = new ObservableCollection<HistoryVariable>();
            Width = 900;
            Height = 600;
            CloseCommand = new RelayCommand(CloseCommandExecute);
            PrintCommand = new RelayCommand(PrintCommandExecute);
            ApplyCommand = new RelayCommand(ApplyCommandExecute);
            if (Directory.Exists(AppStatics.projectFolder + "\\History"))
            {
                HasRecord = false;
                var files = Directory.GetFiles(AppStatics.projectFolder + "\\History");
                var history = new List<HistoryVariable>();
                foreach (var file in files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var parts = fileName.Split('_');
                    if (parts.Length != 2) continue;
                    var extention = Path.GetExtension(file);
                    var dateString = parts.Last();
                    if (!long.TryParse(dateString, out long date)) continue;
                  
                    if (extention.ToLower() == ".txt" && string.Equals(parts[0], "AlarmEvent", StringComparison.CurrentCultureIgnoreCase))
                    {

                        history.Add(new HistoryVariable()
                        {
                            Type = "AlarmEvent",
                            Project = AppStatics.Project,
                            Date = new DateTime(date),
                            Content = System.IO.File.ReadAllLines(file),
                            Title = "Alarms & Events",
                            Description = "Received At " + File.GetCreationTime(file)
                        });
                    }
                    else if (extention.ToLower() == ".adl" &&
                             string.Equals(parts[0], "Download", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var pack = new List<NetVariable>();
                        // Real
                        pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex <= 10193 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                        // Bool
                        pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20000 && a.MainIndex <= 20027 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                        // Enum
                        pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30000 && a.MainIndex <= 30017 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                        var hist = new HistoryVariable();

                        var prj = AppStatics.FileHandler.OpenDownloadDataHandler(hist, pack, file);
                        hist.Project = prj;
                        hist.Type = "Download";
                        hist.Date = new DateTime(date);
                        hist.Content = pack;
                        history.Add(hist);
                    }
                    else if (extention.ToLower() == ".aul" &&
                             string.Equals(parts[0], "Upload", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var pack = new List<NetVariable>();
                        // Real
                        pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex <= 10193 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                        // Bool
                        pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20000 && a.MainIndex <= 20027 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                        // Enum
                        pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30000 && a.MainIndex <= 30017 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                        var hist = new HistoryVariable();

                        var prj = AppStatics.FileHandler.OpenDownloadDataHandler(hist, pack, file);
                        hist.Project = prj;
                        hist.Type = "Upload";
                        hist.Date = new DateTime(date);
                        hist.Content = pack;
                        history.Add(hist);
                    }
                }

                HistoryCollection.AddRange(history);
            }
            else
            {
                HasRecord = true;
            }
        }

        private void ApplyCommandExecute(object obj)
        {
            if (obj is HistoryVariable hist)
            {
                if (hist.Content is List<NetVariable> data)
                {
                    var confirm = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Are you sure?",
                            MessageBoxTypes.None,
                            (int)MessageBoxButtons.Yes | (int)MessageBoxButtons.No,
                            "Send",
                            400,
                            200)
                    };
                    PopupContent = confirm;
                    OnPropertyChanged(nameof(PopupContent));
                    var result = MessageBoxButtons.No;
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {
                        if (notification is ICustomNotification custom)
                            result = custom.Result;
                    });
                    if (result != MessageBoxButtons.Yes) return;
                    foreach (var itm in data)
                    {
                        var curr = AppStatics.CurrentParams.FirstOrDefault(a =>
                            a.Label == itm.Label && a.FormId == itm.FormId && a.PacketNumber == itm.PacketNumber);
                        if (curr != null)
                        {
                            if (curr is RealVariable real && itm is RealVariable real1)
                            {
                                real.Value = real1.Value;
                            }
                            else if (curr is BoolVariable Bool && itm is BoolVariable Bool1)
                            {
                                Bool.Value = Bool1.Value;
                            }
                            else if (curr is EnumVariable Enum && itm is EnumVariable Enum1)
                            {
                                Enum.Value = Enum1.Value;
                            }
                        }
                    }
                    AppStatics.CurrentParamsChanged?.Invoke();
                }
            }
        }

        private void PrintCommandExecute(object obj)
        {
            if (obj is HistoryVariable hist)
            {
                if (hist.Content is List<NetVariable> data)
                {
                    var np = new PrintPageView()
                    {
                        DataContext = new PrintPageViewModel() { PrintType = 1, Data = data, Project = hist.Project}
                    };
                    PopupContent = np;
                    OnPropertyChanged(nameof(PopupContent));
                    var result = MessageBoxButtons.Cancel;
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {
                        if (notification is ICustomNotification custom)
                            result = custom.Result;
                    });
                }
                else if (hist.Content is string[] line)
                {
                    var np = new PrintPageView()
                    {
                        DataContext = new PrintPageViewModel() { PrintType = 2, Lines = line }
                    };
                    PopupContent = np;
                    OnPropertyChanged(nameof(PopupContent));
                    var result = MessageBoxButtons.Cancel;
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {
                        if (notification is ICustomNotification custom)
                            result = custom.Result;
                    });
                }
            }
           

        }

        private void CloseCommandExecute(object obj)
        {
            _notification.Result = MessageBoxButtons.Cancel;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }
    }
}
