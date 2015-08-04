using System;

namespace _001Task4Dictionary
{
    class Program
    {
        static void Main()
        {
            var collection = new MyCollection<WordUkrEng>()
            {
                new WordUkrEng("молоко", "молоко", "milk"),
                new WordUkrEng("вдохновение", "натхнення", "inspiration")
            };

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(collection[0, EnumLangMode.Eng]);
            Console.WriteLine(collection[1, EnumLangMode.Ukr]);

            Console.Read();
        }
    }
}
