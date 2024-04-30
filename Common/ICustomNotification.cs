using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace AharHighLevel.Common
{
    public interface ICustomNotification : IConfirmation
    {
        MessageBoxButtons Result { get; set; }
    }
}
