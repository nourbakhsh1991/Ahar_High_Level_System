using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public static class SystemInformation
    {
        public static string GetDeviceInformation()
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            var Manufacturer = "[NotProvided]";
            var Model = "[NotProvided]";
            ArrayList arrayListInformationCollactor = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;

                    foreach (PropertyData sp in searcherProperties)
                    {
                        if (sp.Name == "Manufacturer")
                            Manufacturer = sp.Value.ToString();
                        if (sp.Name == "Model")
                            Model = sp.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return Manufacturer + "/" + Model;
        }
        public static string GetUserInformation()
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            var UserName = "[NotProvided]";
            ArrayList arrayListInformationCollactor = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;

                    foreach (PropertyData sp in searcherProperties)
                    {
                        if (sp.Name == "UserName")
                            UserName = sp.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return  UserName;
        }
    }
}
