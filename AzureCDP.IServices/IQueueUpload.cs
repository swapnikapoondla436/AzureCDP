using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCDP.IServices
{
    public interface IQueueUpload
    {
        void AddMessageToQueue(string fileName);
    }
}
