using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class MSMQTriggerListener : ITriggerListener
    {
        public void SetUp(string service, int key)
        {
            
        }

        public bool Wait(TimeSpan timeOut)
        {
            return true;
        }


    }
}
