using System;
using System.Collections;
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
        }
    }

    class MyEqualityComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
