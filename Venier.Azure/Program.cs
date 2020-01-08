using Microsoft.Azure.Storage;
using System;

namespace Venier.Azure
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var connectionString = CloudStorageAccount.Parse(StorageConnectionString);
        }
    }
}
