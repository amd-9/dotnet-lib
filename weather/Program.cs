using Microsoft.Extensions.CommandLineUtils;
using SimpleLib;
using SimpleLib.Clients;
using SimpleLib.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpWeatherClient = new HttpWeatherClient("https://www.metaweather.com/api/");

            Dictionary<string, Func<IWeatherServiceAdapter>> adapters = new Dictionary<string, Func<IWeatherServiceAdapter>>()
            {
                {"metaweather",()=>
                    {
                        httpWeatherClient = new HttpWeatherClient("https://www.metaweather.com/api/");
                        return new MetaWeatherServiceAdapter(httpWeatherClient);

                    } },
                {"apixu",()=>
                    {
                        httpWeatherClient = new HttpWeatherClient("http://api.apixu.com/v1/");
                        return new ApixuWeatherServiceAdapter(httpWeatherClient);

                     }}
            };


            CommandLineApplication commandLineApplication = new CommandLineApplication(throwOnUnexpectedArg: false);

            CommandArgument location = null;
            commandLineApplication.Command("location",
              (target) =>
                location = target.Argument(
                  "location",
                  "Enter the location name.",
                  multipleValues: false));

            CommandOption service = commandLineApplication.Option(
                "-$|-s |--service <service>",
                "Weather service to use. The greeting supports"
                + " two types of service 'metaweather' and 'apixu'",
                CommandOptionType.SingleValue);

            commandLineApplication.HelpOption("-? | -h | --help");

            commandLineApplication.OnExecute(() =>
            {
                if (service.HasValue())
                {
                    var weatherServiceAdapter = adapters[service.Value()]();
                    var weatherService = new WeatherService(weatherServiceAdapter);
                    var result = Task.Run(() => weatherService.GetWeatherData("london")).Result;

                    Console.WriteLine(result);
                }

                return 0;
            });

            commandLineApplication.Execute(args);
            
        }
    }
}
