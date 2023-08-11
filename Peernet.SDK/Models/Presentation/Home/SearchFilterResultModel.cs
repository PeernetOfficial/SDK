﻿using Peernet.SDK.Models.Extensions;
using System;
using System.ComponentModel;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class SearchFilterResultModel : INotifyPropertyChanged
    {
        private string nodeId;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdvancedFilterModel AdvancedFilter { get; set; }
        public FileFormat FileFormat { get; set; } = FileFormat.None;
        public FilterType FilterType { get; set; }
        public string InputText { get; set; }
        public bool IsNewSearch => Uuid.IsNullOrEmpty();
        public int Limit { get; set; }

        public string NodeId
        {
            get => nodeId;
            set
            {
                nodeId = value;
                PropertyChanged?.Invoke(this, new(nameof(NodeId)));
            }
        }

        public int Offset { get; set; }
        public bool ShouldReset { get; set; }
        public int? SizeFrom { get; set; }
        public int? SizeTo { get; set; }
        public TimePeriods? Time { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public string Uuid { get; set; }

        public (DateTime from, DateTime to) GetDateRange()
        {
            var from = DateTime.Now;
            var to = DateTime.Now;
            switch (Time)
            {
                case TimePeriods.Last24:
                    from = from.AddDays(-1);
                    break;

                case TimePeriods.LastWeek:
                    from = from.AddDays(-7);
                    break;

                case TimePeriods.LastMonth:
                    from = from.AddDays(-30);
                    break;

                case TimePeriods.LastYear:
                    from = from.AddDays(-365);
                    break;
            }

            return new(from, to);
        }
    }
}