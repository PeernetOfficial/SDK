using System;
using System.ComponentModel;

namespace Peernet.SDK.Models.Presentation.Widgets
{
    public class WidgetModel : INotifyPropertyChanged
    {
        private bool isSelected;

        public event EventHandler SelectionChanged;

        public WidgetModel(EventHandler selectionChanged, string name, bool isSelected)
        {
            SelectionChanged += selectionChanged;
            Name = name;
            IsSelected = isSelected;
        }

        public string Name { get; set; }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                    SelectionChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
