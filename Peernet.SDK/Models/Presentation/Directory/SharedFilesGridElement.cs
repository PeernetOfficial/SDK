using System;
using Peernet.SDK.Models.Domain.Common;

namespace Peernet.SDK.Models.Presentation.Directory
{
    public class SharedFilesGridElement
    {
        public string Name { get; set; }

        public LowLevelFileType Type { get; set; }

        public DateTime Date { get; set; }
    }
}