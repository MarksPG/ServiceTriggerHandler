using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFTrigger
{
    class WCFTriggerService : IWCFTriggerService
    {
        public static AutoResetEvent elseReset = new AutoResetEvent(false);


        public string GetMessage(string name)
        {
            return "Hello World from " + name + "!";
        }

        public void Ping()
        {
            elseReset.Set();
        }
    }
}
