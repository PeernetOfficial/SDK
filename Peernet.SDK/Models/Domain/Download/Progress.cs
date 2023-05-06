namespace Peernet.SDK.Models.Domain.Download
{
    public class Progress
    {
        public long TotalSize { get; set; }

        public int DownloadSize { get; set; }

        public double Percentage { get; set; }
    }
}