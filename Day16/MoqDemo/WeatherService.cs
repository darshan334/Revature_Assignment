namespace MoqDemo;

public interface IWeatherService
{
    IEnumerable<double> GetTemperatures(string city);
}

public class WeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperatures(string city)
    {
        yield return 20;
        yield return 21;
    }
}

public class MockWeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperatures(string city)
    {
        yield return 20;
        yield return 21;
        yield return 22;
        yield return 23;
        yield return 24;
    }
}