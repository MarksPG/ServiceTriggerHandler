using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class WCFBasicTriggerListener : ITriggerListener
    {
        public void SetUp(string service, int key)
        {
            var uri = GetUri(service, key);
            var host = new ServiceHost(typeof(), uri);
            host.Open();
        }

        

        public bool Wait(TimeSpan timeOut)
        {
            return name.WaitOne(timeOut);
            
        }
    }
}
