using System;
using VK.Xml;

namespace VK.Statistics
{
    public class StatisticsMethods
    {
        private readonly VkClient _vkClient;

        public StatisticsMethods(VkClient vkClient)
        {
            _vkClient = vkClient;
        }

        public void TrackVisitor()
        {
            var requestBuilder = _vkClient.CreateRequestBuilder(VkConstants.StatsTrackVisitor);

            var document = _vkClient.ExecuteRequest(requestBuilder);

            var result = document.Root.GetInt32();

            if (result != 1)
            {
                throw new InvalidOperationException(VkLocalization.UnknownErrorOccurred);
            }
        }
    }
}
