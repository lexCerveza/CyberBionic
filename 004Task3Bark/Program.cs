using System.IO;
using System.Text.RegularExpressions;

namespace _004Task3Bark
{
    class Program
    {
        static void Main()
        {
            var filePath = @"C:\Users\Alex\Documents\GitHubVisualStudio\CyberBionic\004Task3Bark\input.txt";
            var fileContents = File.ReadAllText(filePath);
            
            var barkContents = Regex.Replace(fileContents, @"with|on|until|in|under|behind|between", @"bark");
            File.WriteAllText(filePath, barkContents);
        }
    }
}
