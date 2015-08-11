using System;
using System.Text.RegularExpressions;

namespace _004AdditionalTaskLoginPassword
{
    class Program
    {
        static void Main()
        {
            const string loginPattern = @"[a-z|A-Z]+";
            const string passwordPattern = @"\w+";

            var loginRegex = new Regex(loginPattern);
            var passwordRegex = new Regex(passwordPattern);

            Console.WriteLine("Login : ");
            var userLogin = Console.ReadLine();

            if (userLogin != null && loginRegex.Match(userLogin).ToString().Equals(userLogin))
            {
                Console.WriteLine("Password : ");
                var userPassword = Console.ReadLine();

                if (userPassword != null && passwordRegex.Match(userPassword).ToString().Equals(userPassword))
                {
                    Console.WriteLine("Log in successful !");
                }
                else
                {
                    Console.WriteLine("Invalid password !");
                }
            }
            else
            {
                Console.WriteLine("Invalid login !");
            }

            Console.Read();
        }
    }
}
