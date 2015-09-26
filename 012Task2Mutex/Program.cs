using System;
using System.Threading;

namespace _012Task2Mutex
{
    class Program
    {
        static void Main()
        {
            bool mutexCreated;
            using (var mutex = new Mutex(true, "Mutex", out mutexCreated))
            {
                if (mutexCreated)
                {
                    Console.WriteLine("Instance of application launched");
                }
                else
                {
                    Environment.Exit(0);
                }

                Console.Read();
            }
        }
    }
}
