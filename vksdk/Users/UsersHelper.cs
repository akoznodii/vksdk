using System.Linq;
using System.Xml.Linq;
using VK.Common;
using VK.Xml;

namespace VK.Users
{
    internal class UsersHelper
    {
        private static readonly UserFields[] FieldNames = EnumExtensions.GetFields(new[] { UserFields.None, UserFields.Photo50 }).ToArray();

        public static User GetUser(XElement element)
        {
            var fields = (from field in FieldNames
                          let name = field.GetName()
                          let value = element.FindString(name)
                          where !string.IsNullOrEmpty(value)
                          select new { field, value })
                          .ToDictionary(i => i.field, i => i.value);

            var user = new User(fields)
            {
                Id = element.GetInt64(VkConstants.Id),
                FirstName = element.GetString(VkConstants.FirstName),
                LastName = element.GetString(VkConstants.LastName),
                Photo = element.GetString(VkConstants.Photo50)
            };

            return user;
        }
    }
}
