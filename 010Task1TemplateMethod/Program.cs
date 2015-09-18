using System;

namespace _010Task1TemplateMethod
{
    public abstract class BaseAlgorithm
    {
        public void DoAlgorithm()
        {
            Step1();
            Step2();
            Step3();
        }

        public abstract void Step1();
        public abstract void Step2();
        public abstract void Step3();
    }

    public class CustomAlgorithm : BaseAlgorithm
    {
        public override void Step1()
        {
            Console.WriteLine("Step 1");
        }

        public override void Step2()
        {
            Console.WriteLine("Step 2");
        }

        public override void Step3()
        {
            Console.WriteLine("Step 3");
        }
    }

    class Program
    {
        static void Main()
        {
            BaseAlgorithm algorithm = new CustomAlgorithm();
            algorithm.DoAlgorithm();

            Console.Read();
        }
    }
}
