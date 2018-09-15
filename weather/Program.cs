using SimpleLib;
using SimpleLib.Clients;
using System;
using System.Threading.Tasks;

namespace weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var HttpWeatherClient = new HttpWeatherClient("https://www.metaweather.com/api/");
            var metaServiceClient = new MetaWeatherServiceAdapter(HttpWeatherClient);
            var weatherService = new WeatherService(metaServiceClient);


            var result = Task.Run(() => weatherService.GetWeatherData("london")).Result;

            Console.WriteLine("Hello World!");
        }
    }
}
