using System;

namespace VK.OAuth
{
    [Serializable]
    public class AccessToken
    {
        public AccessToken(long userId, string value, double secondsLifetime)
            : this(userId, value, TimeSpan.FromSeconds(secondsLifetime))
        {
        }

        public AccessToken(long userId, string value, TimeSpan lifetime)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            CreateTime = DateTime.UtcNow;
            UserId = userId;
            Value = value;
            Lifetime = lifetime;
        }

        public long UserId { get; private set; }

        public string Value { get; private set; }

        public TimeSpan Lifetime { get; private set; }

        public DateTime CreateTime { get; private set; }

        public bool Expired()
        {
            return DateTime.Now > CreateTime.Add(Lifetime);
        }
    }
}
