
namespace _006Task2CreateAssembly
{
    class TemperatureConverter
    {
        public static double ConvertTemperatureCelsiusFahrenheit(double temperature, TemperatureTypeEnum temperatureType)
        {
            return temperatureType == TemperatureTypeEnum.Celsius
                ? temperature*(9.0/5) + 32
                : (temperature - 32)*(5.0/9);
        }
    }
}
