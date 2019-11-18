using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ElseTriggerHandler
{
    class EWHTriggerListener : ITriggerListener
    {
        private EventWaitHandle ewh;

        public void SetUp(string service, int key)
        {
            var resolver = new EWHNameResolver();
            var nameString = resolver.GetTriggerName(service, key);
            ewh = new EventWaitHandle(false, EventResetMode.AutoReset, nameString);
        }

        public bool Wait(TimeSpan timeOut)
        {
            return ewh.WaitOne(timeOut);
        }
    }
}
