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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VkAPILib;

namespace VkUtil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(VkApiLib.AccessToken))
            {
                var authWind = new AuthWindow();
                authWind.ShowDialog();
            }
        }

        private void audioDownloadbButton_Click(object sender, RoutedEventArgs e)
        {
            var downlAudWind = new DownloadAudioWindow();
            downlAudWind.ShowDialog();
        }
    }
}
