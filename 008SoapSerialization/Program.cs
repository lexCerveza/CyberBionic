using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace _008SoapSerialization
{
    class Program
    {
        static void Main()
        {
            var record = new Record(1, "Name");
            var soapFormatter = new SoapFormatter();
            var fileStream = new FileStream("Record.soap", FileMode.Create);

            try
            {
                soapFormatter.Serialize(fileStream, record);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Serialization failed. Exception : " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
