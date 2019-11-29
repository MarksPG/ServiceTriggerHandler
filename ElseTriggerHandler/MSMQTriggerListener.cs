using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class MSMQTriggerListener : ITriggerListener
    {
        private MessageQueue msgQueue;


        public void SetUp(string service, int key)
        {
            var resolver = new MSMQNameResolver();
            string path = resolver.GetTriggerName(service, key);


            if (MessageQueue.Exists(path))
            {
                MessageQueue.Delete(path);
            }

            msgQueue = MessageQueue.Create(path, true);


            var accessList = new AccessControlList();

            var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var ntAccount = (NTAccount)sid.Translate(typeof(NTAccount));
            accessList.Add(new MessageQueueAccessControlEntry(new Trustee(ntAccount.ToString()) { TrusteeType = TrusteeType.Group }, MessageQueueAccessRights.FullControl));

            sid = new SecurityIdentifier(WellKnownSidType.AnonymousSid, null);
            ntAccount = (NTAccount)sid.Translate(typeof(NTAccount));
            accessList.Add(new MessageQueueAccessControlEntry(new Trustee(ntAccount.ToString()) { TrusteeType = TrusteeType.Group }, MessageQueueAccessRights.FullControl));

            msgQueue.SetPermissions(accessList);

        }

        public bool Wait(TimeSpan timeOut)
        {

            try
            {
                Message message = msgQueue.Receive(timeOut);
                if (message == null)
                    return true;
            }
            catch (MessageQueueException e)
            {

                if (e.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    return false;
                throw;
            }

            return true;

        }


    }
}

