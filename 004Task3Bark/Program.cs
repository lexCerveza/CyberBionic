﻿using System.IO;
using System.Text.RegularExpressions;

namespace _004Task3Bark
{
    class Program
    {
        static void Main()
        {
            const string filePath = @"input.txt";
            var fileContents = File.ReadAllText(filePath);
            
            var barkContents = Regex.Replace(fileContents, "with|on|until|in|under|behind|between", "bark");
            File.WriteAllText(filePath, barkContents);
        }
    }
}
