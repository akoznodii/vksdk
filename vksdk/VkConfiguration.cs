using System.Configuration;

namespace VK
{
    public static class VkConfiguration
    {
        static VkConfiguration()
        {
            LoadConfiguration();
        }

        public static string ApiHost
        {
            get; private set;
        }

        public static string ApiVersion
        {
            get { return "5.21"; }
        }

        public static string AuthHost
        {
            get; private set;
        }

        public static string MainHost
        {
            get; private set;
        }

        public static string VkRedirectAuthAddress
        {
            get { return string.Join("/", AuthHost, "blank.html"); }
        }

        public static string SignupAddress
        {
            get { return string.Join("/", MainHost, "join?reg=1"); }
        }

        private static void LoadConfiguration()
        {
            var configFilePath = typeof(VkConfiguration).Assembly.Location;

            var configuration = ConfigurationManager.OpenExeConfiguration(configFilePath);

            AuthHost = GetValue(configuration, "AuthHost");
            ApiHost = GetValue(configuration, "ApiHost");
            MainHost = GetValue(configuration, "MainHost");
        }

        private static string GetValue(Configuration configuration, string name)
        {
            return configuration.AppSettings.Settings[name].Value;
        }
    }
}
