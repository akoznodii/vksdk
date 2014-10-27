using System;
using System.Net;
using System.Xml.Linq;
using VK.Audios;
using VK.Common;
using VK.Friends;
using VK.Groups;
using VK.OAuth;
using VK.Users;
using VK.Xml;

namespace VK
{
    public class VkClient
    {
        private readonly UsersMethods _usersMethods;
        private readonly AudiosMethods _audiosMethods;
        private readonly FriendsMethods _friendsMethods;
        private readonly GroupsMethods _groupsMethods;

        public VkClient(long applicationId, AccessRights accessRights)
        {
            ApplicationId = applicationId;
            AccessRights = accessRights;
            ApiHost = VkConfiguration.ApiHost;
            ApiVersion = VkConfiguration.ApiVersion;

            _usersMethods = new UsersMethods(this);
            _audiosMethods = new AudiosMethods(this);
            _friendsMethods = new FriendsMethods(this);
            _groupsMethods = new GroupsMethods(this);
        }

        public long ApplicationId { get; private set; }

        public AccessRights AccessRights { get; private set; }

        public AccessToken AccessToken { get; set; }

        public string ApiHost { get; private set; }

        public string ApiVersion { get; private set; }

        public Func<Captcha, bool> CaptchaCallback { get; set; }

        public UsersMethods Users { get { return _usersMethods; } }

        public AudiosMethods Audios { get { return _audiosMethods; } }

        public FriendsMethods Friends { get { return _friendsMethods; } }

        public GroupsMethods Groups { get { return _groupsMethods; } }

        public long UserId
        {
            get
            {
                VerifyAccessToken();

                return AccessToken.UserId;
            }
        }

        public RequestBuilder CreateRequestBuilder()
        {
            return new RequestBuilder().PutHost(ApiHost);
        }

        public RequestBuilder CreateRequestBuilder(string method)
        {
            return CreateRequestBuilder().PutMethod(method);
        }

        public XDocument ExecuteRequest(RequestBuilder requestBuilder)
        {
            requestBuilder.PutParameter(VkConstants.Version, ApiVersion);

            VerifyAccessToken();

            requestBuilder.SignRequest(AccessToken.Value);

            var document = LoadDocument(requestBuilder);

            var errorCode = GetErrorCode(document.Root);

            if (errorCode != 0)
            {
                if (errorCode == ErrorCodes.CaptchaIsNeeded && CaptchaCallback != null)
                {
                    document = ReloadDocumentWithCaptcha(requestBuilder, document.Root);
                }
                else
                {
                    throw new VkApiException(errorCode);
                }
            }

            return document;
        }

        private void VerifyAccessToken()
        {
            if (AccessToken == null)
            {
                throw new InvalidOperationException(VkLocalization.AccessTokenNotProvided);
            }

            if (AccessToken.Expired())
            {
                throw new UnauthorizedAccessException(VkLocalization.AccessTokenHasExpired);
            }
        }

        private XDocument ReloadDocumentWithCaptcha(RequestBuilder requestBuilder, XElement element)
        {
            var captcha = new Captcha()
            {
                Sid = element.GetString(VkConstants.CaptchaSid),
                Image = element.GetString(VkConstants.CaptchaImage),
            };

            while (true)
            {
                if (!CaptchaCallback(captcha))
                {
                    throw new VkApiException(ErrorCodes.CaptchaIsNeeded);
                }

                requestBuilder.PutCaptcha(captcha.Sid, captcha.Key);

                var document = LoadDocument(requestBuilder);

                var errorCode = GetErrorCode(document.Root);

                if (errorCode == ErrorCodes.CacheExpired ||
                    errorCode == ErrorCodes.CaptchaIsNeeded)
                {
                    captcha.Sid = document.Root.GetString(VkConstants.CaptchaSid);
                    captcha.Sid = document.Root.GetString(VkConstants.CaptchaImage);
                    continue;
                }

                if (errorCode != 0)
                {
                    throw new VkApiException(errorCode);
                }

                return document;
            }
        }

        private static XDocument LoadDocument(RequestBuilder requestBuilder)
        {
            var request = CreateHttpWebRequest(requestBuilder.ToString());

            var response = request.GetResponse();

            using (var stream = response.GetResponseStream())
            {
                return XDocument.Load(stream);
            }
        }

        private static HttpWebRequest CreateHttpWebRequest(string url)
        {
            var request = WebRequest.CreateHttp(new Uri(url));

            request.Method = "GET";
            request.Proxy = null;

            return request;
        }

        private static int GetErrorCode(XElement element)
        {
            if (element.Name.LocalName != VkConstants.ErrorType)
            {
                return 0;
            }

            return element.GetInt32(VkConstants.ErrorCode);
        }
    }
}
