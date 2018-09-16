using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleLib.Models
{
    [DataContract]
    public class ApixuWeatherInfo
    {
        [DataMember(Name ="current")]
        public ApixuCurrentData current {get; set;}
    }
}
