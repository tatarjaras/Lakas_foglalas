using LakasfoglalasBackEnd.Models;
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
    /// Interaction logic for LakasListWindow.xaml
    /// </summary>
    public partial class LakasListWindow : Window
    {
        public HttpClient? client;

        private static List<Lakasok> lakas = new List<Lakasok>();
        public LakasListWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadLakas()
        {
            try
            {
                string url = $"{client.BaseAddress}api/Lakasok/{MainWindow.uId}?token={MainWindow.uId}";
                lakas = await client.GetFromJsonAsync<List<Lakasok>>(url);

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

        private async void btnBetoltesL_Click(object sender, RoutedEventArgs e)
        {
            await LoadLakas();
            dgLakas.ItemsSource = lakas;
        }
    }
}
