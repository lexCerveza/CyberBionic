using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Test
{
    class Program
    {
        static void Main()
        {
            using (var isolatedStorage = IsolatedStorageFile.GetMachineStoreForAssembly())
            {
                foreach (var dir in isolatedStorage.GetFileNames())
                {
                    Console.WriteLine(dir);
                }
                
                Console.Read();
            }
        }
    }
}
