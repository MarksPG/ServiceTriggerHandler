using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    interface INameResolver
    {
        string GetTriggerName(string service, int key);
    }
}
