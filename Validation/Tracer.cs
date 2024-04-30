using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Validation
{
    public class Tracer
    {
        public static string Topic;

        public static void LogValidation(string msg)
        {
            Debug.WriteLine(msg);
        }

        public static void LogUserDefinedValidation(string msg)
        {
            Debug.WriteLine(msg);
        }

        public static void LogApplication(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
