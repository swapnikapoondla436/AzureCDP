using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureCDP.IServices;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace AzureCDP.Services
{
    public class QueueUpload : IQueueUpload
    { 

        public void AddMessageToQueue(string fileName)
        {
            QueueClient client = QueueClient.Create("uploadqueue");
            BrokeredMessage msg = new BrokeredMessage(JsonConvert.SerializeObject(fileName));
            client.Send(msg);
        }

    }
}
