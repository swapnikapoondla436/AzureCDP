using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UploadApi.Controllers
{
    public class UploadController : ApiController
    {
        
        public void UploadFile(string fileName, byte[] data)
        {
            String storageConnection = ConfigurationManager.ConnectionStrings["StorageConnection"].ToString();
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnection);
            CloudBlobClient client = account.CreateCloudBlobClient();
            string containerName = ConfigurationManager.AppSettings["UploadContainerName"];
            CloudBlobContainer container = client.GetContainerReference(containerName);
            container.CreateIfNotExists();
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            using (var stream = new MemoryStream(data))
            {
                blob.UploadFromStream(stream);
            }
        }

    }
}