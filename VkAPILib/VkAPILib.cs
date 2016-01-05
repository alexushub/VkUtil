using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Helpers;

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

            if (!string.IsNullOrEmpty(email))
            {
                Email = email;
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
            var req = HttpWebRequest.Create($"https://api.vk.com/method/audio.get?owner_id={UserId}&count=20&v={ApiVer}&access_token={AccessToken}");
            req.Method = WebRequestMethods.Http.Get;
            var resp = req.GetResponse();
            var reader = new StreamReader(resp.GetResponseStream());
            var json = reader.ReadToEnd();

            dynamic data = Json.Decode(json);

            var a = data.Fuck;
        }

        public static List<AudioRecord> SearchAudios(string searchStr)
        {
            var req = HttpWebRequest.Create($"https://api.vk.com/method/audio.search?q={searchStr}&sort=2&count=20&v={ApiVer}&access_token={AccessToken}");
            req.Method = WebRequestMethods.Http.Get;
            var resp = req.GetResponse();
            var reader = new StreamReader(resp.GetResponseStream());
            var json = reader.ReadToEnd();

            dynamic data = Json.Decode(json);
            IEnumerable<dynamic> its = data.response.items;

            var ret = new List<AudioRecord>();

            foreach (var it in its.Where(m => !string.IsNullOrEmpty(m.url)))
            {
                string tit = (it.artist + " - " + it.title).ToString();
                ret.Add(new AudioRecord()
                {
                    Title = tit,
                    Url = new Uri(it.url)
                });
            }

            return ret;
        }

        public class AudioRecord
        {
            public string Title { get; set; }

            public Uri Url { get; set; }
        }
    }
}
