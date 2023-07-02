using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Ink;

namespace Peernet.SDK.Models.Presentation.Profile
{
    public class User : INotifyPropertyChanged, IEquatable<User>
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

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public User DeepCopy()
        {
            return new User
            {
                Name = Name,
                Image = Image?.ToArray()
            };
        }

        public static bool operator ==(User left, User right)
        {
            return EqualityComparer<User>.Default.Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !(left == right) ;
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this is null || other is null)
            {
                return false;
            }

            return string.Equals(this.Name, other.Name) &&
                ImagesEqual(this.Image, other.Image);
        }

        private bool ImagesEqual(byte[] left, byte[] right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            else if (left != null && right != null)
            {
                return left.SequenceEqual(right);
            }
            else
            {
                return false;
            }

        }
    }
}