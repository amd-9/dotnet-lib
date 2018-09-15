using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleLib.Models
{
    [DataContract]
    public class GeoInfo
    {
        [DataMember(Name = "as")]
        public string autonomousSystem { get; set; }
        [DataMember(Name = "city")]
        public string city { get; set; }
        [DataMember(Name = "country")]
        public string country { get; set; }
        [DataMember(Name = "countryCode")]
        public string countryCode { get; set; }
        [DataMember(Name = "isp")]
        public string isp { get; set; }
        [DataMember(Name = "lat")]
        public string lat { get; set; }
        [DataMember(Name = "lon")]
        public string lon { get; set; }
        [DataMember(Name = "org")]
        public string org { get; set; }
        [DataMember(Name = "query")]
        public string query { get; set; }
        [DataMember(Name = "region")]
        public string region { get; set; }
        [DataMember(Name = "regionName")]
        public string regionName { get; set; }
        [DataMember(Name = "status")]
        public string status { get; set; }
        [DataMember(Name = "timezone")]
        public string timezone { get; set; }
        [DataMember(Name = "zip")]
        public string zip { get; set; }
    }
}
