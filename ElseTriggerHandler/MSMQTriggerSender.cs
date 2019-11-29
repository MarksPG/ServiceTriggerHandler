using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ElseTriggerHandler
{
    class MSMQTriggerSender : ITriggerSender
    {

        MessageQueue msgQueue;

        public string GetName(string service, int key)
        {
            var resolver = new MSMQNameResolver();
            string queuePath = resolver.GetTriggerName(service, key);
            return queuePath;
        }

        public void Send(string name)
        {
            string message = "Testing testing";
            msgQueue = new MessageQueue(name);
            var m = new Message();
            string label = "Ping!";

            using (CharEnumerator chars = message.GetEnumerator())
            {
                while (chars.MoveNext())
                {
                    m.BodyStream.WriteByte((byte)chars.Current);
                }
            }

            if (string.IsNullOrEmpty(label))
                msgQueue.Send(m, MessageQueueTransactionType.Single);
            else
                msgQueue.Send(m, label, MessageQueueTransactionType.Single);
        }

    }
    



}

