using System;
using System.Collections.Generic;
namespace _002Task3Dictionaries
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Dictionary");
            var dictionary = new Dictionary<int, double>()
            {
                {123, 256.123}, 
                {124, 256.124}, 
                {125, 256.143}
            };

            Console.WriteLine("Sorted Dictionary");
            var sortedDictionary = new SortedDictionary<int, double>()
            {
                {123, 256.123}, 
                {124, 256.124}, 
                {125, 256.143}
            };

            Console.Read();
        }
    }
}
