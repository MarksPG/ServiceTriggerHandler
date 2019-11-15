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
            var resolver = new NameResolver();
            
            var uri = resolver.GetTriggerName(service, key);
            var host = new ServiceHost(typeof(WCFTriggerServiceClient), new Uri(uri));
            host.Open();
        }

        

        public bool Wait(TimeSpan timeOut)
        {
            return WCFTrigger.WCFTriggerService.elseReset.WaitOne(timeOut);
            
        }
    }
}
