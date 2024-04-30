using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Bootstrapper
{
    public class ViewRequestedEventAggregator : PubSubEvent<string>
    {
    }
    public class LoadProjectEventAggregator : PubSubEvent<bool>
    {
    }
}
