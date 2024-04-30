using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using MessageBox = System.Windows.MessageBox;
using MessageBoxButtons = AharHighLevel.Common.MessageBoxButtons;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace AharHighLevel.ViewModel.Modals
{
    class NewProjectViewModel : BaseViewModel, IInteractionRequestAware
    {
        public string FilePath { get; set; }
        public bool FileSelected { get; set; }
        public string EmployerName { get; set; }
        public string ProjectNum { get; set; }
        public string UnitNum { get; set; }
        public string UnitCap { get; set; }
        public DateTime SelectedDate { get; set; }
        public string Description { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public InteractionRequest<INotification> CustomPopupRequest { get; set; }

        public object PopupContent { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public NewProjectViewModel()
        {
            this.Initialize();
        }
        ~NewProjectViewModel()
        {

        }
        private void Initialize()
        {
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            SelectedDate = DateTime.Now;
            CreateCommand = new RelayCommand(CreateCommandExecute, CanExecuteCreateCommand);
            CloseCommand = new RelayCommand(CloseCommandExecute);
            Width = 400;
            Height = 400;
            _notification = new CustomNotification();
            CustomPopupRequest = new InteractionRequest<INotification>();
        }

        private void CloseCommandExecute(object obj)
        {
            //if (obj is Window wind)
            //{
            //    wind.Close();

            //}
            _notification.Result = MessageBoxButtons.Cancel;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();
        }

        private bool CanExecuteCreateCommand(object arg)
        {
            // && !string.IsNullOrEmpty(UnitNum) && !string.IsNullOrEmpty(UnitCap) && !string.IsNullOrEmpty(EmployerName)
            return !string.IsNullOrEmpty(ProjectNum) && ErrorCount == 0;
        }

        private void CreateCommandExecute(object obj)
        {

            var ofd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var folderPath = ofd.SelectedPath;
                if (folderPath.EndsWith("\\"))
                {
                    folderPath = folderPath.Substring(0, folderPath.Length - 1);
                }
                var prjName = "\\project.APrj";
                var prjLog = "\\Log.txt";
                var paramName = "\\params.APrm";
                var history = "\\history\\";

                var prj = new AharProjectType()
                {
                    Description = Description ?? "",
                    ProjectNumber = ProjectNum ?? "",
                    UnitNumber = UnitNum ?? "",
                    UnitCapacity = UnitCap ?? "",
                    EmployerName = EmployerName ?? "",
                    InstallationDate = SelectedDate.Ticks,
                    LastModify = DateTime.UtcNow.Ticks,
                    Device = Common.SystemInformation.GetDeviceInformation(),
                    Username = Common.SystemInformation.GetUserInformation(),

                };
                dynamic d = new
                {
                    Status = ProjectDataStatus.Create,
                    folderPath,
                    prjName,
                    paramName,
                    history,
                    project = prj
                };
                if (!Directory.Exists(folderPath))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Folder Doesn't Exist.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
                    };
                    PopupContent = view;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {

                    });
                    return;
                }

                if (File.Exists(folderPath + prjName) || File.Exists(folderPath + paramName))
                {
                    var view = new MessageBoxView()
                    {
                        DataContext = new MessageBoxViewModel("Selected folder contains another project.Please select different path.", MessageBoxTypes.Information, (int)MessageBoxButtons.Ok)
                    };
                    PopupContent = view;
                    OnPropertyChanged(nameof(PopupContent));
                    CustomPopupRequest.Raise(new CustomNotification()
                    {
                        Title = "",
                        Content = "",
                    }, (notification) =>
                    {

                    });
                    return;
                }

                var created = AppStatics.FileHandler.ProjectDataHandler(d);
                using (StreamWriter sw = File.CreateText(folderPath + prjLog))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Project Created.");
                    sw.WriteLine("\tProject Number: " + prj.ProjectNumber);
                    sw.WriteLine("\tProject Description:" + prj.Description);
                    sw.Flush();
                    sw.Close();
                }

                AppStatics.NewProjectOpend();
                AppStatics.projectFolder = folderPath;
                AppStatics.Project = prj;
                if (Properties.Settings.Default.RecentFiles.Contains(folderPath))
                {
                    Properties.Settings.Default.RecentFiles.Remove(folderPath);
                }
                Properties.Settings.Default.RecentFiles.Insert(0, folderPath);
                Properties.Settings.Default.Save();

                _notification.Result = MessageBoxButtons.Ok;
                _notification.Confirmed = true;
                FinishInteraction?.Invoke();
            }
        }

        private ICustomNotification _notification;

        public INotification Notification
        {
            get { return _notification; }
            set
            {
                _notification = value as ICustomNotification;
                OnPropertyChanged(nameof(Notification));
            }
        }
        public Action FinishInteraction { get; set; }
    }
}
