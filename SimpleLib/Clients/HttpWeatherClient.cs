using SimpleLib.Contracts;
using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Clients
{
    public class HttpWeatherClient : IWeatherClient
    {
        private readonly string _serviceAddress;
        public HttpWeatherClient(string serviceAddress)
        {
            _serviceAddress = serviceAddress;
        }
        public async Task<T> GetResponseAsync<T>(string apiPath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =new Uri(_serviceAddress);
                var serializer = new DataContractJsonSerializer(typeof(T));
                var responseStream = client.GetStreamAsync(apiPath);

                var geoInfo = (T)serializer.ReadObject(await responseStream);

                return geoInfo;
            }
        }

        public Task<WeatherInfo> GetWeatherInfo(string location)
        {
            throw new NotImplementedException();
        }
    }
}
