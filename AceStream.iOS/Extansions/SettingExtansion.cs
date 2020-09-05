using System;
using Foundation;

namespace AceStream.Extansions
{
    public static class SettingExtansion
    {
        public static bool IsExit(this nint section)
        {
            return section == 1;
        }

        public static bool IsExit(this int section)
        {
            return section == 1;
        }

        public static bool IsAccountRow(this NSIndexPath indexPath)
        {
            return indexPath.Section == 0 && indexPath.Row == 0;
        }

        public static bool IsAboutRow(this NSIndexPath indexPath)
        {
            return indexPath.Section == 0 && indexPath.Row == 1;
        }
    }
}
