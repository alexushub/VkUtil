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
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var audios = VkAPILib.VkApiLib.SearchAudios(searchTextBox.Text);
            var a = audios.Count;
            foreach (var item in audios)
            {
                audioListBox.Items.Add(item);
            }
        }
    }
}
