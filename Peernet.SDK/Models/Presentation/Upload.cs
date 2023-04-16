using Peernet.SDK.Client.Clients;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Download;
using Peernet.SDK.Models.Domain.Warehouse;
using Peernet.SDK.Models.Presentation.Footer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Peernet.SDK.Models.Presentation
{
    public class Upload : DataTransfer
    {
        private readonly Progress<UploadProgress> progress;
        private readonly IWarehouseClient client;
        private CancellationTokenSource cancellationTokenSource;

        public override event EventHandler Completed;
        public override event EventHandler ProgressChanged;

        public Upload(IWarehouseClient client, FileModel file, Progress<UploadProgress> progress)
        {
            this.client = client;
            File = file;
            this.progress = progress;
            progress.ProgressChanged += UploadProgressChanged;
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void UploadProgressChanged(object sender, UploadProgress e)
        {
            Progress = e.ProgressPercentage;
            ProgressChanged?.Invoke(this, EventArgs.Empty);
        }

        public FileModel File { get; }

        public override string Name => File.FileNameWithoutExtension;

        public override Task Cancel()
        {
            if (!IsCompleted)
            {
                cancellationTokenSource.Cancel();
                Status = DataTransferStatus.Canceled;
            }

            return Task.CompletedTask;
        }

        public override async Task Start()
        {
            Id = Guid.NewGuid();
            var stream = System.IO.File.OpenRead(File.FullPath);
            var status = await client.Create(Id, stream, progress, cancellationTokenSource.Token);
            if (status?.Status == WarehouseStatus.StatusOK)
            {
                IsCompleted = true;
                Completed?.Invoke(this, EventArgs.Empty);
                File.Hash = status.Hash;
                Status = DataTransferStatus.Finished;
            }
        }

        public override async Task UpdateStatus()
        {
            var status = await client.CreateTrackUploadId(Id);

            if (status != null)
            {
                if (status.UploadStatus == DataTransferStatus.Finished)
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
                Status = MapStatus(status.UploadStatus);
            }
        }

        private DataTransferStatus MapStatus(DataTransferStatus status)
        {
            switch (status)
            {
                case DataTransferStatus.Active:
                    return DataTransferStatus.Active;
                case DataTransferStatus.Finished:
                    return DataTransferStatus.Finished;
                case DataTransferStatus.Canceled:
                    return DataTransferStatus.Canceled;
                default:
                    return DataTransferStatus.Active;
            }
        }
    }
}
