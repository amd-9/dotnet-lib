using NUnit.Framework;
using SimpleLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLib.Tests
{
    [TestFixture]
    public class GeoService_Should
    {
        private readonly GeoService _geoService;
        public GeoService_Should()
        {
            _geoService = new GeoService();
        }

        [Test]
        public async Task GetGeoDataByIP()
        {
            var geoData = await _geoService.GetGeoDataByIP("134.234.3.2");
            Assert.IsInstanceOf(typeof(GeoInfo), geoData);
        }

        [Test]
        public async Task GetReturnSameQueryInGeoInfo()
        {
            var ipQuery = "134.234.3.2";
            var geoData = await _geoService.GetGeoDataByIP(ipQuery);

            Assert.AreEqual(ipQuery,geoData.query);
        }
    }
}
