using AzureCDP.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureCDP.Services
{
    public class FileUpload : IFileUpload
    {
        public void UploadFile(string fileName, string storageConnection, byte[] data)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnection);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("fileupload");
            container.CreateIfNotExists();
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            using (var stream = new MemoryStream(data))
            {
                blob.UploadFromStream(stream);
            }
        }
    }
}
