
using LakasfoglalasBackEnd.Models;
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
    /// Interaction logic for NewLakasWindow.xaml
    /// </summary>
    public partial class NewLakasWindow : Window
    {
        public HttpClient? client;
        public List<int> varosok = new List<int>();
        public List<int> userek = new List<int>();

        public NewLakasWindow()
        {
            InitializeComponent();
            varosok.Add(1);
            varosok.Add(2);
            varosok.Add(3);
            varosok.Add(4);
            userek.Add(1);
            userek.Add(11);
            userek.Add(12);
            cbxVarosID.ItemsSource = varosok;
            cbxFelhasznaloID.ItemsSource = userek;
            client = MainWindow.sharedClient;
            string currentDir = Directory.GetCurrentDirectory();
        }
        private async void LMentes_Click(object sender, RoutedEventArgs e)
        {
            string salt = MainWindow.GenerateSalt();
            if (tbxUtca.Text is not null &&
                tbxMeret.Text is not null &&
                cbxSzobakSzama.SelectedValue is not null &&
                tbxAr.Text is not null &&
                tbxLeiras.Text is not null &&
                cbxVarosID.SelectedValue is not null&&
                cbxFelhasznaloID.SelectedValue is not null
                )
            {
                try
                {
                    Lakasok newlakas = new()
                    {
                        Id = 0,
                        Utca = tbxUtca.Text,
                        Meret = int.Parse(tbxMeret.Text),
                        SzobakSzama = int.Parse(cbxSzobakSzama.Text),
                        Ar = int.Parse(tbxAr.Text),
                        Leiras = tbxLeiras.Text,
                        FelhasznaloId = int.Parse(cbxFelhasznaloID.SelectedItem.ToString()),
                        VarosId =  int.Parse(cbxVarosID.SelectedItem.ToString()),
                        Eladasoks=false
                    };
                    string toSend = JsonSerializer.Serialize(newlakas, JsonSerializerOptions.Default);
                    var content = new StringContent(toSend, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"api/Lakasok/{MainWindow.uId}?token={MainWindow.uId}", content);
                    string rcontent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(rcontent);
                    MessageBox.Show("anyád");
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

        private void LMegse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    
}
}
