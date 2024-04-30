using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class HistoryVariable
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public AharProjectType Project { get; set; }
        public object Content { get; set; }
        public int Index { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDlUl => Content is List<NetVariable>;
    }
}
