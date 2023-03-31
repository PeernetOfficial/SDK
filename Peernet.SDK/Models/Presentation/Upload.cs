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
        public override event EventHandler StatusChanged;
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

            if (e.ProgressPercentage == 100)
            {
                IsCompleted = true;
                Completed?.Invoke(this, EventArgs.Empty);
            }
        }

        public FileModel File { get; }

        public override string Name => File.FileNameWithoutExtension;

        public override Task<ApiResponseDownloadStatus> Cancel()
        {
            if (IsCompleted)
            {
                return Task.FromResult(new ApiResponseDownloadStatus { DownloadStatus = DownloadStatus.DownloadFinished });
            }
            else
            {
                cancellationTokenSource.Cancel();
                return Task.FromResult(new ApiResponseDownloadStatus { DownloadStatus = DownloadStatus.DownloadCanceled });
            }
        }

        public override Task<ApiResponseDownloadStatus> Pause()
        {
            return Task.FromResult(new ApiResponseDownloadStatus { DownloadStatus = DownloadStatus.DownloadFinished });
        }

        public override Task<ApiResponseDownloadStatus> Resume()
        {
            return Task.FromResult(new ApiResponseDownloadStatus { DownloadStatus = DownloadStatus.DownloadFinished });
        }

        public override async Task<ApiResponseDownloadStatus> Start()
        {
            Id = Guid.NewGuid().ToString();
            var stream = System.IO.File.OpenRead(File.FullPath);
            var status = await client.Create(stream, progress, cancellationTokenSource.Token);
            if (status?.Status == WarehouseStatus.StatusOK)
            {
                File.Hash = status.Hash;
                return new ApiResponseDownloadStatus { DownloadStatus = DownloadStatus.DownloadFinished };
            }

            return new ApiResponseDownloadStatus { DownloadStatus = DownloadStatus.DownloadCanceled };
        }

        public override Task UpdateStatus()
        {
            return Task.CompletedTask;
        }
    }
}
