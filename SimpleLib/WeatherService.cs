﻿using SimpleLib.Models;
using SimpleLib.WeatherContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib
{
    public class WeatherService
    {
        public readonly IWeatherServiceAdapter _serviceAdapter;
        public WeatherService(IWeatherServiceAdapter serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        public async Task<string> GetWeatherData(string location)
        {
            try
            {
                return await _serviceAdapter.GetWeatherInfo(location);
            }
            catch(Exception ex)
            {
                //Log error
                throw ex;
            }
        }
    }
}
