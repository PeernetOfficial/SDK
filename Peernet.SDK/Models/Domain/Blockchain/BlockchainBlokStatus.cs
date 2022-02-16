﻿using System.ComponentModel;

namespace Peernet.SDK.Models.Domain.Blockchain
{
    public enum BlockchainBlokStatus
    {
        [Description("Success")]
        Success = 0,

        [Description("Error block not found")]
        NotFound = 1,

        [Description("Error block encoding (indicates that the blockchain is corrupt")]
        EncodingError = 2,
    }
}