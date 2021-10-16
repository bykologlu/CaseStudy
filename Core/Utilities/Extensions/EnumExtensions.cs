using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Extensions
{
    public static class EnumExtensions
    { 
        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<T>();
        }

        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>().Description.ToString();
            return attribute == null ? value.ToString() : attribute;
        }
    }
}
