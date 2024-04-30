using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Common;

namespace AharHighLevel.ViewModel.Modals
{
    public class ProjectInformationModalViewModel :BaseViewModel
    {
        public AharProjectType Project { get; set; }
        public DateTime Date { get; set; }
        public ProjectInformationModalViewModel()
        {
            Initialize();
        }
        ~ProjectInformationModalViewModel() { }

        private void Initialize()
        {
            Project = AppStatics.Project;
            Date = Project != null ? new DateTime(Project.InstallationDate) : DateTime.Now;
        }
    }
}
