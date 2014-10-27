using System;

namespace VK.Audios
{
    public enum OwnerType
    {
        User,
        Group
    }

    internal static class OwnerTypeHelper
    {
        public static long ToOwnerId(this long ownerId, OwnerType ownerType)
        {
            if (ownerId == 0)
            {
                throw new InvalidOperationException("Owner id cannot equal zero");
            }

            if (ownerType == OwnerType.User)
            {
                return ownerId > 0 ? ownerId : -1 * ownerId;
            }
            else
            {
                return ownerId > 0 ? -1 * ownerId : ownerId;
            }
        }

        public static OwnerType GetOwnerType(this long ownerId)
        {
            if (ownerId == 0)
            {
                throw new InvalidOperationException("Owner id cannot equal zero");
            }

            return ownerId > 0 ? OwnerType.User : OwnerType.Group;
        }
    }
}
