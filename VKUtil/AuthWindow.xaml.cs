using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VkAPILib;

namespace VkUtil
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private const string _access_token = "access_token";
        private const string _user_id = "user_id";
        private const string _email = "email";

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var appId = VkApiLib.AppId;
            var scope = VkApiLib.Scope;
            var apiVer = VkApiLib.ApiVer;
            var url = new Uri($"https://oauth.vk.com/authorize?client_id={appId}&scope={scope}&redirect_uri=https://oauth.vk.com/blank.html&display=page&v={apiVer}&response_type=token");
            webBrowser1.Navigate(url);
        }

        private void webBrowser1_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var url = webBrowser1.Source;

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
