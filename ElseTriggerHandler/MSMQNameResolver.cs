using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class MSMQNameResolver : INameResolver
    {
        

        public string GetTriggerName(string service, int key)
        {
            string serverpath = ".";
            string pathName = $@"{serverpath}\Private$\{service}_{key}";
            

            return pathName;
        }

    }
}
