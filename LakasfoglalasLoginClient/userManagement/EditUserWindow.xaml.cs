using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace LakasfoglalasLoginClient.userManagement
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public HttpClient? client;
        public EditUserWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
            string currentDir = Directory.GetCurrentDirectory();
            //imgProfilkep.Source = new BitmapImage(new Uri($"{currentDir}/default.jpg", UriKind.Absolute));
            tbProfilkep.Text = $"default.jpg";
        }

        private void ImageSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Modositas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void cbxFelhasznaloNev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
