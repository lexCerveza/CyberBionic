using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _008Task2Task3BinarySerialization
{
    [Serializable]
    class SimpleClass
    {
        public int Id { get; set; }

        public SimpleClass(int id)
        {
            Id = id;
        }
    }

    class Program
    {
        static void Main()
        {
            const string data = "SimpleClassData.dat";
            var binaryFormatter = new BinaryFormatter();
            var serializeInstance = new SimpleClass(1);
            var fileStream = new FileStream(data, FileMode.Create);

            // Serialization 
            try
            {
                binaryFormatter.Serialize(fileStream, serializeInstance);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Serialization failed. Exception : " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }

            // Deserializion
            SimpleClass deserializeInstance;
            fileStream = new FileStream(data, FileMode.Open);
            try
            {
                deserializeInstance = (SimpleClass) binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Deserialization failed. Exception : " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
