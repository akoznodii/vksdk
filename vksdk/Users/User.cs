using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VK.Users
{
    public class User
    {
        public User()
            : this(null)
        {
        }

        public User(IDictionary<UserFields, string> fields)
        {
            Fields = new ReadOnlyDictionary<UserFields, string>(fields);
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public ReadOnlyDictionary<UserFields, string> Fields { get; private set; }
    }
}
