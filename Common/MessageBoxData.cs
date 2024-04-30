using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Common
{
    public class MessageBoxData
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Keys { get; set; }
        public MessageBoxTypes Type { get; set; }
        public int Id { get; set; } = 0;
        public bool isResult { get; set; }
        public MessageBoxButtons Result { get; set; }
    }

}
