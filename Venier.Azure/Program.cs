using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Threading;

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
            Console.WriteLine("Il messaggio è stato aggiunto alla coda.");

            //Dequeue messages
            /* First */
            // PeekMessage -> peeks first message
            //var queueMessage = queue.PeekMessage();

            /* Second */
            // GetMessage -> invisible for 30sec in queue
            while(true)
            { 
                var queueMessage = queue.GetMessage();
                if(queueMessage!=null)
                { 
                    Console.WriteLine(queueMessage.AsString);
                    queue.DeleteMessage(queueMessage);
                }
                else 
                {
                    Console.WriteLine("Nessun messaggio nella coda.");
                }
                Thread.Sleep(2000);
            }

            Console.ReadLine();
        }
    }
}
