using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Common;

namespace AharHighLevel.ViewModel.MainModule
{
    public class ConfigureInformationViewModel : BaseViewModel
    {
        public AharProjectType Project { get; set; }
        public DateTime Date { get; set; }
        public ConfigureInformationViewModel()
        {
            this.Initialize();
        }
        ~ConfigureInformationViewModel()
        {

        }

        private void Initialize()
        {
            Project = AppStatics.Project;
            Date = Project != null ? new DateTime(Project.InstallationDate) : DateTime.Now;
        }

    }
}
