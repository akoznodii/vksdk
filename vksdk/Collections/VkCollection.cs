using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace VK.Collections
{
    public class VkCollection<T> : ReadOnlyCollection<T>
    {
        public VkCollection(IEnumerable<T> items)
            : base(items.ToArray())
        {
        }

        public int ResponseCount { get; set; }

        public int Offset { get; set; }
    }
}
