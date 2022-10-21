using System;

namespace RETCON.Core
{
    public enum OS
    {
        Windows,
        MacOS,
        Linux
    }

    public static class OSHelper
    {
        public static string GetCurrentUserName()
        {
            return Environment.UserName;
        }

        public static bool Is64BitSystem()
        {
            return Environment.Is64BitOperatingSystem;
        }

        public static OS GetOperatingSystem()
        {
            var platformID = Environment.OSVersion.Platform;

            if (platformID == PlatformID.Win32NT)
                return OS.Windows;

            return OS.Linux;
        }
    }

    public static class FunctionHelpers
    {
        public static int Bit(int x)
        {
            return 1 << x;
        }
    }
}
