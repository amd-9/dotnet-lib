using SimpleLib.Contracts;
using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Clients
{
    public class GeoServiceHttpClient : IGeoServiceClient
    {
        public async Task<GeoInfo> GetResponseAsync(string serviceAddress)
        {
            using (HttpClient client = new HttpClient())
            {
                var serializer = new DataContractJsonSerializer(typeof(GeoInfo));
                var responseStream = client.GetStreamAsync(serviceAddress);

                var geoInfo = serializer.ReadObject(await responseStream) as GeoInfo;

                return geoInfo;
            }
        }
    }
}
