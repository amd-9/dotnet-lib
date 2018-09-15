using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleLib.Models
{
    [DataContract]
    public class WeatherInfo
    {
        [DataMember(Name= "id")]
        public string id { get; set; }
        [DataMember(Name = "weather_state_name")]
        public string weather_state_name { get; set; }
        [DataMember(Name = "weather_state_abbr")]
        public string weather_state_abbr { get; set; }
        [DataMember(Name = "wind_direction_compass")]
        public string wind_direction_compass { get; set; }
        [DataMember(Name = "created")]
        public string created { get; set; }
        [DataMember(Name = "applicable_date")]
        public string applicable_date { get; set; }
        [DataMember(Name = "min_temp")]
        public string min_temp { get; set; }
        [DataMember(Name = "max_temp")]
        public string max_temp { get; set; }
        [DataMember(Name = "the_temp")]
        public string the_temp { get; set; }
        [DataMember(Name = "wind_speed")]
        public string wind_speed { get; set; }
        [DataMember(Name = "wind_direction")]
        public string wind_direction { get; set; }
        [DataMember(Name = "air_pressure")]
        public string air_pressure { get; set; }
        [DataMember(Name = "humidity")]
        public string humidity { get; set; }
        [DataMember(Name = "visibility")]
        public string visibility { get; set; }
        [DataMember(Name = "predictability")]
        public string predictability { get; set; }
    }
}
