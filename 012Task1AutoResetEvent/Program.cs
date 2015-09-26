using System;
using System.Threading;

namespace _012Task1AutoResetEvent
{
    class Program
    {
        private static readonly AutoResetEvent Manual = new AutoResetEvent(false);

        static void Main()
        {
            var threads = new Thread[]
            {
                new Thread(Function1),
                new Thread(Function2)
            };

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.WriteLine("Launch Event");
            Console.ReadKey();

            Manual.Set();
            Manual.Set();

            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Thread 1 Started");
            Manual.WaitOne(); 
            Console.WriteLine("Thread 1 Finished");
        }

        static void Function2()
        {
            Console.WriteLine("Thread 2 Started");
            Manual.WaitOne();
            Console.WriteLine("Thread 2 Finished");
        }
    }
}
