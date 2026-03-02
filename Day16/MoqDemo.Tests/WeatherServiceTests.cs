using Moq;
using Xunit;
using MoqDemo;

namespace MoqDemo.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public void GetWeatherExpectedResult()
        {
            var mockWeatherService = new Mock<IWeatherService>();

            mockWeatherService
                .Setup(x => x.GetTemperatures(It.IsAny<string>()))
                .Returns(new List<double> { 30, 32, 28, 31, 29 });

            var weatherService = mockWeatherService.Object;

            var result = weatherService.GetTemperatures("New York");

            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void GetWeather_ThrowsException()
        {
            var mockWeatherService = new Mock<IWeatherService>();

            mockWeatherService
                .Setup(x => x.GetTemperatures(It.IsAny<string>()))
                .Throws(new Exception("City not found"));

            var weatherService = mockWeatherService.Object;

            Assert.Throws<Exception>(() =>
                weatherService.GetTemperatures("Some dummy city"));
        }
    }
}