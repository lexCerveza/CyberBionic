using System;
using System.Threading;

namespace _011AdditionalTaskThreadsStepByStep
{
    class Program
    {
        static void ThreadTask()
        {
            Console.WriteLine("Thread Start");
            Console.WriteLine("Thread Finish");
        }

        static void Main()
        {
            var thread1 = new Thread(ThreadTask);
            var thread2 = new Thread(ThreadTask);
            var thread3 = new Thread(ThreadTask);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.Read();
        }
    }
}