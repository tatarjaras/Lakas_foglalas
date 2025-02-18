using LakasfoglalasLoginClient.userManagement;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LakasfoglalasLoginClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string uId = "";
        static int SaltLength = 64;

        public static string GenerateSalt()
        {
            Random random = new Random();
            string karakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string salt = "";
            for (int i = 0; i < SaltLength; i++)
            {
                salt += karakterek[random.Next(karakterek.Length)];
            }
            return salt;
        }

        public static string CreateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000/")
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenLoginWindow(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.client = sharedClient;
            loginWindow.ShowDialog();
            if (uId != "")
            {
                mitemFelhasznalok.IsEnabled = true;
                mitemBejelentkezes.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés");
            }
        }

        private void UserListWindow(object sender, RoutedEventArgs e)
        {
            UserListWindow userlistWindow = new UserListWindow();
            userlistWindow.ShowDialog();
        }

        private void HozzaadWindow(object sender, RoutedEventArgs e)
        {
            NewUserWindow newuserWindow = new NewUserWindow();
            newuserWindow.ShowDialog();
        }

        private void ModositasWindow(object sender, RoutedEventArgs e)
        {
            EditUserWindow edituserWindow = new EditUserWindow();
            edituserWindow.ShowDialog();
        }

        private void LakasListWindow(object sender, RoutedEventArgs e)
        {
            LakasListWindow lakaslistwindow= new LakasListWindow();
            lakaslistwindow.ShowDialog();
        }

        private void LakasHozzaad(object sender, RoutedEventArgs e)
        {
            NewLakasWindow newlakaslistwindow = new NewLakasWindow();
            newlakaslistwindow.ShowDialog();
        }
    }
}