using System;
using System.ComponentModel;

namespace AceStream.Core.Extansions
{
    public static class EnumExtansion
    {
        public static string GetDescription<T>(this T type) where T : Enum
        {
            var name = Enum.GetName(typeof(T), type);

            var property = typeof(T).GetField(name);
            var attribute = property.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
            var description = ((DescriptionAttribute)attribute).Description;
            
            return description;
        }
    }
}
