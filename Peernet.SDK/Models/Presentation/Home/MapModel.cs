using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class MapModel
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public List<GeoPoint> ConvertGeoPointsToMapScale(List<GeoPoint> geoPoints)
        {
            return geoPoints.Select(Convert).ToList();
        }

        private GeoPoint Convert(GeoPoint point)
        {
            var x = (point.Longitude + 180) * (Width / 360);
            var y = (point.Latitude + 90) * (Height / 180);

            return new GeoPoint(y, x);
        }
    }
}