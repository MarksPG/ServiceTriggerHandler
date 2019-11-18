using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ElseTriggerHandler
{
    [ServiceContract]
    public interface ITriggerSender
    {
        [OperationContract]
        string GetName(string service, int key = -1);

        [OperationContract]
        void Send(string name);
    }
}
