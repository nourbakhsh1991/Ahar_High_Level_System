using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AharHighLevel.Common;
using AharHighLevel.Network;
using Prism.Events;

namespace AharHighLevel.EventAggregator
{
    public class FormDataEA : PubSubEvent<NetworkPacket>
    {
    }

    public class FormParameterDetailEa : PubSubEvent<Tuple<NetVariable, bool>>
    {

    }
    
    public class MessageBoxEa:PubSubEvent<MessageBoxData>
    { }

    public class Form1EA : PubSubEvent<byte[]>
    {
    }
    public class Form2EA : PubSubEvent<byte[]>
    {
    }
    public class Form3EA : PubSubEvent<byte[]>
    {
    }
    public class Form4EA : PubSubEvent<byte[]>
    {
    }
    public class Form5EA : PubSubEvent<byte[]>
    {
    }
    public class Form6EA : PubSubEvent<byte[]>
    {
    }
    public class Form7EA : PubSubEvent<byte[]>
    {
    }
    public class Form8EA : PubSubEvent<byte[]>
    {
    }
    public class Form9EA : PubSubEvent<byte[]>
    {
    }
    public class Form10EA : PubSubEvent<byte[]>
    {
    }
    public class Form11EA : PubSubEvent<byte[]>
    {
    }
    public class Form12EA : PubSubEvent<byte[]>
    {
    }
    public class Form13EA : PubSubEvent<byte[]>
    {
    }
    public class Form14EA : PubSubEvent<byte[]>
    {
    }
    public class ConfigureRdEA : PubSubEvent<byte[]>
    {
    }
    public class ConfigureSdEA : PubSubEvent<byte[]>
    {
    }
    public class ConfigurePmEA : PubSubEvent<byte[]>
    {
    }
    public class ConfigurePbEA : PubSubEvent<byte[]>
    {
    }

    public class SptAvEA : PubSubEvent<byte[]>
    {
    }
    public class SptFcEA : PubSubEvent<byte[]>
    {
    }
    public class SptStartupEA : PubSubEvent<byte[]>
    {
    }

    public class CtrlAvEA : PubSubEvent<byte[]>
    {
    }

    public class CtrlFcEA : PubSubEvent<byte[]>
    {
    }

    public class CtrlPfEA : PubSubEvent<byte[]>
    {
    }

    public class CtrlVarEA : PubSubEvent<byte[]>
    {
    }

    public class LimConfigureEA : PubSubEvent<byte[]>
    {
    }

    public class LimOliEA : PubSubEvent<byte[]>
    {
    }

    public class LimScEA : PubSubEvent<byte[]>
    {
    }

    public class LimUliEA : PubSubEvent<byte[]>
    {
    }

    public class LimVfEA : PubSubEvent<byte[]>
    {
    }

    public class PrcConfigureEA : PubSubEvent<byte[]>
    {
    }

    public class PrcPbEA : PubSubEvent<byte[]>
    {
    }

    public class PrcTempEA : PubSubEvent<byte[]>
    {
    }

    public class PrcSrvnEA : PubSubEvent<byte[]>
    {
    }

    public class PsConfigureEA : PubSubEvent<byte[]>
    {
    }

    public class PsParameterEA : PubSubEvent<byte[]>
    {
    }
    public class OpOmEA : PubSubEvent<byte[]>
    {
    }

    public class FormStatusEa : PubSubEvent<byte> { }
    public class FormsSendEa : PubSubEvent<NetworkPacket>
    {
    }

    public class FormsResultEa : PubSubEvent<bool>
    { }

    public class FormsCommands : PubSubEvent<string>
    { }
}
