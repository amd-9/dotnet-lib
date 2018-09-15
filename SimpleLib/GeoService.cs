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
        public async Task<GeoInfo> GetGeoDataByIP(string ip)
        {
            try
            {
                var serviceAddress = string.Format("http://ip-api.com/json/{0}", ip);

                using (HttpClient client = new HttpClient())
                {
                    var serializer = new DataContractJsonSerializer(typeof(GeoInfo));
                    var responseStream = client.GetStreamAsync(serviceAddress);

                    var geoInfo = serializer.ReadObject(await responseStream) as GeoInfo;

                    return geoInfo;

                }
            }
            catch (Exception ex)
            {
                //Log error
                throw ex;
            }
        }
    }
}
