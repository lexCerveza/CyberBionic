using System;
using System.Diagnostics;

namespace _017Task2ServiceInstall
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Service installing ...");
            Process.Start(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe", "WindowsServices.exe");
            Console.WriteLine("Service install done ...");
            Console.Read();
        }
    }
}
