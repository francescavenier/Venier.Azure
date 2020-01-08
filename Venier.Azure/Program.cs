using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace Venier.Azure
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
        }
    }
}
