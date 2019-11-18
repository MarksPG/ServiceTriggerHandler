using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class EWHNameResolver : INameResolver
    {
        //private string triggerName;

        public string GetTriggerName(string service, int key)
        {
            return $"{service}.{key}";
        }
    }
}
