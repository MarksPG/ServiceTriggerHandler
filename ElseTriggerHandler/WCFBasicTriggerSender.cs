using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    public class WCFBasicTriggerSender : ITriggerSender
    {

        public string GetName(string service, int key)
        {
            return name;
        }

        public void Send(string name)
        {

            using (var client = new WCFTriggerServiceClient(name));
            client.
        }
    }
}
