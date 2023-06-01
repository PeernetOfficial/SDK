using Peernet.SDK.Models.Presentation.Home;

namespace Peernet.SDK.Models.Presentation
{
    public class ResultsSnapshot
    {
        public string Title { get; set; }

        public PeernetSchemaViewType PeernetSchemaViewType { get; set; }

        public SearchResultModel SearchResultModel { get; set; }
    }
}
