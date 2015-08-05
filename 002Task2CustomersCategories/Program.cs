using System;
using System.Collections.Generic;

namespace _002Task2CustomersCategories
{
    static class Program
    {
        static void Main()
        {
            var customerCategoryDict = new Dictionary<string, int>()
            {
                {"Stan", 1},
                {"Eric", 1},
                {"Kyle", 2},
                {"Kenny", 3}
            };

            Console.WriteLine(customerCategoryDict["Stan"]);
            foreach (var customer in customerCategoryDict.GetCustomersByCategory(2))
            {
                Console.WriteLine(customer);
            }

            Console.Read();
        }

        public static IEnumerable<string> GetCustomersByCategory(this Dictionary<string, int> dictionary, int category)
        {
            foreach (var record in dictionary)
            {
                if (record.Value == category)
                {
                    yield return record.Key;
                }
            }
        }
    }
}
