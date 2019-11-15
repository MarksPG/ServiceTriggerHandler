using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class NameResolver : INameResolver
    {
        private string triggerName;

        public string GetTriggerName(string service, int key)
        {
            return triggerName;
        }
    }
}
