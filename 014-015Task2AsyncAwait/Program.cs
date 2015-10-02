using System;
using System.Threading.Tasks;

namespace _014_015Task2AsyncAwait
{
    class Program
    {
        static void Main()
        {
            Task.Run(() => Console.WriteLine("First Task started ..."));
            Task.Run(() => Console.WriteLine("Second Task started ..."));

            Console.WriteLine("Main continue executing");
            Console.Read();
        }
    }
}
