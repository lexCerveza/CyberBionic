using System;

namespace _010AdditionalTaskNVI
{
    public class BaseClass
    {
        public virtual void DoStuff()
        {
            Console.WriteLine("DoStuff : BaseClass");
        }
    }

    public class ChildClass : BaseClass
    {
        public override void DoStuff()
        {
            Console.WriteLine("DoStuff : ChildClass");
        }
    }


    class Program
    {
        static void Main()
        {
            BaseClass instance = new ChildClass();
            instance.DoStuff();

            Console.ReadKey();
        }
    }
}
