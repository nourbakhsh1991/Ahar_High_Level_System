using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Bootstrapper
{
    public interface IModuleServices
    {
        void ActivateView(string viewName, string regionName = "MainRegion");
    }
}
