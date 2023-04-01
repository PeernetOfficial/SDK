namespace Peernet.SDK.Models.Presentation
{
    public enum DataTransferStatus
    {
        WaitMetadata = 0,
        WaitSwarm = 1,
        Active = 2,
        Pause = 3,
        Canceled = 4,
        Finished = 5,
        Failed = 6
    }
}
