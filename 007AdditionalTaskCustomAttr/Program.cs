using System;
using _007AdditionalTaskCustomAttr.Attributes;
using _007AdditionalTaskCustomAttr.Classes;

namespace _007AdditionalTaskCustomAttr
{
    static class Program
    {
        static void Main()
        {
            var director = new Director();
            var manager = new Manager();
            var programmer = new Programmer();

            Console.WriteLine("Director " + (AccessSystem(director) ? "access granted" : "access denied"));
            Console.WriteLine("Manager " + (AccessSystem(manager) ? "access granted" : "access denied"));
            Console.WriteLine("Programmer " + (AccessSystem(programmer) ? "access granted" : "access denied"));

            Console.Read();
        }

        private static bool AccessSystem(this Worker worker)
        {
            var accessLevel = ((AccessLevelAttribute)Attribute.GetCustomAttribute(Type.GetType(worker.ToString()), typeof(AccessLevelAttribute))).AccessLevel;
            return accessLevel == AccessLevel.High ? true : false;
        }
    }
}
