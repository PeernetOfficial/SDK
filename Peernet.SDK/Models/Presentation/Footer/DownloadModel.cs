using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Domain.Download;
using Peernet.SDK.Models.Extensions;
using Peernet.SDK.Models.Presentation.Home;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Peernet.SDK.Models.Presentation.Footer
{
    public class DownloadModel : INotifyPropertyChanged
    {
        private bool isCompleted;
        private bool isMapEnabled;
        private double progress;
        private DownloadStatus status;

        public DownloadModel(ApiFile file)
        {
            File = file;
            IsMapEnabled = !Points.IsNullOrEmpty();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static MapModel Map { get; } = new() { Width = 471, Height = 231 };
        public string DisplayName => File.Name.Length > 26 ? $"{File.Name.Substring(0, 26)}..." : File.Name;
        public ApiFile File { get; init; }
        public string FileSize => $"{File.Size}";
        public string Id { get; set; }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
            }
        }

        public bool IsMapEnabled
        {
            get => isMapEnabled;
            set
            {
                isMapEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsMapEnabled)));
            }
        }

        public bool IsPlayerEnabled { get; set; }

        public List<GeoPoint> Points => Map.ConvertGeoPointsToMapScale(GeoPoints);

        public List<GeoPoint> GeoPoints => ParseGeoIPs(File?.SharedByGeoIP);

        public double Progress
        {
            get => progress;
            set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }

        public DownloadStatus Status
        {
            get => status;
            set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
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