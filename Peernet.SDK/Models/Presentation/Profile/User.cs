using Peernet.SDK.Models.Domain.Common;
using System.ComponentModel;

namespace Peernet.SDK.Models.Presentation.Profile
{
    public class User : INotifyPropertyChanged
    {
        private byte[] image;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public byte[] Image
        {
            get => image;
            set
            {
                if (value != image)
                {
                    image = value;
                    NotifyPropertyChanged(nameof(Image));
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public ApiFile[] Files { get; set; }

        public string Description { get; set; }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}