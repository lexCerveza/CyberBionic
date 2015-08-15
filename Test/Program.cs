using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Test
{
    class Program
    {
        static void Main()
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetMachineStoreForAssembly();

            IsolatedStorageFileStream file = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, isolatedStorage);

            var streamWriter = new StreamWriter(file);
            streamWriter.WriteLine("User Settings");
            streamWriter.Close();
        }
    }
}
