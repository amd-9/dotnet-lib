using Microsoft.Extensions.CommandLineUtils;
using SimpleLib;
using SimpleLib.WeatherAdapters;
using SimpleLib.WeatherAdapters.Models;
using SimpleLib.WeatherContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var dllFile = new FileInfo(@"..\SimpleLib.WeatherAdapters\bin\Debug\netcoreapp2.1\SimpleLib.WeatherAdapters.dll");

            var weatherAdapterType = typeof(IWeatherServiceAdapter);
            var weatherAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile.FullName);
            var weatherAssemplyTypes =  weatherAssembly.GetTypes().Where(t => weatherAdapterType.IsAssignableFrom(t)).ToList();

            var factory = new WeatherServiceFactory(weatherAssemplyTypes);

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
                    var weatherServiceAdapter = factory.CreateServiceAdapter(service.Value());
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
