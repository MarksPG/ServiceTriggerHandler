using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    enum TransportType
    {
        Ewh,
        WcfBasic,
        Msmq
    }

    abstract class TriggerListenerFactory
    {
        public ITriggerListener CreateConnectionType(TransportType connectionType)

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



