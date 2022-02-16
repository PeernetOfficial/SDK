﻿using System.ComponentModel;

namespace Peernet.SDK.Models.Presentation.Home
{
    public enum HealthType
    {
        [Description("Grean health indicator")]
        Green,

        [Description("Yellow health indicator")]
        Yellow,

        [Description("Red health indicator")]
        Red
    }
}