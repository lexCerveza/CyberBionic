using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace _002Task4OrderedDictionary
{
    class Program
    {
        static void Main()
        {
            var orderedDictionary = new OrderedDictionary(new MyEqualityComparer())
            {
                {"One", 1},
                {"Two", 2},
                {"Three", 3}
            };

            Console.Read();
        }
    }

    class MyEqualityComparer : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x is string && y is string)
            {
                return EqualityComparer<string>.Default.Equals((string) x, (string) y);
            }
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            if (obj is string)
            {
                return ((string) obj).GetHashCode();
            }

            return obj.GetHashCode();
        }
    }
}
