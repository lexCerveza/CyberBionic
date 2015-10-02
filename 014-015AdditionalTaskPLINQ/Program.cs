using System;
using System.Linq;

namespace _014_015AdditionalTaskPLINQ
{
    class Program
    {
        static void Main()
        {
            var result = Enumerable.Range(0, 1000000).Select(i => new Random().Next(10)).AsParallel().Where(i => (i % 2 == 1)).ToArray();
        }
    }
}
