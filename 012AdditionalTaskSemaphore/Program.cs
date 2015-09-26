using System;
using System.IO;
using System.Text;
using System.Threading;

namespace _012AdditionalTaskSemaphore
{
    class Program
    {
        private static Semaphore _semaphore;
        private const int NumThreads = 3;

        private static int _count;

        static void ThreadTask()
        {
            _semaphore.WaitOne();

            using (var fileStream = new FileStream("log.txt", FileMode.Append))
            {
                var log = String.Format("{0} entered Semaphore. Count - {1} {2}", Thread.CurrentThread.Name, _count, Environment.NewLine);
                var bytes = new UTF8Encoding().GetBytes(log);
                fileStream.Write(bytes, 0, bytes.Length);

                _count++;

                log = String.Format("{0} exited Semaphore.Count - {1} {2}", Thread.CurrentThread.Name, _count, Environment.NewLine);
                bytes = new UTF8Encoding().GetBytes(log);
                fileStream.Write(bytes, 0, bytes.Length);

                fileStream.Close();
            }
            
            _semaphore.Release();
        }

        static void Main()
        {
            _semaphore = new Semaphore(1, 1); 
            _count = 0;

            var threads = new Thread[NumThreads];
            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ThreadTask)
                {
                    IsBackground = true,
                    Name = "Thread " + i
                };
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }
}