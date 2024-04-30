using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using AharHighLevel.Common;
using AharHighLevel.View.Modals;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Win32;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace AharHighLevel.ViewModel.Modals
{
    public class PrintPageViewModel : BaseViewModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ICommand Exit { get; set; }
        public ICommand SelectPathCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public int PrintType { get; set; }
        public string[] Lines { get; set; }
        public List<NetVariable> Data { get; set; }
        public AharProjectType Project { get; set; }
        public string Path { get; set; }

        public string CurrentVersion =>
            ApplicationDeployment.IsNetworkDeployed
                ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                : Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public PrintPageViewModel()
        {
            this.Initialize();
        }
        ~PrintPageViewModel()
        {

        }

        private void Initialize()
        {
            Width = 400;
            Height = 250;
            Exit = new RelayCommand(o =>
            {
                _notification.Result = MessageBoxButtons.Cancel;
                _notification.Confirmed = false;
                FinishInteraction?.Invoke();
            }, o => true);
            SelectPathCommand = new RelayCommand(SelectPathCommandExecute);
            PrintCommand = new RelayCommand(PrintCommandExecute);
            
        }

        private void PrintCommandExecute(object obj)
        {
            if (Directory.Exists(System.IO.Path.GetDirectoryName(Path)))
            {
                if (Project==null)
                {
                    Project = AppStatics.Project;
                }
                if (PrintType == 0)
                {
                    Print(AppStatics.Project, AppStatics.CurrentParams.Where(a => a.MainIndex > 0).ToList());
                }
                else if (PrintType == 1)
                {
                    Print(AppStatics.Project, Data);
                }
                else if (PrintType == 2)
                {
                    PrintLine(AppStatics.Project, Lines);
                }

            }
            
        }

        private void SelectPathCommandExecute(object obj)
        {
            var sfd = new SaveFileDialog
            {
                InitialDirectory = @"C:\", Filter = "Pdf file (*.pdf)|*.pdf", CheckPathExists = true
            };
            var res = sfd.ShowDialog();
            if (!res.HasValue || !res.Value) return;
            Path = sfd.FileName;
            OnPropertyChanged(nameof(Path));
        }

        public bool Print(AharProjectType prj, List<NetVariable> paramList)
        {
            try
            {
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "My First PDF";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont h1 = new XFont("SF UI Display", 20, XFontStyle.Bold);
                XFont h2 = new XFont("SF UI Display", 16, XFontStyle.BoldItalic);
                XFont h3 = new XFont("SF UI Display", 12, XFontStyle.Regular);
                var bitmap = new BitmapImage(new Uri("pack://application:,,,/Resources/Favicon.png"));
                var top = 10;
                var headerSize = graph.MeasureString("Ahar System", h1);
                var iconSize = XSize.FromSize(new Size(48, 32));
                var icon_left = (pdfPage.Width.Point - headerSize.Width - iconSize.Width) / 2;
                var header_left = icon_left + iconSize.Width;
                var icon_top = (64 - iconSize.Height) / 2;

                //######### HEADER
                graph.DrawImage(XImage.FromBitmapSource(bitmap), new XRect(icon_left, icon_top + top, 32, 32));
                graph.DrawString("Ahar System", h1, XBrushes.Black, new XRect(header_left, top, headerSize.Width, 64),
                    XStringFormats.Center);
                graph.DrawLine(XPens.Black, 16, 64, pdfPage.Width.Point - 16, 64);
                top += 64;
                //######### SOFTWARE
                var str = "Ahar High Level System Version " + CurrentVersion;
                var softwareSize = graph.MeasureString(str, h2);
                graph.DrawString(str, h2, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 32),
                    XStringFormats.CenterLeft);
                top += 32;
                str = "Device Info: " + prj.Device;
                graph.DrawString(str, h2, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 32),
                    XStringFormats.CenterLeft);
                top += 32;
                graph.DrawLine(XPens.Black, 16, top, pdfPage.Width.Point - 16, top);
                //######## Project
                str = "Project Number:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.ProjectNumber;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Unit Number:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.UnitNumber;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Unit Capacity:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.UnitCapacity;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Installation Date:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = new DateTime(prj.InstallationDate).ToShortDateString();
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Employer Name:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.EmployerName;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                graph.DrawLine(XPens.Black, 16, top, pdfPage.Width.Point - 16, top);
                //######## Date Time
                str = "Date:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = DateTime.Now.ToString("D");
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Time:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = DateTime.Now.ToString("h:mm:ss tt");
                ;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Username:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.Username;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                graph.DrawLine(XPens.Black, 16, top, pdfPage.Width.Point - 16, top);
                //###### Parameters
                if (paramList != null)
                {
                    foreach (var itm in paramList)
                    {
                        if (top + 20 > pdfPage.Height.Point)
                        {
                            pdfPage = pdf.AddPage();
                            graph = XGraphics.FromPdfPage(pdfPage);
                            top = 32;
                        }

                        str = itm.Label;
                        graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                            XStringFormats.CenterLeft);
                        if (itm is RealVariable Real)
                        {
                            str = Real.Value;
                        }
                        else if (itm is BoolVariable Bool)
                        {
                            str = Bool.Value ? "TRUE" : "FALSE";
                        }
                        else if (itm is EnumVariable Enum)
                        {
                            str = Enum.Items[Enum.Value];
                        }

                        if (!string.IsNullOrEmpty(itm.Unit))
                            str += " (" + itm.Unit + ")";
                        graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 250, top, pdfPage.Width.Point, 20),
                            XStringFormats.CenterLeft);
                        top += 20;
                    }
                }
                string pdfFilename = Path;
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
                return true;
            }
            catch (Exception ex)
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel(ex.Message, MessageBoxTypes.Information, (int)MessageBoxButtons.Ok,"Error",500,300)
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
                return false;
            }
        }
        public bool PrintLine(AharProjectType prj, string[] paramList)
        {
            try
            {
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "My First PDF";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont h1 = new XFont("SF UI Display", 20, XFontStyle.Bold);
                XFont h2 = new XFont("SF UI Display", 16, XFontStyle.BoldItalic);
                XFont h3 = new XFont("SF UI Display", 12, XFontStyle.Regular);
                XFont h4 = new XFont("SF UI Display", 10, XFontStyle.Regular);
                var bitmap = new BitmapImage(new Uri("pack://application:,,,/Resources/Favicon.png"));
                var top = 10;
                var headerSize = graph.MeasureString("Ahar System", h1);
                var iconSize = XSize.FromSize(new Size(48, 32));
                var icon_left = (pdfPage.Width.Point - headerSize.Width - iconSize.Width) / 2;
                var header_left = icon_left + iconSize.Width;
                var icon_top = (64 - iconSize.Height) / 2;

                //######### HEADER
                graph.DrawImage(XImage.FromBitmapSource(bitmap), new XRect(icon_left, icon_top + top, 32, 32));
                graph.DrawString("Ahar System", h1, XBrushes.Black, new XRect(header_left, top, headerSize.Width, 64),
                    XStringFormats.Center);
                graph.DrawLine(XPens.Black, 16, 64, pdfPage.Width.Point - 16, 64);
                top += 64;
                //######### SOFTWARE
                var str = "Ahar High Level System Version " + CurrentVersion;
                var softwareSize = graph.MeasureString(str, h2);
                graph.DrawString(str, h2, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 32),
                    XStringFormats.CenterLeft);
                top += 32;
                str = "Device Info:";
                graph.DrawString(str, h2, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 32),
                    XStringFormats.CenterLeft);
                top += 32;
                graph.DrawLine(XPens.Black, 16, top, pdfPage.Width.Point - 16, top);
                //######## Project
                str = "Project Number:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.ProjectNumber;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Unit Number:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.UnitNumber;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Unit Capacity:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.UnitCapacity;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Installation Date:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = new DateTime(prj.InstallationDate).ToShortDateString();
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Employer Name:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.EmployerName;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                graph.DrawLine(XPens.Black, 16, top, pdfPage.Width.Point - 16, top);
                //######## Date Time
                str = "Date:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = DateTime.Now.ToString("D");
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Time:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = DateTime.Now.ToString("h:mm:ss tt");
                ;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                str = "Username:";
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                str = prj.Username;
                graph.DrawString(str, h3, XBrushes.Black, new XRect(64 + 100, top, pdfPage.Width.Point, 20),
                    XStringFormats.CenterLeft);
                top += 20;
                graph.DrawLine(XPens.Black, 16, top, pdfPage.Width.Point - 16, top);
                //###### Parameters
                if (paramList != null)
                {
                    foreach (var itm in paramList)
                    {
                        if (top + 20 > pdfPage.Height.Point)
                        {
                            pdfPage = pdf.AddPage();
                            graph = XGraphics.FromPdfPage(pdfPage);
                            top = 32;
                        }

                        graph.DrawString(itm.Replace("\t", "    "), h4, XBrushes.Black,
                            new XRect(64, top, pdfPage.Width.Point, 20), XStringFormats.CenterLeft);
                        top += 20;
                    }
                }
                string pdfFilename = Path;
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
                return true;
            }
            catch (Exception ex)
            {
                var view = new MessageBoxView()
                {
                    DataContext = new MessageBoxViewModel(ex.Message, MessageBoxTypes.Information, (int)MessageBoxButtons.Ok, "Error", 500, 300)
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
                return false;
            }
        }
    }
}
