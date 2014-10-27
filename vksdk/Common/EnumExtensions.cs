using System;
using System.Collections.Generic;
using System.Linq;

namespace VK.Common
{
    public static class EnumExtensions
    {
        public static IEnumerable<TEnum> GetFieldValues<TEnum>(this Enum flag)
        {
            if (!(flag is TEnum))
            {
                throw new InvalidOperationException("Not appropriate flag");
            }

            return Enum.GetValues(typeof(TEnum))
                       .Cast<Enum>()
                       .Where(flag.HasFlag)
                       .Cast<TEnum>();
        }

        public static IEnumerable<TEnum> GetFields<TEnum>(IEnumerable<TEnum> excludeFields)
        {
            return Enum.GetValues(typeof(TEnum))
                        .Cast<TEnum>()
                        .Except(excludeFields);
        }
    }
}
