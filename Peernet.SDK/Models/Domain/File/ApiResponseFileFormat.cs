using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Models.Domain.File
{
    public class ApiResponseFileFormat
    {
        public int Status { get; set; }

        public LowLevelFileType FileType { get; set; }

        public HighLevelFileType FileFormat { get; set; }
    }
}