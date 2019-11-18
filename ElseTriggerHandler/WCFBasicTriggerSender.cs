using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class WCFBasicTriggerSender : ITriggerSender
    {
        INameResolver resolver = new WCFBasicNameResolver();
        public string GetName(string service, int key)
        {
            return resolver.GetTriggerName(service, key);
        }

        public void Send(string name)
        {

            using (var client = new WCFTriggerServiceClient(name))
            {
                client.Ping();
            }
        }
    }
}
