using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.WeatherContracts
{
    public interface IWeatherClient
    {
        Task<T> GetResponseAsync<T>(string apiPath);
    }
}
