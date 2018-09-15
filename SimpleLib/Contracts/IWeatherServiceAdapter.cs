using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Contracts
{
    public interface IWeatherServiceAdapter
    {
        Task<List<WeatherInfo>> GetWeatherInfo(string location);
    }
}
