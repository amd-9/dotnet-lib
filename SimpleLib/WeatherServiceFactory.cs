using SimpleLib.WeatherAdapters.Models;
using SimpleLib.WeatherContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLib
{
    public class WeatherServiceFactory
    {
        private  readonly List<Type> _adapterTypes;
        public WeatherServiceFactory(List<Type> adapterTypes)
        {
            _adapterTypes = adapterTypes;
        }
        public IWeatherServiceAdapter CreateServiceAdapter(string serviceName)
        {
            try
            {
                var adapterType =
                _adapterTypes.Where(t => Attribute.IsDefined(t, typeof(WeatherServiceAdapterAttribute)))
                    .Where(a => (Attribute.GetCustomAttribute(a, typeof(WeatherServiceAdapterAttribute)) as WeatherServiceAdapterAttribute).Name == serviceName)
                    .FirstOrDefault();
                
                var serviceAdress = Attribute.GetCustomAttribute(adapterType, typeof(WeatherServiceAddressAttribute)) as WeatherServiceAddressAttribute;

                var weatherClient = new HttpWeatherClient(serviceAdress.Address);

                IWeatherServiceAdapter adapterInstance = Activator.CreateInstance(adapterType,weatherClient) as IWeatherServiceAdapter;

                return adapterInstance;
            }
            catch(Exception ex)
            {
                //Log adapter not found
                throw ex;
            }
        }
    }
}
