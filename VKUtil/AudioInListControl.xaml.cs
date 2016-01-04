using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VkAPILib;

namespace VkUtil
{
    /// <summary>
    /// Interaction logic for AudioInListControl.xaml
    /// </summary>
    public partial class AudioInListControl : UserControl
    {
        public static string downloadPath = string.Empty;

        //private string downloadedFolderPath = string.Empty;
        private string downloadedFilePath = string.Empty;
        private WebClient wc;

        public AudioInListControl()
        {
            InitializeComponent();
        }

        private void downloadButton_Click(object sender, RoutedEventArgs e)
        {
            downloadButton.IsEnabled = false;
            cancelDownloadButton.IsEnabled = true;

            VkApiLib.AudioRecord audio = (VkApiLib.AudioRecord)((Button)sender).DataContext;

            wc = new WebClient();

            wc.DownloadProgressChanged += (object o, DownloadProgressChangedEventArgs args) =>
            { 
                downloadProgressBar.Value = args.ProgressPercentage;
            };

            wc.DownloadFileCompleted += (o, args) =>
            {
                
                cancelDownloadButton.IsEnabled = false;

                if (!args.Cancelled)
                {
                    string argument = @"/select, " + downloadedFilePath;
                    Process.Start("explorer.exe", argument);
                }
            };

            downloadedFilePath = System.IO.Path.Combine(downloadPath, audio.Title + ".mp3");
            //downloadedFolderPath = downloadPath;

            wc.DownloadFileAsync(audio.Url, downloadedFilePath);
        }

        private void cancelDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            wc.CancelAsync();
            wc.Dispose();

            downloadProgressBar.Value = 0;
            downloadButton.IsEnabled = true;
            cancelDownloadButton.IsEnabled = false;
        }
    }
}
