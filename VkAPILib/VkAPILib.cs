using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VkAPILib
{
    public class VkApiLib
    {
        static VkApiLib()
        {
            var token = ConfigurationManager.AppSettings["AccessToken"];
            var userId = ConfigurationManager.AppSettings["UserId"];
            var email = ConfigurationManager.AppSettings["Email"];
            var appId = ConfigurationManager.AppSettings["AppId"];
            var scope = ConfigurationManager.AppSettings["Scope"];
            var apiVer = ConfigurationManager.AppSettings["ApiVer"];

            if (!string.IsNullOrEmpty(token))
            {
                AccessToken = token;
            }

            if (!string.IsNullOrEmpty(userId))
            {
                UserId = userId;
            }

            if (!string.IsNullOrEmpty(appId))
            {
                AppId = appId;
            }

            if (!string.IsNullOrEmpty(scope))
            {
                Scope = scope;
            }

            if (!string.IsNullOrEmpty(apiVer))
            {
                ApiVer = apiVer;
            }
        }

        private static string _accessToken;
        private static string _userId;
        private static string _email;

        public static string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Email"]))
                {
                    ConfigurationManager.AppSettings.Set("Email", value);
                }
            }
        }

        public static string AccessToken
        {
            get { return _accessToken; }
            set
            {
                _accessToken = value;
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["AccessToken"]))
                {
                    ConfigurationManager.AppSettings.Set("AccessToken", value);
                }
            }
        }

        public static string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["UserId"]))
                {
                    ConfigurationManager.AppSettings.Set("UserId", value);
                }
            }
        }

        public static string AppId { get; private set; } = string.Empty;

        public static string Scope { get; private set; } = string.Empty;

        public static string ApiVer { get; private set; } = string.Empty;

        public static void GetHistoryWith(string userId)
        {
            
        }

    }
}
