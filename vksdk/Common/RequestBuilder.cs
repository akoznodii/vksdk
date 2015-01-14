using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VK.Common
{
    public class RequestBuilder
    {
        private readonly StringBuilder _stringBuilder;

        public RequestBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public RequestBuilder PutHost(string hostAddress)
        {
            if (string.IsNullOrEmpty(hostAddress))
            {
                throw new ArgumentNullException("hostAddress");
            }

            if (_stringBuilder.Length != 0)
            {
                throw new InvalidOperationException("Request string is not empty");
            }

            _stringBuilder.Append(hostAddress);

            return this;
        }

        public RequestBuilder PutEndpoint(string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentNullException("endpoint");
            }

            if (_stringBuilder.Length == 0)
            {
                throw new InvalidOperationException("Request string is empty");
            }

            _stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "/{0}?", endpoint);

            return this;
        }

        public RequestBuilder PutMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
            {
                throw new ArgumentNullException("method");
            }

            if (_stringBuilder.Length == 0)
            {
                throw new InvalidOperationException("Request string is empty");
            }

            _stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "/{0}/{1}.xml?", VkConstants.Method, method);

            return this;
        }

        public RequestBuilder PutParameter<T>(string name, IEnumerable<T> values, bool isRequired = true)
        {
            var value = string.Join(",", values);

            if (!isRequired && string.IsNullOrEmpty(value))
            {
                return this;
            }

            return PutParameter(name, value);
        }

        public RequestBuilder PutParameter(string name, int value)
        {
            return PutParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        public RequestBuilder PutParameter(string name, bool value)
        {
            return PutParameter(name, value ? 1 : 0);
        }

        public RequestBuilder PutParameter(string name, long value)
        {
            return PutParameter(name, value.ToString(CultureInfo.InvariantCulture));
        }

        public RequestBuilder PutParameter(string name, Enum value)
        {
            return PutParameter(name, value.ToString("d"));
        }

        public RequestBuilder PutParameter(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            if (_stringBuilder.Length == 0)
            {
                throw new InvalidOperationException("Request string is empty");
            }

            var index = _stringBuilder.Length - 1;

            if (_stringBuilder[index] != '?' && _stringBuilder[index] != '&')
            {
                _stringBuilder.Append('&');
            }

            _stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}", name, value);
            
            return this;
        }

        public RequestBuilder UpdateParameter(string name, string value)
        {
            var reuest = ToString();

            var startIndex = reuest.IndexOf(name, StringComparison.OrdinalIgnoreCase);

            if (startIndex == -1)
            {
                throw new InvalidOperationException("Parameter was not found");
            }

            var lastIndex = reuest.LastIndexOf('&');
            var endIndex = lastIndex > startIndex ? lastIndex - 1 : reuest.Length;

            var insert = string.Format(CultureInfo.InvariantCulture, "{0}={1}", name, value);
            _stringBuilder.Remove(startIndex, endIndex - startIndex);
            _stringBuilder.Insert(startIndex, insert);

            return this;
        }

        public RequestBuilder SignRequest(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException("accessToken");
            }

            return PutParameter(VkConstants.AccessToken, accessToken);
        }

        public RequestBuilder PutCaptcha(string sid, string key)
        {
            if (string.IsNullOrEmpty(sid))
            {
                throw new ArgumentNullException("sid");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            return this.PutParameter(VkConstants.CaptchaSid, sid)
                       .PutParameter(VkConstants.CaptchaKey, key);
        }

        public RequestBuilder UpdateCaptcha(string sid, string key)
        {
            if (string.IsNullOrEmpty(sid))
            {
                throw new ArgumentNullException("sid");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            return this.UpdateParameter(VkConstants.CaptchaSid, sid)
                       .UpdateParameter(VkConstants.CaptchaKey, key);
        }
        
        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
