using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public enum MessageBoxTypes
    {
        Error,
        Warning,
        Information,
        Ok,
        Loading,
        None
    }

    public enum MessageBoxButtons
    {
        Ok = 1,
        Cancel = 2,
        Yes = 4,
        No = 8
    }
}
