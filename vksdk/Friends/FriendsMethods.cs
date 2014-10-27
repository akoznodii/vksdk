using System.Linq;
using VK.Collections;
using VK.Users;
using VK.Xml;

namespace VK.Friends
{
    public class FriendsMethods
    {
        private readonly VkClient _vkClient;

        public FriendsMethods(VkClient vkClient)
        {
            _vkClient = vkClient;
        }

        public VkCollection<User> Get(int count = 0, int offset = 0, OrderType orderType = OrderType.Hints, UserFields fields = UserFields.None, NameCase nameCase = NameCase.Nominative)
        {
            return Get(_vkClient.UserId, count, offset, orderType, fields, nameCase);
        }

        public VkCollection<User> Get(long userId, int count = 0, int offset = 0, OrderType orderType = OrderType.Hints, UserFields fields = UserFields.None, NameCase nameCase = NameCase.Nominative)
        {
            if (fields == UserFields.None)
            {
                fields = UserFields.Photo50;
            }

            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.FriendsGet)
                                          .PutParameter(VkConstants.Order, orderType.GetName())
                                          .PutParameter(VkConstants.Fields, fields.GetNames(), false)
                                          .PutParameter(VkConstants.NameCase, nameCase.GetNameCase());

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
                                     .GetDescendants(VkConstants.UserType)
                                     .Select(UsersHelper.GetUser)
                                     .ToVkCollection();

            collection.ResponseCount = responseCount;
            collection.Offset = offset;

            return collection;
        }
    }
}
