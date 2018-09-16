using SimpleLib.Contracts;
using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Clients
{
    public class ApixuWeatherServiceAdapter: IWeatherServiceAdapter
    {
        private readonly IWeatherClient _client;
        public ApixuWeatherServiceAdapter(IWeatherClient client)
        {
            _client = client;
        }

        public async Task<string> GetWeatherInfo(string location)
        {
            var weatherInfo = await _client.GetResponseAsync<ApixuWeatherInfo>($"current.json?key=cc73d8f649fb445e895154453181509&q={location}");

            return $"Current weather in {location} is {weatherInfo.current.temp_c}";
        }
    }
}
