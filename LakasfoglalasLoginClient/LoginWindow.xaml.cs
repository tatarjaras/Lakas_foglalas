using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;
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

namespace LakasfoglalasLoginClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public HttpClient client;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void btnBejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.PostAsync($"api/Login/SaltRequest/{tbxFelhasznalonev.Text}",
                new StringContent(tbxFelhasznalonev.Text, Encoding.UTF8, "text/plain"));
            string salt = await response.Content.ReadAsStringAsync();
            MessageBox.Show(salt);

            string tmpHash = MainWindow.CreateSHA256(tbxJelszo.Password + salt);
            MessageBox.Show(tmpHash);
            LoginDTO dtoUser = new LoginDTO()
            {
                LoginName = tbxFelhasznalonev.Text,
                TmpHash = tmpHash
            };

            string felhAdatok = JsonSerializer.Serialize(dtoUser, JsonSerializerOptions.Default);
            var body = new StringContent(felhAdatok, Encoding.UTF8, "application/json");
            var valasz = await client.PostAsync("api/Login", body);
            var content = await valasz.Content.ReadAsStringAsync();
            MessageBox.Show(content);

            LoggedUser bejelentkezett =
                JsonSerializer.Deserialize<LoggedUser>(content);
            MessageBox.Show(bejelentkezett.Token);

            string[] darabok = content.Split('"');
            string tokenem = darabok[darabok.Length - 2];
            MainWindow.uId = tokenem;
            Close();
        }

        private void btnMegse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
