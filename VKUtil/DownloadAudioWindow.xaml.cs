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
using Microsoft.Win32;

namespace VkUtil
{
    /// <summary>
    /// Interaction logic for DownloadAudioWindow.xaml
    /// </summary>
    public partial class DownloadAudioWindow : Window
    {
        public DownloadAudioWindow()
        {
            InitializeComponent();

            downloadFolderPathTextBox.TextChanged += (sender, args) =>
            {
                AudioInListControl.downloadPath = downloadFolderPathTextBox.Text;
            };
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var audios = VkAPILib.VkApiLib.SearchAudios(searchTextBox.Text);
            var a = audios.Count;

            audioListBox.Items.Clear();
            foreach (var item in audios)
            {
                audioListBox.Items.Add(item);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            searchTextBox.Focus();

            downloadFolderPathTextBox.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            AudioInListControl.downloadPath = downloadFolderPathTextBox.Text;
        }

        private void downloadPathSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
             // = downloadFolderPathTextBox.Text;
            var result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                downloadFolderPathTextBox.Text = dialog.SelectedPath;
            }
        }
    }
}
