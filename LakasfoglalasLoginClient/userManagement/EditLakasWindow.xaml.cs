using LakasfoglalasBackEnd.Models;
using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Interaction logic for EditLakasWindow.xaml
    /// </summary>
    public partial class EditLakasWindow : Window
    {

        public HttpClient? client;
        private static List<Lakasok> lakas = new List<Lakasok>();

        public EditLakasWindow()
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
                dgrLakas.ItemsSource = null;
                dgrLakas.ItemsSource = lakas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a lakások betöltésekor: {ex.Message}");
            }
        }

        private async void btnBetoltes_KliKk(object sender, RoutedEventArgs e)
        {
            await LoadLakas();
        }

        private async void Modositas_Click(object sender, RoutedEventArgs e)
        {
            if (dgrLakas.SelectedItem is Lakasok utca)
            {
                var result = MessageBox.Show($"Biztosan módosítod a(z) {utca.Utca}(án) található házat?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId;
                        string updateUrl = $"api/Lakasok/{token}";

                        var updatelakas = new Lakasok
                        {
                            Id = utca.Id,
                            Utca = utca.Utca,
                            Meret = utca.Meret,
                            SzobakSzama = utca.SzobakSzama,
                            Ar = utca.Ar,
                            Leiras = utca.Leiras,
                            Eladasoks = utca.Eladasoks,
                            FelhasznaloId = utca.FelhasznaloId,
                            VarosId = utca.VarosId,
                        };


                        var response = await client.PutAsJsonAsync(updateUrl,updatelakas);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Lakás sikeresen módosítva.");
                            await LoadLakas();
                        }
                        else
                        {
                            string errorMsg = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Hiba történt: {response.StatusCode} - {errorMsg}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba a módosítás során: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy lakást a módosításhoz!");
            }
        }

        private async void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgrLakas.SelectedItem is Lakasok utca)
            {
                var result = MessageBox.Show($"Biztosan törlöd  a(z) {utca.Utca}(án) található házat?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId; 
                        string deleteUrl = $"api/Lakasok/{token}, {utca.Id}";

                        var response = await client.DeleteAsync(deleteUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Lakás sikeresen törölve.");
                            await LoadLakas();
                        }
                        else
                        {
                            string errorMsg = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Hiba történt: {response.StatusCode} - {errorMsg}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba a törlés során: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy lakást a törléshez!");
            }
        }


        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
