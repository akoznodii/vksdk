using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VK.Groups
{
    public class Group
    {
        public Group()
            : this(null)
        {
        }

        public Group(IDictionary<GroupFields, string> fields)
        {
            Fields = new ReadOnlyDictionary<GroupFields, string>(fields);
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string ScreenName { get; set; }

        public bool IsClosed { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsMember { get; set; }

        public GroupType GroupType { get; set; }

        public string Photo50 { get; set; }
        
        public string Photo100 { get; set; }

        public string Photo200 { get; set; }

        public ReadOnlyDictionary<GroupFields, string> Fields { get; private set; }
    }
}
