using System;

namespace VK.Groups
{
    public enum GroupType
    {
        Group,
        Page,
        Event
    }

    public static class GroupTypeExtensions
    {
        public static GroupType GetName(string groupType)
        {
            switch (groupType)
            {
                case VkConstants.Group:
                    return GroupType.Group;
                case VkConstants.Page:
                    return GroupType.Page;
                case VkConstants.Event:
                    return GroupType.Event;
                default:
                    throw new ArgumentOutOfRangeException("groupType");
            }
        }
    }
}
