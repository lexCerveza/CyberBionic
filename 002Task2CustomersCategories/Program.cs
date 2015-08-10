using System;
using System.Collections.Generic;

namespace _002Task2CustomersCategories
{
    static class Program
    {
        static void Main()
        {
            var stan = new Customer(1, "Stan");
            var eric = new Customer(2, "Eric");
            var kyle = new Customer(3, "Kyle");
            var kenny = new Customer(4, "Kenny");

            var customerCategoryDict = new Dictionary<Customer, int>()
            {
                {stan, 1},
                {eric, 1},
                {kyle, 1},
                {kenny, 1},
            };

            stan.Equals(new Customer(1, "Butters"));

            Console.WriteLine(customerCategoryDict[stan]);
            Console.WriteLine(customerCategoryDict[new Customer(1, "Stan")]);
            foreach (var customer in customerCategoryDict.GetCustomersByCategory(1))
            {
                Console.WriteLine(customer);
            }

            Console.Read();
        }

        public static IEnumerable<Customer> GetCustomersByCategory(this Dictionary<Customer, int> dictionary, int category)
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
