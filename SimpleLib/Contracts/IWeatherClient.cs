using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleLib.Models;

namespace SimpleLib.Contracts
{
    public interface IWeatherClient
    {
        Task<T> GetResponseAsync<T>(string apiPath);
    }
}
