using System;

namespace _001Task2Months
{
    class Program
    {
        static void Main()
        {
            var january = new Month(1, 31);
            var february = new Month(2, 29);
            var march = new Month(3, 31);
            var april = new Month(4, 30);
            var may = new Month(5, 31);
            var june = new Month(6, 30);
            var july = new Month(7, 31);
            var august = new Month(8, 31);
            var september = new Month(9, 30);
            var october = new Month(10, 31);
            var november = new Month(11, 30);
            var december = new Month(12, 31);

            var collection = new MyCollection()
            {
                january, february, march, april, may, june, july, august, september, october, november, december
            };

            Console.WriteLine(collection.GetMonthByIndex(3));
            Console.WriteLine();

            foreach (var month in collection.GetMothsByDays(31))
            {
                Console.WriteLine(month);
            }

            Console.Read();
        }
    }
}
