using Peernet.SDK.Models.Domain.Download;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Peernet.SDK.Models.Presentation
{
    public abstract class DataTransfer : INotifyPropertyChanged
    {
        private double progress;
        private bool isCompleted;
        private string id;

        public abstract event EventHandler Completed;
        public abstract event EventHandler StatusChanged;
        public abstract event EventHandler ProgressChanged;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        public double Progress
        {
            get => progress;
            set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Name { get; }

        public abstract Task<ApiResponseDownloadStatus> Pause();

        public abstract Task<ApiResponseDownloadStatus> Cancel();

        public abstract Task<ApiResponseDownloadStatus> Resume();

        public abstract Task<ApiResponseDownloadStatus> Start();
        
        public abstract Task UpdateStatus();
    }
}
