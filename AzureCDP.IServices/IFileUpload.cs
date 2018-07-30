using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCDP.IServices
{
    public interface IFileUpload
    {
        void UploadFile(string fileName, string storageConnection, byte[] data);
    }
}
