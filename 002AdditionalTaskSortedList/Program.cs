using System;
using System.Collections.Generic;


namespace _002AdditionalTaskSortedList
{
    class Program
    {
        static void Main()
        {
            var bands = new SortedList<string, string>();
            bands["Onyx"] = "Hip-Hop";
            bands["Jacksons 5"] = "Pop";
            bands["Van Halen"] = "Hard Rock";
            bands["Boney M"] = "Disco";

            foreach (var band in bands)
            {
                Console.WriteLine(band);
            }
            Console.WriteLine("----------------------------");

            bands = new SortedList<string, string>(new MyComparerDescending());
            bands["Onyx"] = "Hip-Hop";
            bands["Jacksons 5"] = "Pop";
            bands["Van Halen"] = "Hard Rock";
            bands["Boney M"] = "Disco";

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
            return y[0] - x[0];
        }
    }
}
