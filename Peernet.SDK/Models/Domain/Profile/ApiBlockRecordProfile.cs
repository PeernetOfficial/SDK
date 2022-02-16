namespace Peernet.SDK.Models.Domain.Profile
{
    public class ApiBlockRecordProfile
    {
        public ProfileField Type { get; set; }

        public string Text { get; set; }

        public byte[] Blob { get; set; }
    }
}