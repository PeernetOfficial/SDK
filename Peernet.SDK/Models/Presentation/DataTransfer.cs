using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Peernet.SDK.Models.Presentation
{
    public abstract class DataTransfer : INotifyPropertyChanged
    {
        private Guid id;
        private bool isCompleted;
        private double progress;
        private DataTransferStatus status;

        public abstract event EventHandler Completed;

        public abstract event EventHandler ProgressChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
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

        public abstract string Name { get; }

        public double Progress
        {
            get => progress;
            set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }

        public DataTransferStatus Status
        {
            get => status;
            set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }

        public abstract Task Cancel();

        public virtual Task Pause()
        {
            return Task.CompletedTask;
        }

        public virtual Task Resume()
        {
            return Task.CompletedTask;
        }

        public abstract Task Start();

        public abstract Task UpdateStatus();
    }
}