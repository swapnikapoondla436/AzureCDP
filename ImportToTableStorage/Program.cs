using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportToTableStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueClient queueClient = QueueClient.Create("uploadqueue");
            BrokeredMessage message = queueClient.Receive();
            var msgText = message?.GetBody<string>();
            string fileName = JsonConvert.DeserializeObject<string>(msgText);
            ProcessFileData.ProcessFile(fileName); 
        }
    }
}
