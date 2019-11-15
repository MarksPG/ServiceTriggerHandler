using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ElseTriggerHandler
{
    [ServiceContract]
    interface ITriggerListener
    {
        [OperationContract]
        void SetUp(string service, int key);

        [OperationContract]
        bool Wait(TimeSpan timeOut);
    }
}
