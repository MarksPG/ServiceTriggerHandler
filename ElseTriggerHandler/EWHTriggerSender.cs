using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Threading;

namespace ElseTriggerHandler
{
    class EWHTriggerSender : ITriggerSender
    {
        
        public string GetName(string service, int key)
        {
            var resolver = new EWHNameResolver();
            var nameString = resolver.GetTriggerName(service, key);
            return nameString;
        }

        public void Send(string name)
        {
            var ewh = new EventWaitHandle(false, EventResetMode.AutoReset, name);
            ewh.Set();
        }
    }
}
