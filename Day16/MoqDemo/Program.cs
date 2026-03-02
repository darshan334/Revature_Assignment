using MoqDemo;

class Program
{
    static void Main()
    {
        IWeatherService weather = new WeatherService();

        foreach (var temp in weather.GetTemperatures("NewYork"))
        {
            System.Console.WriteLine(temp);
        }
    }
}