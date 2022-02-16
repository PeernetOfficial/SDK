using System;

namespace Peernet.SDK.Models.Presentation.Home
{
    public class DateFilterModel : CustomFilterModel<TimePeriods>
    {
        public DateFilterModel(Action onSelectionChanged)
            : base("Date", onSelectionChanged)
        {
        }

        public override void UnselectAll()
        {
            base.UnselectAll();
            Set(TimePeriods.None);
            SelectedItemIndex = 0;
        }
    }
}