using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Contracts
{
    public interface IGeoServiceClient
    {
         Task<GeoInfo> GetResponseAsync(string serviceAddress);
    }
}
