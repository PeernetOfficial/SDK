using Peernet.SDK.Models.Presentation;
using System;

namespace Peernet.SDK.Common
{
    public interface ISettingsManager
    {
        string ApiKey { get; }

        string ApiUrl { get; set; }

        string Backend { get; set; }

        VisualMode DefaultTheme { get; set; }

        string DownloadPath { get; set; }

        string LogFile { get; }

        string PluginsLocation { get; set; }

        Uri SocketUrl { get; }

        void Save();
    }
}