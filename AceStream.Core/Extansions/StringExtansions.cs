using System;
using System.Text.RegularExpressions;

namespace AceStream.Core.Extansions
{
    public static class StringExtansions
    {
        public static string Split(this string value, int element)
        {
            return value.Split(new string[] { ". " }, StringSplitOptions.None)[element];
        }

        public static string Clear(this string value)
        {
            return Regex.Replace(value.Replace("/", ""), @"[\d-]", string.Empty).Trim();
        }
    }
}
