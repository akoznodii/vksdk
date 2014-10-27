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
        Docs = 32,
        Notes = 64,
        Pages = 128,
        Status = 256,
        Offers = 512,
        Questions = 1024,
        Wall = 2048,
        Groups = 4096,
        Messages = 8192,
        Notifications = 32768,
        Stats = 131072,
        Ads = 262144,
        Offline = 524288,
        NoHttps = 1048576,
    }
}
