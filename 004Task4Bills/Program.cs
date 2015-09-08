using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace _004Task4Bills
{
    class Program
    {
        static void Main()
        {
            var fileContents = File.ReadAllText(@"bills.txt");
            var regex = new Regex(@"(?<name>\S*)\s*(?<price>\S*)\s*(?<currency>\S*)\.\s*(?<count>\d*)\s*(?<day>\d{1,2})\.(?<month>\d{1,2})\.(?<year>\d*)");

            for(Match m = regex.Match(fileContents); m.Success; m = m.NextMatch())
            {
                var name = m.Groups["name"].Value;
                var price = double.Parse(m.Groups["price"].Value);
                var currency = m.Groups["currency"].Value;
                var count = int.Parse(m.Groups["count"].Value);

                var day = m.Groups["day"].Value;
                var month = m.Groups["month"].Value;
                var year = m.Groups["year"].Value;

                //int a;
                //if (int.TryParse(year, out a))
                //{
                    
                //}
                var date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

                var currentLocaleTime = date.ToString(CultureInfo.CurrentCulture);
                var usLocaleTime = date.ToString(CultureInfo.GetCultureInfo("en-US"));

                Console.WriteLine("Name - {0}", name);
                Console.WriteLine("Price - {0}", price);
                Console.WriteLine("Currency - {0}", currency);
                Console.WriteLine("Count - {0}", count);
                Console.WriteLine("Current locale time - {0}", currentLocaleTime);
                Console.WriteLine("en-US locale time - {0}\n", usLocaleTime);
            }

            Console.Read();
        }
    }
}
