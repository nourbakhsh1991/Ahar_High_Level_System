using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AharHighLevel.Common
{
    public interface IMouseEventHandler
    {
        void MouseEnterCommand(object Sender, MouseEventArgs Args);
        void MouseLeaveCommand(object Sender, MouseEventArgs Args);
    }
}
