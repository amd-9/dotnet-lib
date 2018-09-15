using SimpleLib.Contracts;
using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib
{
    public class GeoService
    {
        private readonly IGeoServiceClient _client;
        public GeoService(IGeoServiceClient client)
        {
            _client = client;
        }
        public async Task<GeoInfo> GetGeoDataByIP(string ip)
        {
            try
            {
                var serviceAddress = string.Format("http://ip-api.com/json/{0}", ip);               
                return await _client.GetResponseAsync(serviceAddress);
  
            }
            catch (Exception ex)
            {
                //Log error
                throw ex;
            }
        }
    }
}
