using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Bootstrapper
{
    public interface INetworkMessenger
    {
        void StartConnection(IPAddress address, int port);
    }
}
