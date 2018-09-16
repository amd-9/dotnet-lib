using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.WeatherContracts
{
    public interface IWeatherServiceAdapter
    {
        
        Task<string> GetWeatherInfo (string location);
    }
}
