using System;
using System.Collections.Generic;


namespace _002AdditionalTaskSortedList
{
    class Program
    {
        static void Main()
        {
            var bands = new SortedList<string, string>()
            {
                {"Onyx", "Hip-Hop"},
                {"Jacksons 5", "Pop"},
                {"Van Halen", "Hard Rock"},
                {"Boney M", "Disco"}
            };

            foreach (var band in bands)
            {
                Console.WriteLine(band);
            }
            Console.WriteLine("----------------------------");

            bands = new SortedList<string, string>(new MyComparerDescending())
            {
                {"Onyx", "Hip-Hop"},
                {"Jacksons 5", "Pop"},
                {"Van Halen", "Hard Rock"},
                {"Boney M", "Disco"}
            };

            foreach (var band in bands)
            {
                Console.WriteLine(band);
            }

            Console.Read();
        }
    }

    internal class MyComparerDescending : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return Comparer<string>.Default.Compare(y, x);
        }
    }
}
