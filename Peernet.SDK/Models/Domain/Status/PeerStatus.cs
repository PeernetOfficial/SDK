using Peernet.SDK.Models.Presentation.Home;
using System.Globalization;
using System.Linq;

namespace Peernet.SDK.Models.Domain.Status
{
    public class PeerStatus
    {
        public string GeoIP { get; set; }

        public string NodeId { get; set; }

        public string PeerId { get; set; }

        public GeoPoint GetGeoIP()
        {
            if (!string.IsNullOrEmpty(GeoIP))
            {
                var geoIpArray = GeoIP?.Split(',').Select(geoIp => double.Parse(geoIp, CultureInfo.InvariantCulture)).ToArray();

                return new(geoIpArray[0], geoIpArray[1]);
            }

            return default;
        }
    }
}