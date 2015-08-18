using System;
using System.IO;

namespace _003AdditionalTaskCreateDirectories
{
    class Program
    {
        static void Main()
        {
            const int folderCount = 100;
            const string dirName = @"TestFolder";

            if (Directory.Exists(dirName))
            {
                for (var i = 0; i < folderCount; i++)
                {
                    Directory.CreateDirectory(String.Format(@"{0}\Folder_{1}", dirName, i));
                }

                for (var i = 0; i < folderCount; i++)
                {
                    Directory.Delete(String.Format(@"{0}\Folder_{1}", dirName, i));
                }
            }
            
        }
    }
}