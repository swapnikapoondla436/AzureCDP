using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace ImportToTableStorage
{
    public class ProcessFileData
    {

        public static void ProcessFile(string file)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["StorageConnection"].ToString();
            Microsoft.WindowsAzure.Storage.CloudStorageAccount account = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(connectionString);
            StorageCredentialsAccountAndKey cre = new StorageCredentialsAccountAndKey(account.Credentials.AccountName, account.Credentials.ExportBase64EncodedKey());
            Microsoft.WindowsAzure.CloudStorageAccount ac = new Microsoft.WindowsAzure.CloudStorageAccount(cre, true);
            CloudTableClient client = account.CreateCloudTableClient();            
            CloudTable table = client.GetTableReference("employe");
            table.CreateIfNotExists();
            var dt = DataAccess.DataTable.New.ReadAzureBlob(ac, "fileupload", file);
            foreach (var row in dt.Rows)
            {
                EmployeeTableEntity emp = new EmployeeTableEntity { EmployeeId = Convert.ToInt16(row["EmployeeId"]), FirstName = row["FirstName"], LastName = row["LastName"], ContactNo = row["ContactNo"], EmailId = row["EmailId"], PartitionKey = row["EmployeeId"], RowKey = Guid.NewGuid().ToString() };
                TableOperation operation = TableOperation.InsertOrMerge(emp);
                table.Execute(operation);
            }
        }

    }
}

