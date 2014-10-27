using System;
using System.Runtime.Serialization;

namespace VK
{
    [Serializable]
    public class VkApiException : Exception
    {
        public VkApiException()
        {
        }

        public VkApiException(string message)
            : base(message)
        {
        }

        public VkApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public VkApiException(int errorCode) :
            base(ErrorCodes.GetErrorMessage(errorCode))
        {
            ErrorCode = errorCode;
        }

        protected VkApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public int ErrorCode { get; private set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            ErrorCode = info.GetInt32("ErrorCode");
        }
    }
}
