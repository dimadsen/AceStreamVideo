using Foundation;

namespace AceStream.Utils
{
    public static class ChampionatData
    {
        public static string Data
        {
            get => NSUserDefaults.StandardUserDefaults.StringForKey(nameof(Data));
            set => NSUserDefaults.StandardUserDefaults.SetString(value, nameof(Data));
        }
    }
}
