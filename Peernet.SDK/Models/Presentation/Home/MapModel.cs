using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class MapModel
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public List<GeoPoint> ConvertGeoPointsToMapScale(string geoIPs)
        {
            var geoPoints = ParseGeoIPs(geoIPs);
            return geoPoints.Select(Convert).ToList();
        }

        private GeoPoint Convert(GeoPoint point)
        {
            var x = (point.Longitude + 180) * (Width / 360);
            var y = (point.Latitude + 90) * (Height / 180);

            return new GeoPoint(y, x);
        }

        private List<GeoPoint> ParseGeoIPs(string geoIPs)
        {
            var geoPoints = new List<GeoPoint>();
            if (geoIPs == null)
            {
                return geoPoints;
            }

            var points = geoIPs.Split("\n");

            foreach (var point in points)
            {
                var latitudeLongitude = point.Split(",");
                double latitude;
                double longitude;

                if (double.TryParse(latitudeLongitude[0], NumberStyles.Any, CultureInfo.InvariantCulture, out latitude) &&
                    double.TryParse(latitudeLongitude[1], NumberStyles.Any, CultureInfo.InvariantCulture, out longitude))
                {
                    geoPoints.Add(new GeoPoint(latitude, longitude));
                }
            }

            return geoPoints;
        }
    }
}