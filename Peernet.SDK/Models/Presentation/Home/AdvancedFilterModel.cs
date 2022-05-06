using System.ComponentModel;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class AdvancedFilterModel : INotifyPropertyChanged
    {
        private bool isActive;
        private DataGridSortingNameEnum sortingName;
        private DataGridSortingTypeEnum sortingType;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsActive
        {
            get => isActive; set
            {
                isActive = value;
                PropertyChanged?.Invoke(this, new(nameof(IsActive)));
            }
        }

        public DataGridSortingNameEnum SortName
        {
            get => sortingName;
            set
            {
                sortingName = value;
                PropertyChanged?.Invoke(this, new(nameof(SortName)));
            }
        }

        public DataGridSortingTypeEnum SortType
        {
            get => sortingType;
            set
            {
                sortingType = value;
                PropertyChanged?.Invoke(this, new(nameof(SortType)));
            }
        }
    }
}