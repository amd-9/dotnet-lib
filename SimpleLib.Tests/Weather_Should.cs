using Moq;
using NUnit.Framework;
using SimpleLib.WeatherContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Tests
{
    [TestFixture]
    public class Weather_Should
    {
        private readonly WeatherService _weatherService;

        public Weather_Should()
        {
            var mock = new Mock<IWeatherServiceAdapter>();
            mock.Setup(adapter => adapter.GetWeatherInfo(It.IsAny<string>()))
                .Returns(Task.FromResult("Current weather in london is 16.0"));

            _weatherService = new WeatherService(mock.Object);

        }

        [Test]
        public async Task GetWeatherByLocation()
        {
            var location = "london";
            var weatherResult = await _weatherService.GetWeatherData(location);

            Assert.AreEqual("Current weather in london is 16.0", weatherResult);
        }
    }
}
