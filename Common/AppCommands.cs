using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public static class AppCommands
    {
        public static string Send => "__SEND";
        public static string StartLoading => "__LoadingStart";
        public static string EndLoading => "__LoadingEnd";
        public static string CancelEdit => "__CancelEdit";
        public static string CompareSettings => "__CompareSettings";
        public static string CopyRamToRomToggle => "__CopyRamToRomToggle";
        public static string NewPacket => "__NewPacket";
        public static string FormDataRefresh => "__FormDataRefresh";
        public static string FormLoadRefresh => "__FormLoadRefresh";
    }
}
