using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using WCFTrigger;

namespace ElseTriggerHandler
{
    class WCFBasicTriggerListener : ITriggerListener
    {
        public void SetUp(string service, int key)
        {
            var resolver = new WCFBasicNameResolver();
            

            Uri baseAddress = new Uri(resolver.GetTriggerName(service, key));
            ServiceHost serviceHost = new ServiceHost(typeof(WCFTriggerService), baseAddress);
            
            serviceHost.AddServiceEndpoint(typeof(IWCFTriggerService), new BasicHttpBinding(), baseAddress);


            ServiceMetadataBehavior smb = (ServiceMetadataBehavior)serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb == null)
            {
                smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(smb);
            }

            var edf = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
            edf.IncludeExceptionDetailInFaults = true;

            serviceHost.Open();
        }

        

        public bool Wait(TimeSpan timeOut)
        {
            return WCFTrigger.WCFTriggerService.elseReset.WaitOne(timeOut);
            
        }
    }
}
