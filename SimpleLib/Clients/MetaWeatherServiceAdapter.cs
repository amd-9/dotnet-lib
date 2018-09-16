using SimpleLib.Contracts;
using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Clients
{
    public class MetaWeatherServiceAdapter : IWeatherServiceAdapter
    {
        private readonly IWeatherClient _client;
        public MetaWeatherServiceAdapter(IWeatherClient client)
        {
            _client = client;
        }
        public async Task<string> GetWeatherInfo(string location)
        {
            var currentDate = DateTime.Now.ToString("yyyy/MM/dd");

            //Step 1: Get location info by location name
            var locationInfo = await _client.GetResponseAsync<List<LocationInfo>>($"location/search/?query={location}");

            var locData = locationInfo[0];

            //Step 2: Get weather data by location long and lat
            var weatherInfo = await _client.GetResponseAsync<List<WeatherInfo>>($"location/{locData.woeid}/{currentDate}/");

            return $"Current weather in {location} is {weatherInfo.First().the_temp}";
        }
    }
}
