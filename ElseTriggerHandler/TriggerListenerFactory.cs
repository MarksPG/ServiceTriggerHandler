using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    public enum TransportType
    {
        Ewh,
        WcfBasic,
        Msmq
    }

    public static class TriggerListenerFactory
    {
        public static ITriggerListener CreateTransportType(TransportType connectionType)

        {
            switch (connectionType)
            {
                case TransportType.Ewh:
                    return new EWHTriggerListener();
                case TransportType.WcfBasic:
                    return new WCFBasicTriggerListener();
                case TransportType.Msmq:
                    return new MSMQTriggerListener();

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}



