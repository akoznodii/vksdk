using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.OAuth
{
    [Flags]
    public enum AccessRights
    {
        Notify = 1,
        Friends = 2,
        Photos = 4,
        Audio = 8,
        Video = 16,
        Docs = 131072,
        Notes = 2048,
        Pages = 128,
        Status = 1024,
        Offers = 32,
        Questions = 64,
        Wall = 8192,
        Groups = 262144,
        Messages = 4096,
        Email = 4194304,
        Notifications = 524288,
        Stats = 1048576,
        Ads = 32768,
        Offline = 65536,
        NoHttps = 256,
    }
}
