using System.Collections.Generic;
using Peernet.SDK.Models.Domain.Blockchain;

namespace Peernet.SDK.Models.Domain.Profile
{
    public class ApiProfileData
    {
        public List<ApiBlockRecordProfile> Fields { get; set; }

        public BlockchainStatus Status { get; set; }
    }
}