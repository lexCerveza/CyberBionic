using System;

namespace _013AsyncTaskCallback
{
    class Program
    {
        static void Main()
        {
            var customDelegate = new Func<string, string>(GetHelloString);

            customDelegate.BeginInvoke("Mark",
                                       (asyncResult) =>
                                       {
                                           var asyncState = asyncResult.AsyncState as Func<string, string>;
                                           if (asyncState != null)
                                           {
                                               var result = asyncState.EndInvoke(asyncResult);
                                               Console.WriteLine("Callback - " + result);
                                           }

                                           Console.WriteLine("Async Task End");
                                       }
                                       , customDelegate);

            Console.Read();
        }

        static string GetHelloString(string input)
        {
            return "Hello, " + input;
        }
    }
}
