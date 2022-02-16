using System;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class FileFormatFilterModel : CustomFilterModel<FileFormat>
    {
        public FileFormatFilterModel(Action onSelectionChanged)
            : base("File Format", onSelectionChanged)
        {
        }

        public override void UnselectAll()
        {
            Set(FileFormat.None);
            SelectedItemIndex = 0;
            base.UnselectAll();
        }
    }
}