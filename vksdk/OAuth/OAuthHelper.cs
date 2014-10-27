using System;
using System.Globalization;
using System.Text.RegularExpressions;
using VK.Common;

namespace VK.OAuth
{
    public static class OAuthHelper
    {
        private const string Name = "name";
        private const string Value = "value";
        private const string Pattern = @"(?<name>[\w\d]+)=(?<value>[^&\s]+)";
        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Uri GetLoginUri(long applicationId, AccessRights rights, string host = null, string redirect = null, DisplayMode display = DisplayMode.Popup, bool isStandAlone = true)
        {
            if (string.IsNullOrEmpty(host))
            {
                host = VkConfiguration.AuthHost;
            }

            if (string.IsNullOrEmpty(redirect))
            {
                redirect = VkConfiguration.VkRedirectAuthAddress;
            }

            var uriString = GetLoginUrl(applicationId, rights, host, redirect, display, isStandAlone);

            return new Uri(uriString, UriKind.Absolute);
        }

        public static Uri GetLogoutUri(string host = null)
        {
            var builder = new RequestBuilder();

            if (string.IsNullOrEmpty(host))
            {
                host = VkConfiguration.MainHost;
            }

            builder.PutHost(host).PutEndpoint("oauth/logout");

            return new Uri(builder.ToString());
        }

        public static AccessToken RetrieveAccessToken(Uri redirectedUri)
        {
            if (redirectedUri == null)
            {
                throw new ArgumentNullException("redirectedUri");
            }

            var matches = Regex.Matches(redirectedUri.AbsoluteUri);

            if (matches.Count == 0)
            {
                throw new InvalidOperationException(string.Format(VkLocalization.Culture, VkLocalization.NoMatchesFoundInResponse));
            }

            var token = string.Empty;
            var userId = 0L;
            var lifetime = 0d;
            var errorMessage = string.Empty;
            var errorCode = 0;

            foreach (Match match in matches)
            {
                switch (match.Groups[Name].Value)
                {
                    case VkConstants.AccessToken:
                        token = match.Groups[Value].Value;
                        break;
                    case VkConstants.ExpiresIn:
                        lifetime = double.Parse(match.Groups[Value].Value, CultureInfo.InvariantCulture);
                        break;
                    case VkConstants.AuthUserId:
                        userId = long.Parse(match.Groups[Value].Value, CultureInfo.InvariantCulture);
                        break;
                    case VkConstants.ErrorReason:
                    case VkConstants.ErrorType:
                    case VkConstants.ErrorDescription:
                        errorMessage = Uri.UnescapeDataString(match.Groups[Value].Value);
                        break;
                    case VkConstants.ErrorInResponse:
                        errorCode = Int32.Parse(match.Groups[Value].Value, CultureInfo.InvariantCulture);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new VkApiException(errorMessage);
            }

            if (errorCode != 0)
            {
                throw new VkApiException(errorCode);
            }

            if (!string.IsNullOrEmpty(token) && userId != 0 && lifetime > 0)
            {
                return new AccessToken(userId, token, lifetime);
            }

            throw new InvalidOperationException(string.Format(VkLocalization.Culture, VkLocalization.NotAllRequiredMatchesFoundInResponse));
        }

        public static bool CanRetrieveToken(Uri uri)
        {
            return uri != null && uri.AbsoluteUri.StartsWith(VkConfiguration.VkRedirectAuthAddress, StringComparison.OrdinalIgnoreCase);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "I need a lowercase, not upper!")]
        private static string GetLoginUrl(long applicationId, AccessRights rights, string host, string redirect, DisplayMode display, bool isStandalone)
        {
            if (applicationId < 1 ||
                string.IsNullOrEmpty(host) ||
                string.IsNullOrEmpty(redirect))
            {
                throw new InvalidOperationException(string.Format(VkLocalization.Culture, VkLocalization.InvalidInputParameters));
            }

            var builder = new RequestBuilder();

            builder.PutHost(host)
                   .PutEndpoint(VkConstants.Authorize)
                   .PutParameter(VkConstants.ApplicationId, applicationId)
                   .PutParameter(VkConstants.RedirectUri, redirect)
                   .PutParameter(VkConstants.ScopeMode, rights)
                   .PutParameter(VkConstants.DisplayName, display.ToString().ToLowerInvariant());

            if (isStandalone)
            {
                builder.PutParameter(VkConstants.ResponseTypeParameter, VkConstants.Token);
            }

            return builder.ToString();
        }
    }
}
