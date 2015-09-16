using System;

namespace _008SoapSerialization
{
    [Serializable]
    class Record
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Record(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
