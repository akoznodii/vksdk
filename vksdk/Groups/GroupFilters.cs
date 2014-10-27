using System;
using System.Collections.Generic;
using System.Linq;
using VK.Common;

namespace VK.Groups
{
    [Flags]
    public enum GroupFilters
    {
        None = 0x1,
        Admin = 0x2,
        Editor = 0x4,
        Moderator = 0x8,
        Groups = 0x10,
        Publics = 0x20,
        Events = 0x40
    }

    public static class GroupFiltersExtensions
    {
        public static IEnumerable<string> GetNames(this GroupFilters fields)
        {
            return fields.HasFlag(GroupFilters.None)
                ? Enumerable.Empty<string>()
                : fields.GetFieldValues<GroupFilters>().Select(GetName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "It is OK")]
        public static string GetName(this GroupFilters filters)
        {
            switch (filters)
            {
                case GroupFilters.None:
                    return string.Empty;
                case GroupFilters.Admin:
                    return VkConstants.Admin;
                case GroupFilters.Editor:
                    return VkConstants.Editor;
                case GroupFilters.Moderator:
                    return VkConstants.Moderator;
                case GroupFilters.Groups:
                    return VkConstants.Groups;
                case GroupFilters.Publics:
                    return VkConstants.Publics;
                case GroupFilters.Events:
                    return VkConstants.Events;
                default:
                    throw new ArgumentOutOfRangeException("filters");
            }
        }
    }
}
