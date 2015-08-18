using System;
using System.Reflection;

namespace _006Task3AssemblyUsage
{
    class Program
    {
        static void Main()
        {
            var assembly = Assembly.Load("006Task2CreateAssembly");;

            const double celsiusTemperature = 38.6;
            const double fahrenheitTemperature = 100.0;
            Array temperatureEnums = null;

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsEnum && type.Name.Equals("TemperatureTypeEnum"))
                {
                    temperatureEnums = Enum.GetValues(type);
                }
            }

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsClass && type.Name.Equals("TemperatureConverter"))
                {
                    var methodType = type.GetMethod("ConvertTemperatureCelsiusFahrenheit");
                    if (temperatureEnums != null)
                    {
                        var celsiusResult = methodType.Invoke(null,new object[] {celsiusTemperature, temperatureEnums.GetValue(0)});
                        var fahrResult = methodType.Invoke(null, new object[] { fahrenheitTemperature, temperatureEnums.GetValue(1)});
                        Console.WriteLine("Celsius To Fahrenheit : {0} -> {1}", celsiusTemperature, celsiusResult);
                        Console.WriteLine("Fahrenheit To Celsius : {0} -> {1}", fahrenheitTemperature, fahrResult);
                    }
                }
            }

            Console.Read();
        }
    }
}
