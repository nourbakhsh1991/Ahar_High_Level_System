using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.ViewModel
{
    public class FormsMenuVM
    {
        public string Name { get; set; }
        public IEnumerable<FormVM> Items { get; set; }
    }
}
