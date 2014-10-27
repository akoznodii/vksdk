using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using VK.Collections;
using VK.Xml;

namespace VK.Users
{
    public class UsersMethods
    {
        private readonly VkClient _vkClient;

        public UsersMethods(VkClient vkClient)
        {
            _vkClient = vkClient;
        }

        public User Get(UserFields fields = UserFields.None, NameCase nameCase = NameCase.Nominative)
        {
            return Get(_vkClient.UserId, fields, nameCase);
        }

        public User Get(long id, UserFields fields = UserFields.None, NameCase nameCase = NameCase.Nominative)
        {
            return Get(new[] { id }, fields, nameCase).Single();
        }

        public VkCollection<User> Get(ICollection<long> ids, UserFields fields = UserFields.None, NameCase nameCase = NameCase.Nominative)
        {
            if (ids == null || !ids.Any())
            {
                throw new ArgumentNullException("ids");
            }

            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.UsersGet)
                                          .PutParameter(VkConstants.UserIds, ids)
                                          .PutParameter(VkConstants.Fields, fields.GetNames(), false)
                                          .PutParameter(VkConstants.NameCase, nameCase.GetNameCase());

            var document = _vkClient.ExecuteRequest(requestBuilder);

            return document.Root
                           .GetDescendants(VkConstants.UserType)
                           .Select(UsersHelper.GetUser)
                           .ToVkCollection();
        }
    }
}
