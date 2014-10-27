using System;
using System.Linq;
using System.Xml.Linq;
using VK.Collections;
using VK.Common;
using VK.Xml;

namespace VK.Groups
{
    public class GroupsMethods
    {
        private static readonly GroupFields[] FieldNames = EnumExtensions.GetFields(new[] { GroupFields.None }).ToArray();

        private readonly VkClient _vkClient;

        public GroupsMethods(VkClient vkClient)
        {
            _vkClient = vkClient;
        }

        public VkCollection<Group> Get(int count = 0, int offset = 0, GroupFilters filters = GroupFilters.None, GroupFields fields = GroupFields.None)
        {
            return Get(_vkClient.UserId, count, offset, filters, fields);
        }

        public VkCollection<Group> Get(long userId, int count = 0, int offset = 0, GroupFilters filters = GroupFilters.None, GroupFields fields = GroupFields.None)
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.GroupsGet)
                                          .PutParameter(VkConstants.Extended, true)
                                          .PutParameter(VkConstants.Filter, filters.GetNames(), false)
                                          .PutParameter(VkConstants.Fields, fields.GetNames(), false);

            if (userId > 0)
            {
                requestBuilder.PutParameter(VkConstants.UserId, userId);
            }

            if (count > 0)
            {
                requestBuilder.PutParameter(VkConstants.Count, count);
            }

            if (offset > 0)
            {
                requestBuilder.PutParameter(VkConstants.Offset, offset);
            }

            var document = _vkClient.ExecuteRequest(requestBuilder);

            var responseCount = document.Root.GetInt32(VkConstants.Count);

            var collection = document.Root
                                     .GetDescendants(VkConstants.Group)
                                     .Select(GetGroup)
                                     .ToVkCollection();

            collection.ResponseCount = responseCount;
            collection.Offset = offset;

            return collection;
        }

        private static Group GetGroup(XElement element)
        {
            var fields = (from field in FieldNames
                          let name = field.GetName()
                          let value = element.FindString(name)
                          where !string.IsNullOrEmpty(value)
                          select new { field, value })
                          .ToDictionary(i => i.field, i => i.value);

            var group = new Group(fields)
            {
                Id = element.GetInt64(VkConstants.Id),
                Name = element.GetString(VkConstants.Name),
                ScreenName = element.GetString(VkConstants.ScreenName),
                Photo50 = element.GetString(VkConstants.Photo50),
                Photo100 = element.GetString(VkConstants.Photo100),
                Photo200 = element.GetString(VkConstants.Photo200),
                IsAdmin = element.FindBoolean(VkConstants.IsAdmin),
                IsMember = element.FindBoolean(VkConstants.IsMember),
                IsClosed = element.FindBoolean(VkConstants.IsClosed),
                GroupType = GroupTypeExtensions.GetName(element.GetString(VkConstants.Type))
            };

            return group;
        }
    }
}
