using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK
{
    public static class ErrorCodes
    {
        public const int None = 0;

        public const int UnknownErrorOccurred = 1;                   ////Unknown error occurred.

        public const int ApplicationIsDisabled = 2;                  ////Application is disabled. Enable your application or use test mode.

        public const int UnknownMethodPassed = 3;                    //Unknown method passed

        public const int IncorrectSignature = 4;                     //Incorrect signature.

        public const int UserAuthorizationFailed = 5;                //User authorization failed.

        public const int TooManyRequests = 6;                        //Too many requests per second.

        public const int PermissionDeniedByUser = 7;                 //Permission to perform this action is denied by user.

        public const int FloodControlIsEnabled = 9;                  //Flood control enabled for this action.

        public const int CaptchaIsNeeded = 14;                       //Captcha is needed

        public const int UserAudiosAccessDenied = 15;                //Access denied:  Access to users audio is denied

        public const int InvalidParameters = 100;                    //One of the parameters specified was missing or invalid.

        public const int InvalidScore = 112;                         //Invalid score.

        public const int InvalidUserId = 113;                        //Invalid user id.

        public const int InvalidMessage = 120;                       //Invalid message

        public const int InvalidGroupId = 125;                       //Invalid group id.

        public const int AccessDenied = 201;                         //Access denied.

        public const int CacheExpired = 202;                         //Cache is expired

        public const int AccessToGroupDenied = 203;                  //Access to the group is denied.

        public const int AccessToSubscriptionsDenied = 240;          //Access to subscriptions or followers list denied.

        public static string GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case None:
                    return string.Format(VkLocalization.Culture, VkLocalization.Success);
                case ApplicationIsDisabled:
                    return string.Format(VkLocalization.Culture, VkLocalization.ApplicationIsDisabled);
                case UnknownMethodPassed:
                    return string.Format(VkLocalization.Culture, VkLocalization.UnknownMethodPassed);
                case IncorrectSignature:
                    return string.Format(VkLocalization.Culture, VkLocalization.IncorrectSignature);
                case UserAuthorizationFailed:
                    return string.Format(VkLocalization.Culture, VkLocalization.UserAuthorizationFailed);
                case TooManyRequests:
                    return string.Format(VkLocalization.Culture, VkLocalization.TooManyRequests);
                case PermissionDeniedByUser:
                    return string.Format(VkLocalization.Culture, VkLocalization.PermissionDeniedByUser);
                case FloodControlIsEnabled:
                    return string.Format(VkLocalization.Culture, VkLocalization.FloodControlIsEnabled);
                case CaptchaIsNeeded:
                    return string.Format(VkLocalization.Culture, VkLocalization.CaptchaIsNeeded);
                case UserAudiosAccessDenied:
                    return string.Format(VkLocalization.Culture, VkLocalization.UserAudiosAccessDenied);
                case InvalidParameters:
                    return string.Format(VkLocalization.Culture, VkLocalization.InvalidParameters);
                case InvalidScore:
                    return string.Format(VkLocalization.Culture, VkLocalization.InvalidScore);
                case InvalidUserId:
                    return string.Format(VkLocalization.Culture, VkLocalization.InvalidUserId);
                case InvalidMessage:
                    return string.Format(VkLocalization.Culture, VkLocalization.InvalidMessage);
                case InvalidGroupId:
                    return string.Format(VkLocalization.Culture, VkLocalization.InvalidGroupId);
                case AccessDenied:
                    return string.Format(VkLocalization.Culture, VkLocalization.AccessDenied);
                case AccessToGroupDenied:
                    return string.Format(VkLocalization.Culture, VkLocalization.AccessToGroupDenied);
                case AccessToSubscriptionsDenied:
                    return string.Format(VkLocalization.Culture, VkLocalization.AccessToSubscriptionsDenied);
                case CacheExpired:
                    return string.Format(VkLocalization.Culture, VkLocalization.CacheExpired);
                case UnknownErrorOccurred:
                    return string.Format(VkLocalization.Culture, VkLocalization.UnknownErrorOccurred);
                default:
                    return string.Format(VkLocalization.Culture, VkLocalization.UnknownErrorCode, errorCode);
            }
        }
    }
}
