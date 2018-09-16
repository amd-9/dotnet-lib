using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLib.WeatherContracts
{
    public class WeatherServiceAddressAttribute: Attribute
    {
        public string Address { get; set; }
    }
}
