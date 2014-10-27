using System;
using System.Collections.Generic;
using System.Linq;
using VK.Common;

namespace VK.Users
{
    [Flags]
    public enum UserFields
    {
        None = 0x1,
        Nickname = 0x2,
        Domain = 0x4,
        Sex = 0x8,
        Birthdate = 0x10,
        City = 0x20,
        Country = 0x40,
        TimeZone = 0x80,
        Photo50 = 0x100,
        Photo100 = 0x200,
        Photo200 = 0x400,
        Photo200Original = 0x800,
        HasMobile = 0x1000,
        Contacts = 0x2000,
        Education = 0x4000,
        Online = 0x8000,
        Relation = 0x10000,
        LastSeen = 0x20000,
        Status = 0x40000,
        CanWritePrivateMessage = 0x80000,
        CanSeeAllPosts = 0x100000,
        CanPost = 0x200000,
        University = 0x400000
    }

    public static class UserFieldsExtensions
    {
        public static IEnumerable<string> GetNames(this UserFields userFields)
        {
            return userFields.HasFlag(UserFields.None)
                ? Enumerable.Empty<string>()
                : userFields.GetFieldValues<UserFields>().Select(GetName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "It is OK")]
        public static string GetName(this UserFields userField)
        {
            switch (userField)
            {
                case UserFields.None:
                    return string.Empty;
                case UserFields.Nickname:
                    return VkConstants.Nickname;
                case UserFields.Sex:
                    return VkConstants.Sex;
                case UserFields.Birthdate:
                    return VkConstants.Birthdate;
                case UserFields.City:
                    return VkConstants.City;
                case UserFields.Country:
                    return VkConstants.Country;
                case UserFields.TimeZone:
                    return VkConstants.TimeZone;
                case UserFields.Photo50:
                    return VkConstants.Photo50;
                case UserFields.Photo100:
                    return VkConstants.Photo100;
                case UserFields.Photo200:
                    return VkConstants.Photo200;
                case UserFields.Domain:
                    return VkConstants.Domain;
                case UserFields.HasMobile:
                    return VkConstants.HasMobile;
                case UserFields.Contacts:
                    return VkConstants.Contacts;
                case UserFields.Education:
                    return VkConstants.Education;
                case UserFields.University:
                    return VkConstants.Universities;
                case UserFields.Photo200Original:
                    return VkConstants.Photo200Original;
                case UserFields.Online:
                    return VkConstants.Online;
                case UserFields.Relation:
                    return VkConstants.Relation;
                case UserFields.LastSeen:
                    return VkConstants.LastSeen;
                case UserFields.Status:
                    return VkConstants.Status;
                case UserFields.CanWritePrivateMessage:
                    return VkConstants.CanWritePrivateMessage;
                case UserFields.CanSeeAllPosts:
                    return VkConstants.CanSeeAllPosts;
                case UserFields.CanPost:
                    return VkConstants.CanPost;
                default:
                    throw new ArgumentOutOfRangeException("userField");
            }
        }
    }
}
