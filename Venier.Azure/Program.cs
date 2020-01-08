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

            CloudQueue queue = queueClient.GetQueueReference("myqueue");
            queue.CreateIfNotExists();

            //Create message in queue
            CloudQueueMessage message = new CloudQueueMessage("Hello!");
            queue.AddMessage(message);

            //Dequeue messages
            /* First */
            // PeekMessage -> peeks first message
            //var queueMessage = queue.PeekMessage();
            /* Second */
            // GetMessage -> 30sec
            var queueMessage = queue.GetMessage();

            queue.DeleteMessage(message);

            Console.ReadLine();
        }
    }
}
