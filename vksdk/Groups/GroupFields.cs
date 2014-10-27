using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Common;

namespace VK.Groups
{
    [Flags]
    public enum GroupFields
    {
        None = 0x1,
        City = 0x2,
        Country = 0x4,
        Place = 0x8,
        Description = 0x10,
        WikiPage = 0x20,
        MembersCount = 0x40,
        Counters = 0x80,
        StartDate = 0x100,
        FinishDate = 0x200,
        CanPost = 0x400,
        CanSeeAllPosts = 0x800,
        Activity = 0x1000,
        Status = 0x2000,
        Contacts = 0x4000,
        Links = 0x8000,
        FixedPost = 0x10000,
        Verified = 0x20000,
        Site = 0x40000,
        CanCreateTopic = 0x80000
    }

    public static class GroupFieldsExtensions
    {
        public static IEnumerable<string> GetNames(this GroupFields fields)
        {
            return fields.HasFlag(GroupFields.None)
                ? Enumerable.Empty<string>()
                : fields.GetFieldValues<GroupFields>().Select(GetName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "It is OK")]
        public static string GetName(this GroupFields fields)
        {
            switch (fields)
            {
                case GroupFields.None:
                    return string.Empty;
                case GroupFields.City:
                    return VkConstants.City;
                case GroupFields.Country:
                    return VkConstants.Country;
                case GroupFields.Place:
                    return VkConstants.Place;
                case GroupFields.Description:
                    return VkConstants.Description;
                case GroupFields.WikiPage:
                    return VkConstants.WikiPage;
                case GroupFields.MembersCount:
                    return VkConstants.MembersCount;
                case GroupFields.Counters:
                    return VkConstants.Counters;
                case GroupFields.StartDate:
                    return VkConstants.StartDate;
                case GroupFields.FinishDate:
                    return VkConstants.FinishDate;
                case GroupFields.CanPost:
                    return VkConstants.CanPost;
                case GroupFields.CanSeeAllPosts:
                    return VkConstants.CanSeeAllPosts;
                case GroupFields.Activity:
                    return VkConstants.Activity;
                case GroupFields.Status:
                    return VkConstants.Status;
                case GroupFields.Contacts:
                    return VkConstants.Contacts;
                case GroupFields.Links:
                    return VkConstants.Links;
                case GroupFields.FixedPost:
                    return VkConstants.FixedPost;
                case GroupFields.Verified:
                    return VkConstants.Verified;
                case GroupFields.Site:
                    return VkConstants.Site;
                case GroupFields.CanCreateTopic:
                    return VkConstants.CanCreateTopic;
                default:
                    throw new ArgumentOutOfRangeException("fields");
            }
        }
    }
}
