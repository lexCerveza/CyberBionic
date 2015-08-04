using System;
using System.Collections;

namespace _001AdditionalTaskYield
{
    static class Program
    {
        public static IEnumerable PowerUnpaired(this int[] array)
        {
            for (var i = 0; i < array.Length; i ++)
            {
                if (array[i]%2 == 1)
                {
                    yield return array[i] * array[i];
                }
            }
        }

        static void Main()
        {
            int[] arr = {2, 3, 4, 4, 5, 3, 7};
            foreach (var element in arr.PowerUnpaired())
            {
                Console.Write("{0} ", element);
            }

            Console.Read();
        }
    }
}
