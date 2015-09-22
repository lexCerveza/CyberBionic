using System.IO;
using System.Text;
using System.Threading;

namespace _011Task2MultiThreadFile
{
    class Program
    {
        private static readonly object Locker = new object();

        static void Thread1Task()
        {
            var fileContents = File.ReadAllText("File1.txt");

            lock (Locker)
            {
                using (var fileStream = File.Open("File3.txt", FileMode.Append))
                {
                    var bytes = new UTF8Encoding().GetBytes(fileContents);
                    fileStream.Write(bytes, 0, bytes.Length);

                    fileStream.Close();
                }
            }
        }

        static void Thread2Task()
        {
            var fileContents = File.ReadAllText("File2.txt");

            lock (Locker)
            {
                using (var fileStream = File.Open("File3.txt", FileMode.Append))
                {
                    var bytes = new UTF8Encoding().GetBytes(fileContents);
                    fileStream.Write(bytes, 0, bytes.Length);

                    fileStream.Close();
                }
            }
        }

        static void Main()
        {
            var thread1 = new Thread(Thread1Task);
            var thread2 = new Thread(Thread2Task);

            thread1.Start();
            thread2.Start();
        }
    }
}
