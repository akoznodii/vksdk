using System;

namespace VK.Friends
{
    public enum OrderType
    {
        Name,
        Hints,
        Random,
        Mobile
    }

    public static class OrderTypeExtensions
    {
        public static string GetName(this OrderType orderType)
        {
            switch (orderType)
            {
                case OrderType.Name:
                    return VkConstants.Name;
                case OrderType.Hints:
                    return VkConstants.Hints;
                case OrderType.Random:
                    return VkConstants.Random;
                case OrderType.Mobile:
                    return VkConstants.Mobile;
                default:
                    throw new ArgumentOutOfRangeException("orderType");
            }
        }
    }
}
