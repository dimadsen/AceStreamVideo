using System;
namespace AceStream.Core.Extansions
{
    public static class StringExtansions
    {
        public static string Split(this string value, int element)
        {
            return value.Split(new string[] { ". " }, StringSplitOptions.None)[element];
        }
    }
}
