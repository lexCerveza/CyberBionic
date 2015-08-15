using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _004Task2WebPageParser
{
    class Program
    {
        static void Main()
        {
            string stringPage = string.Empty;
            stringPage += "<a href='http://cbsystematics.com'>Home-page</a>";
            stringPage += "<a href='http://google.com'>Search</a>";
            stringPage += "<a href='https://ya.ru'>Yandex</a>";
            stringPage += "<a href='https://yandex.ru'>Yandex Full</a>";
            stringPage += "<a href='http://microsoft.com'>Microsoft</a>";
            stringPage += "093 245 16 54";
            stringPage += "(093)2451654";
            stringPage += "0932451654";
            stringPage += "093 2451654";
            stringPage += "11111 Ukraine,Kiev Shevchenko Str. H.13 A.23";
            
            var linkRegex = new Regex(@"<a href='(?<link>\S+)'>");
            var phoneRegex = new Regex(@"(?<phone>\(?\d{3}\)?\s?\d{3}\s?\d{2}\s?\d{2})");
            var addressRegex = new Regex(@"(?<address>\d{5}\s*\S*,\S*\s*[\w|\s]*\.\s*H\.\d*\s*A\.\d*)");

            var fileContents = new StringBuilder();
            fileContents.AppendLine("Web-pages");
            for (Match m = linkRegex.Match(stringPage); m.Success; m = m.NextMatch())
            {
                fileContents.AppendFormat("{0}\n", m.Groups["link"].Value);
            }

            fileContents.AppendLine("Phones");
            for (Match m = phoneRegex.Match(stringPage); m.Success; m = m.NextMatch())
            {
                fileContents.AppendFormat("{0}\n", m.Groups["phone"].Value);
            }

            fileContents.AppendLine("Addresses");
            for (Match m = addressRegex.Match(stringPage); m.Success; m = m.NextMatch())
            {
                fileContents.AppendFormat("{0}\n", m.Groups["address"].Value);
            }

            var file = File.Create("webpage_info.txt");
            if (file.CanWrite)
            {
                var bytes = Encoding.UTF8.GetBytes(fileContents.ToString());
                file.Write(bytes, 0, bytes.Length);
            }
            file.Close();
        }
    }
}
