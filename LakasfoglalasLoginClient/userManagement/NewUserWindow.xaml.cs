using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public HttpClient? client;
        public NewUserWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
            string currentDir = Directory.GetCurrentDirectory();
            imgProfilkep.Source = new BitmapImage(new Uri($"{currentDir}/default.jpg", UriKind.Absolute));
            tbProfilkep.Text = $"default.jpg";
        }

        private void ImageSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Mentes_Click(object sender, RoutedEventArgs e)
        {
            string salt = MainWindow.GenerateSalt();
            if (tbxFelhasznaloNev.Text is not null &&
                tbxTeljesNev.Text is not null &&
                pbxJelszo1.Password is not null &&
                pbxJelszo1.Password == pbxJelszo2.Password &&
                tbxEmail.Text is not null &&
                cbxPermission.SelectedValue is not null
                )
            {
                string ujHash = MainWindow.CreateSHA256(MainWindow.CreateSHA256(pbxJelszo1.Password + salt));
                try
                {
                    User newUser = new()
                    {
                        Id = 0,
                        LoginNev = tbxFelhasznaloNev.Text,
                        Name = tbxTeljesNev.Text,
                        Salt = salt,
                        Hash = ujHash,
                        PermissionId = 9, //(int)cbxPermission.SelectedValue,
                        Active = cbActive.IsChecked == true,
                        Email = tbxEmail.Text,
                        ProfilePicturePath = tbProfilkep.Text
                    };
                    string toSend = JsonSerializer.Serialize(newUser, JsonSerializerOptions.Default);
                    var content = new StringContent(toSend, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"api/User/{MainWindow.uId}?token={MainWindow.uId}", content);
                    string rcontent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(rcontent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kitöltési hiba");
            }
        }

        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
