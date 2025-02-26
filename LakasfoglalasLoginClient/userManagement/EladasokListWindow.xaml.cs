using LakasfoglalasBackEnd.Models;
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
    /// Interaction logic for EladasokListWindow.xaml
    /// </summary>
    public partial class EladasokListWindow : Window
    {

        public HttpClient? client;

        private static List<Eladasok> eladas = new List<Eladasok>();

        public EladasokListWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }
        private async Task LoadLakas()
        {
            try
            {
                string url = $"{client.BaseAddress}api/Eladasok/{MainWindow.uId}?token={MainWindow.uId}";
                eladas = await client.GetFromJsonAsync<List<Eladasok>>(url);

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

        private async void btnBetoltesE_Click(object sender, RoutedEventArgs e)
        {
            await LoadLakas();
            dgEladas.ItemsSource = eladas;
        }
    }
}