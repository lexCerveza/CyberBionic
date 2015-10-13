using System;

namespace _009Task2ResourceMonitoring
{
    enum MemoryConsumingLevel : long
    {
        Low = 10000,
        Medium = 20000,
        High = 30000
    }

    class ResourcesMonitor
    {
        public MemoryConsumingLevel MemoryConsumingLevel { get; set; }

        public bool IsCriticalMemoryConsuming()
        {
            return GC.GetTotalMemory(false) > (long) Enum.Parse(typeof(MemoryConsumingLevel), Enum.GetName(typeof(MemoryConsumingLevel), MemoryConsumingLevel));
        } 
    }

    class Program
    {
        static void Main()
        {
            var monitor = new ResourcesMonitor
            {
                MemoryConsumingLevel = MemoryConsumingLevel.Medium
            };

            var a = monitor.IsCriticalMemoryConsuming();
        }
    }
}
