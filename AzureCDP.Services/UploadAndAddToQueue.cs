using AzureCDP.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCDP.Services
{
    public class UploadAndAddToQueue
    {
        public static void UploadAndQueue(string fileName, string storageConnection, byte[] data)
        {
            IFileUpload fileUpload = new FileUpload();
            IQueueUpload queue = new QueueUpload();
            fileUpload.UploadFile(fileName, storageConnection, data);
            queue.AddMessageToQueue(fileName);

        }
    }
}
