using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace _005AdditionalTaskTelephoneBook
{
    class Program
    {
        public static void Main(string[] args)
        {
            var root = new XElement("MyContacts",
                                    new XElement("Contact", new XAttribute("TelephoneNumber", "0991234567"),
                                                new XElement("name", "Igor")));
            var xml = new XDocument(new XDeclaration("1.0", "utf-8", "no"), root);

            xml.WriteTo(new XmlTextWriter(Console.Out));
            Console.Read();
        }
    }
}
