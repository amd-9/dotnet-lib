using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleLib.WeatherAdapters.Models
{
    
    public class ApixuCurrentData
    {
        [DataMember(Name ="temp_c")]
        public string temp_c { get; set; }
    }
}
