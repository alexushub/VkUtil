using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkAPILib;

namespace VKAuthorizer
{
    public partial class AuthForm : Form
    {
        private const string _access_token = "access_token";
        private const string _user_id = "user_id";
        private const string _email = "email";

        public AuthForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var appId = VkApiLib.AppId;
            var scope = VkApiLib.Scope;
            var apiVer = VkApiLib.ApiVer;
            var url = new Uri($"https://oauth.vk.com/authorize?client_id={appId}&scope={scope}&redirect_uri=https://oauth.vk.com/blank.html&display=page&v={apiVer}&response_type=token");
            webBrowser1.Navigate(url);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var url = webBrowser1.Url;

            if (url.ToString().Contains("access_token="))
            {
                var str = url.Fragment;
                var splitted = str.Split('&', '=', '#').ToList();

                var token = splitted[splitted.IndexOf(_access_token) + 1];
                var userId = splitted[splitted.IndexOf(_user_id) + 1];
                var email = splitted[splitted.IndexOf(_email) + 1];

                VkApiLib.AccessToken = token;
                VkApiLib.UserId = userId;
                VkApiLib.Email = email;

                this.Close();
            }
        }
    }
}
