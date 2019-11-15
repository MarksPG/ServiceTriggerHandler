using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFTrigger
{
    public class WCFTriggerService : IWCFTriggerService
    {
        public static AutoResetEvent elseReset = new AutoResetEvent(false);

        public void Ping()
        {
            elseReset.Set();
        }
    }
}
