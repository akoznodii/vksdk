using System.Collections.Generic;

namespace VK.Collections
{
    public static class CollectionExtensions
    {
        public static VkCollection<T> ToVkCollection<T>(this IEnumerable<T> items)
        {
            return new VkCollection<T>(items);
        }
    }
}
