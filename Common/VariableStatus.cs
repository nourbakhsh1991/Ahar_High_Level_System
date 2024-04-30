using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public enum VariableStatus
    {
        Init,
        Local,
        Loaded,
        Changed,
        Wrong,
        ReadOnly,
        SavedValue
    }
}
