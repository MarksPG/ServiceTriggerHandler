using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    //enum ConnectionType
    //{
    //    Ewh,
    //    WcfBasic,
    //    Msmq
    //}

    abstract class TriggerSenderFactory
    {
        public ITriggerSender CreateConnectionType(TransportType transportType)

        {
            switch (transportType)
            {
                case TransportType.Ewh:
                    return new EWHTriggerSender();
                case TransportType.WcfBasic:
                    return new WCFBasicTriggerSender();
                case TransportType.Msmq:
                    return new MSMQTriggerSender();

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}


    

