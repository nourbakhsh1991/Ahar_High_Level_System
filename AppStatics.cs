using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Common;
//using AharHighLevel.Models;
using AharHighLevel.Network;
using AharHighLevel.ProjectData;
using Microsoft.Practices.Unity;

namespace AharHighLevel
{
    public static class AppStatics
    {
        public static int AckTimeout => 30000;
        public static Action FileSaved { get; set; }
        public static Action FileOpened { get; set; }
        public static Action CurrentParamsChanged { get; set; }
        public static IUnityContainer Container { get; set; }
        public static FileHandler FileHandler { get; set; }
        public static NetworkMessenger Messenger { get; set; }
        public static List<NetVariable> CurrentParams { get; set; }
        public static List<NetVariable> SaveParams { get; set; }
        public static bool ProjectChanged => ChangedForms.Count > 0;
        public static bool FormSent { get; set; }
        private static List<int> ChangedForms { get; set; }
        private static List<int> FaultForms { get; set; }
        public static bool IsProjectLoaded { get; set; }
        public static string projectFolder { get; set; }
        public static AharProjectType Project { get; set; }
        public static int MinFormWidth => 600;
        public static bool ChartStarted { get; set; }
        public static int MinFormHeight => 500;
        public static int ActiveForm { get; set; }
        static AppStatics()
        {
            CurrentParams = new List<NetVariable>(ConfigParams.AllParams);
            SaveParams = new List<NetVariable>(ConfigParams.AllParams);
            ChangedForms = new List<int>();
            FaultForms = new List<int>();
            IsProjectLoaded = false;
        }

        public static void AddChangeForm(int id)
        {
            if (!ChangedForms.Contains(id)) ChangedForms.Add(id);
        }
        public static void RemoveChangeForm(int id)
        {
            if (ChangedForms.Contains(id)) ChangedForms.Remove(id);
        }
        public static void ClearChangeForm()
        {
            ChangedForms.Clear();
        }

        public static void AddFaultForm(int id)
        {
            if (!FaultForms.Contains(id)) FaultForms.Add(id);
        }
        public static void RemoveFaultForm(int id)
        {
            if (FaultForms.Contains(id)) FaultForms.Remove(id);
        }

        public static bool HasFault(int id)
        {
            return FaultForms.Contains(id);
        }

        public static bool HasFault()
        {
            return FaultForms.Count > 0;
        }

        public static bool HasSettingFault()
        {
            return FaultForms.Any(a => a < 100);
        }

        public static void NewProjectOpend()
        {
            FormSent = false;
            ChangedForms.Clear();
            IsProjectLoaded = true;
            ActiveForm = -1;
        }
        public static void ProjectClosed()
        {
            FormSent = false;
            ChangedForms.Clear();
            IsProjectLoaded = false;
            projectFolder = "";
            Project = null;
            Messenger.Disconnect();
            CurrentParams.Clear();
            SaveParams.Clear();
            ActiveForm = -1;
        }

    }
}
