using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AharHighLevel.Bootstrapper;
using AharHighLevel.Common;
using AharHighLevel.EventAggregator;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.ProjectData
{
    public class FileHandler : IFileHandler
    {
        public bool FileSaved { get; set; }
        public string FilePath { get; set; }
        public string FileStreamer { get; set; }
        public string FilePassword { get; set; }
        private static Semaphore semaphore = new Semaphore(1, 1);
        public FileHandler()
        {
            FilePassword = "Ahar";
            this.Initialize();
        }
        public void Initialize()
        {

        }

        public bool ProjectDataHandler(dynamic obj)
        {
            try
            {
                if (obj.Status == ProjectDataStatus.Create)
                {
                    var prjPath = obj.folderPath + obj.prjName;
                    
                    return CryptoService.CreateProject(new FileInfo(prjPath), FilePassword, obj); ;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public AharProjectType OpenDownloadDataHandler(HistoryVariable history, List<NetVariable> paramList, string path)
        {
            try
            {


                return CryptoService.OpenProjectDownload(new FileInfo(path), FilePassword, history, paramList);



                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool SaveProjectDataHandler(dynamic obj)
        {
            try
            {
                if (obj.Status == ProjectDataStatus.Create)
                {
                    var prjPath = obj.folderPath + obj.prjName;
                    

                    return CryptoService.SaveProject(new FileInfo(prjPath), FilePassword, obj, AppStatics.CurrentParams); ;
                }

                return false;
            }
            catch (Exception exs)
            {
                return false;
            }
        }
        public bool SaveDownloadDataHandler(dynamic obj)
        {
            try
            {
                if (obj.Status == ProjectDataStatus.Create)
                {
                    var prjPath = obj.folderPath + obj.prjName;
                    var pack = new List<NetVariable>();
                    // Real
                    pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex <= 10193 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                    // Bool
                    pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20000 && a.MainIndex <= 20027 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                    // Enum
                    pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30000 && a.MainIndex <= 30017 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                    CryptoService.SaveDownload(new FileInfo(prjPath), FilePassword, obj, pack);

                    return true;
                }

                return false;
            }
            catch (Exception exs)
            {
                return false;
            }
        }
        public bool SaveUploadDataHandler(dynamic obj)
        {
            try
            {
                if (obj.Status == ProjectDataStatus.Create)
                {
                    var prjPath = obj.folderPath + obj.prjName;
                    var pack = new List<NetVariable>();
                    // Real
                    pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 10000 && a.MainIndex <= 10193 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                    // Bool
                    pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 20000 && a.MainIndex <= 20027 && !a.IsReadOnly).OrderBy(a => a.MainIndex));
                    // Enum
                    pack.AddRange(AppStatics.CurrentParams.Where(a => a.MainIndex >= 30000 && a.MainIndex <= 30017 && !a.IsReadOnly).OrderBy(a => a.MainIndex));

                    CryptoService.SaveUpload(new FileInfo(prjPath), FilePassword, obj, pack);

                    return true;
                }

                return false;
            }
            catch (Exception exs)
            {
                return false;
            }
        }
        public bool SaveProjectAsDataHandler(dynamic obj)
        {
            try
            {
                if (obj.Status == ProjectDataStatus.Create)
                {
                    var prjPath = obj.folderPath + obj.prjName;

                    return CryptoService.SaveProject(new FileInfo(prjPath), FilePassword, obj, AppStatics.CurrentParams);
                }

                return false;
            }
            catch (Exception exs)
            {
                return false;
            }
        }

        public AharProjectType OpenProjectDataHandler(dynamic obj)
        {
            try
            {
                if (obj.Status == ProjectDataStatus.Open)
                {
                    var prjPath = obj.folderPath + obj.prjName;
                    return CryptoService.OpenProject(new FileInfo(prjPath), FilePassword);

                }

                return null;
            }
            catch (Exception exs)
            {
                return null;
            }
        }

        public void GenerateLog(string[] strs)
        {
            try
            {
                semaphore.WaitOne();
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }
                    var lines = new List<string>(strs);
                    if (lines.Count == 0) return;
                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {

                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + lines[0]);
                        lines.RemoveAt(0);
                        foreach (var line in lines)
                        {
                            sw.WriteLine("\t\t" + lines[0]);
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }

                semaphore.Release();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Log File...");
            }
  
        }
    }
}
