using System;
using System.Xml;

namespace _005Task3TelephonesOnly
{
    class Program
    {
        static void Main()
        {
            var xmlPath = @"C:\Users\Alex\Documents\GitHubVisualStudio\CyberBionic\005Task2XmlDocInfo\TelephoneBook.xml";
            var reader = new XmlTextReader(xmlPath);

            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Contact"))
                    {
                        Console.WriteLine(reader.GetAttribute("TelephoneNumber"));
                    }
                }
            }

            Console.Read();
        }
    }
}
