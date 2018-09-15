using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleLib.Models
{
    [DataContract]
    public class LocationInfo
    {
        [DataMember(Name = "woeid")]
        public string woeid { get; set; }
        [DataMember(Name = "latt_long")]
        public string latt_long { get; set; }
    }
}
