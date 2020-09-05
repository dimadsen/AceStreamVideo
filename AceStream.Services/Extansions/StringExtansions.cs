using System;
using System.Text.RegularExpressions;

namespace AceStream.Core.Extansions
{
    public static class StringExtansions
    {
        public static string Split(this string value, int element,string option)
        {
            try
            {
                return value.Split(new string[] { option }, StringSplitOptions.None)[element];
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string Clear(this string value)
        {
            return Regex.Replace(value.Replace("/", ""), @"[\d-]", string.Empty).Trim();
        }
    }
}
