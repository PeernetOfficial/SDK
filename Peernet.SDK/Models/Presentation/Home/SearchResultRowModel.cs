﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Peernet.SDK.Models.Domain.Common;
using Peernet.SDK.Models.Extensions;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class SearchResultRowModel : INotifyPropertyChanged
    {
        private bool isMapEnabled;

        public SearchResultRowModel(ApiFile source)
        {
            File = source;
            EnumerationMember = (HealthType)3;
            Name = source.Name;
            Date = source.Date;
            Size = $"{source.Size}";
            SharedBy = source.SharedByCount;
            //FlameIsVisible = source.SharedByCount > 15;
            Points = Map.ConvertGeoPointsToMapScale(source.SharedByGeoIP);
            IsMapEnabled = !Points.IsNullOrEmpty();
        }

        public static MapModel Map { get; } = new() { Width = 471, Height = 231 };
        public DateTime Date { get; }
        public HealthType EnumerationMember { get; }

        public ApiFile File { get; }

        public bool FlameIsVisible { get; }

        public bool IsCompleted { get; }

        public bool IsMapEnabled
        {
            get => isMapEnabled;
            set
            {
                isMapEnabled = value;
                PropertyChanged?.Invoke(this, new(nameof(IsMapEnabled)));
            }
        }

        public string Name { get; }
        public List<GeoPoint> Points { get; }
        public int SharedBy { get; }
        public string Size { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static DataGridSortingNameEnum Parse(string name)
        {
            switch (name)
            {
                case nameof(Name):
                    return DataGridSortingNameEnum.Name;

                case nameof(Date):
                    return DataGridSortingNameEnum.Date;

                case nameof(Size):
                    return DataGridSortingNameEnum.Size;

                case nameof(SharedBy):
                    return DataGridSortingNameEnum.Share;

                default:
                    return DataGridSortingNameEnum.None;
            }
        }
    }
}