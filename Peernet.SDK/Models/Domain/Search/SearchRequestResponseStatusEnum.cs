using System.ComponentModel;

namespace Peernet.SDK.Models.Domain.Search
{
    public enum SearchRequestResponseStatusEnum
    {
        [Description("Success (ID valid)")]
        Success = 0,

        [Description("Invalid Term")]
        InvalidTerm,

        [Description("Error Max Concurrent Searches")]
        ErrorMaxConcurrentSearches
    }
}