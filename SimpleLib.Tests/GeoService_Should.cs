using Moq;
using NUnit.Framework;
using SimpleLib.Clients;
using SimpleLib.Contracts;
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
            var mock = new Mock<IGeoServiceClient>();
            mock.Setup(client => client.GetResponseAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new GeoInfo
                {
                    autonomousSystem = "AS1586 DoD Network Information Center",
                    city = "Sierra Vista (Fort Huachuca)",
                    country = "United States",
                    countryCode = "US",
                    isp = "",
                    lat = "31.5552",
                    lon = "-110.35",
                    org = "",
                    query = "134.234.3.2",
                    region = "",
                    regionName = "Arizona",
                    status = "success",
                    timezone = "America/Phoenix",
                    zip = "85613"
                }

            ));
            _geoService = new GeoService(mock.Object);
        }

        [Test]
        public async Task GetReturnSameQueryInGeoInfo()
        {
            var ipQuery = "134.234.3.2";
            var geoData = await _geoService.GetGeoDataByIP(ipQuery);

            Assert.AreEqual(ipQuery, geoData.query);
        }
    }
}
