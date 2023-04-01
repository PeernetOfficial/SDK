using Peernet.SDK.Client.Clients;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Domain.Download;
using System;
using System.Threading.Tasks;

namespace Peernet.SDK.Models.Presentation
{
    public class Download : DataTransfer
    {
        private readonly IDownloadClient downloadClient;

        public Download(IDownloadClient downloadClient, ApiFile file, string path)
            : base()
        {
            this.downloadClient = downloadClient; 
            File = file;
            DestinationPath = path;
        }

        public ApiFile File { get; set; }

        public string DestinationPath { get; private set; }

        public override string Name => File.Name.Length > 26 ? $"{File.Name.Substring(0, 26)}..." : File.Name;

        public override event EventHandler Completed;
        public override event EventHandler ProgressChanged;

        public override async Task Cancel()
        {
            var responseStatus = await Execute(DownloadAction.Cancel);
            Status = MapStatus(responseStatus.DownloadStatus);
        }

        public override async Task Pause()
        {
            var responseStatus = await Execute(DownloadAction.Pause);
            Status = MapStatus(responseStatus.DownloadStatus);
        }

        public override async Task Resume()
        {
            var responseStatus = await Execute(DownloadAction.Resume);
            Status = MapStatus(responseStatus.DownloadStatus);
        }

        public override async Task Start()
        {
            var responseStatus = await downloadClient.Start(DestinationPath, File.Hash, File.NodeId);
            Id = responseStatus.Id;
            Status = MapStatus(responseStatus.DownloadStatus);
        }

        public override async Task UpdateStatus()
        {
            var status = await downloadClient.GetStatus(Id);
            if (status != null)
            {
                if (status.DownloadStatus == DownloadStatus.DownloadFinished)
                {
                    IsCompleted = true;
                    Progress = 100;
                    Completed?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    Progress = status.Progress.Percentage;
                }
                
                ProgressChanged?.Invoke(this, EventArgs.Empty);
                Status = MapStatus(status.DownloadStatus);
            }
        }

        private async Task<ApiResponseDownloadStatus> Execute(DownloadAction action)
        {
            return await downloadClient.GetAction(Id, action);
        }

        private DataTransferStatus MapStatus(DownloadStatus downloadStatus)
        {
            switch (downloadStatus)
            {
                case DownloadStatus.DownloadFinished:
                    return DataTransferStatus.Finished;
                case DownloadStatus.DownloadPause:
                    return DataTransferStatus.Pause;
                case DownloadStatus.DownloadCanceled:
                    return DataTransferStatus.Canceled;
                case DownloadStatus.DownloadActive:
                    return DataTransferStatus.Active;
                case DownloadStatus.DownloadWaitMetadata:
                    return DataTransferStatus.WaitMetadata;
                case DownloadStatus.DownloadWaitSwarm:
                    return DataTransferStatus.WaitSwarm;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
