using Foundation;

namespace AceStream.Utils
{
    public  class ChampionatData
    {
        public  string Data
        {
            get => NSUserDefaults.StandardUserDefaults.StringForKey(nameof(Data));
            set => NSUserDefaults.StandardUserDefaults.SetString(value, nameof(Data));
        }
    }
}
