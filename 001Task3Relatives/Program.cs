using System;

namespace _001Task3Relatives
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Relative("John", 1978, new MyCollection<Relative>());
            var mike = new Relative("Mike", 1999, new MyCollection<Relative>() {john});
            var anna = new Relative("Anna", 2000, new MyCollection<Relative>() {john, mike});

            var collection = new MyCollection<Relative>()
            {
                john, 
                mike,
                anna
            };

            foreach (var relative in collection)
            {
                Console.WriteLine(relative);
            }

            collection.Remove(mike);
            Console.WriteLine();

            foreach (var relative in collection)
            {
                Console.WriteLine(relative);
            }
            //Console.WriteLine();

            //foreach (var relative in collection)
            //{
            //    Console.WriteLine(relative);
            //}

            //collection.GetRelatives(1);
            //Console.WriteLine();

            //Console.WriteLine(collection.GetRelativeByBirthDate(2000));

            Console.Read();
        }
    }
}
