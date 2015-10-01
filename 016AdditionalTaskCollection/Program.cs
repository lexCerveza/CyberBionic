using System;
using System.Linq;

namespace _016AdditionalTaskCollection
{
    class Program
    {
        static void Main()
        {
            var collection = new[] {1, 2, 3, 4, 5, 6};

            var collectionPowOfTwo = collection.Select(i => (int) Math.Pow(i, 2)).ToArray();
            var collectionEven = collection.Select((element, index) =>
                                                    {
                                                        if (element % 2 == 1)
                                                        {
                                                            for (var i = index + 1; i < collection.Length; i++)
                                                            {
                                                                if (collection[i] % 2 == 0)
                                                                {
                                                                    return collection[i];
                                                                }
                                                            }
                                                        }

                                                        return element;
                                                    }).ToArray();
        }
    }
}