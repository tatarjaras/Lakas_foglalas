using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Interaction logic for UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        public HttpClient? client;

        private static List<User> users = new List<User>();
        public UserListWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadUsers()
        {
            try
            {
                string url = $"{client.BaseAddress}api/User/{MainWindow.uId}?uId={MainWindow.uId}";
                users = await client.GetFromJsonAsync<List<User>>(url);

                /*Másik lehetőség:
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    users = JsonSerializer.Deserialize<List<User>>(content, options)!;
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            await LoadUsers();
            dgUsers.ItemsSource = users;
        }
    }
}
