using System;
using System.Xml;

namespace _005Task2XmlDocInfo
{
    class Program
    {
        static void Main()
        {
            var xmlPath = "TelephoneBook.xml";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);

            var root = xmlDocument.DocumentElement;
            Console.WriteLine("Root element : {0}", root.Name);

            foreach(XmlNode contact in root.ChildNodes)
            {
                Console.WriteLine("Found {0}", contact.Name);
                foreach (XmlAttribute attr in contact.Attributes)
                {
                    Console.WriteLine("{0}, {1}", attr.Name, attr.Value);
                }

                foreach(XmlNode name in contact)
                {
                    Console.WriteLine("{0}, {1}", name.Name, name.FirstChild.Value);
                }
            }

            Console.Read();
        }
    }
}
