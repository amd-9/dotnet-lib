using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLib.WeatherContracts
{
    public class WeatherServiceAdapterAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
