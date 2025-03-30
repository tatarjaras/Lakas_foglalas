using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
            public HttpClient? client;
            private static List<User> users = new List<User>();

            public EditUserWindow()
            {
                InitializeComponent();
                client = MainWindow.sharedClient;
            }

            private async Task LoadUsers()
            {
                try
                {
                    string url = $"{client.BaseAddress}api/User/{MainWindow.uId}?uId={MainWindow.uId}";
                    users = await client.GetFromJsonAsync<List<User>>(url) ?? new List<User>();
                    dgrUsers.ItemsSource = null;
                    dgrUsers.ItemsSource = users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a felhasználók betöltésekor: {ex.Message}");
                }
            }

            private async void btnBetoltes_Click(object sender, RoutedEventArgs e)
            {
                await LoadUsers();
            }

            private async void Modositas_Click(object sender, RoutedEventArgs e)
            {
                if (dgrUsers.SelectedItem is User selectedUser)
                {
                    var result = MessageBox.Show($"Biztosan módosítod a {selectedUser.Name} nevű felhasználót?", "Megerősítés", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            string token = MainWindow.uId;
                            string updateUrl = $"api/User/{token}";

                            var updatedUser = new User
                            {
                                Id = selectedUser.Id,
                                Name = selectedUser.Name,
                                Email = selectedUser.Email,
                                PermissionId = selectedUser.PermissionId,
                                Hash = selectedUser.Hash ?? "",
                                Salt = selectedUser.Salt ?? "",
                                LoginNev = selectedUser.LoginNev ?? "defaultLogin",
                                ProfilePicturePath = selectedUser.ProfilePicturePath ?? "default.jpg"
                            };


                            var response = await client.PutAsJsonAsync(updateUrl, updatedUser);

                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Felhasználó sikeresen módosítva.");
                                await LoadUsers();
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
                    MessageBox.Show("Kérlek válassz ki egy felhasználót a módosításhoz!");
                }
            }

            private async void Torles_Click(object sender, RoutedEventArgs e)
            {
                if (dgrUsers.SelectedItem is User selectedUser)
                {
                    var result = MessageBox.Show($"Biztosan törlöd a {selectedUser.Name} nevű felhasználót?", "Megerősítés", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            string token = MainWindow.uId; // Feltételezve, hogy az uId a token
                            string deleteUrl = $"api/User/{token}, {selectedUser.Id}";

                            var response = await client.DeleteAsync(deleteUrl);

                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Felhasználó sikeresen törölve.");
                                await LoadUsers(); // Lista frissítése
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
                    MessageBox.Show("Kérlek válassz ki egy felhasználót a törléshez!");
                }
            }


            private void Megse_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
        }
    }
