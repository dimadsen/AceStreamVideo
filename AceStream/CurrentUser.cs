using System;
using Foundation;

namespace AceStream
{
    public static class CurrentUser
    {
        public static nint Id
        {
            get => NSUserDefaults.StandardUserDefaults.IntForKey(nameof(Id));
            set => NSUserDefaults.StandardUserDefaults.SetInt(value, nameof(Id));
        }

        public static bool IsAuthorized
        {
            get => NSUserDefaults.StandardUserDefaults.BoolForKey(nameof(IsAuthorized));
            set => NSUserDefaults.StandardUserDefaults.SetBool(value, nameof(IsAuthorized));
        }
    }
}
