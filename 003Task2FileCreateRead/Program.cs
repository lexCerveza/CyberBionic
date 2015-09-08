using System;
using System.IO;
using System.Text;

namespace _003Task2FileCreateRead
{
    class Program
    {
        static void Main()
        {
            const string filePath = @"the_shining.txt";
            const string fileContents = "All work and no play makes Jack a dull boy";
            
            byte[] byteFileContents = new UTF8Encoding(true).GetBytes(fileContents);

            using (var fileCreateWriteStream = new FileStream(filePath, FileMode.Create))
            {
                if (fileCreateWriteStream.CanWrite)
                {
                    fileCreateWriteStream.Write(byteFileContents, 0, byteFileContents.Length);
                }
            }

            Console.WriteLine(Encoding.UTF8.GetString(File.ReadAllBytes(filePath)));
            Console.Read();
        }
    }
}
