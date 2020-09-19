using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserCredentials credentials;
        public static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            credentials = new UserCredentials();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string loginId = txtName.Text;
            string password = string.Empty;
            ValidateUser(loginId, ref password);

        }

        /// <summary>
        /// This method will validate the user
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        private void ValidateUser(string loginId, ref string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(loginId) && UserCredentials.userCredentials.ContainsKey(loginId))
                {
                    password = UserCredentials.userCredentials[loginId];
                }
                else
                {
                    MessageBox.Show("Username Incorrect !!");
                    return;
                }

                if (!string.IsNullOrEmpty(password) && txtPassword.Password == password)
                {
                    //LoginScreen.Visibility = Visibility.Hidden;
                    ListViewScreen screen = new ListViewScreen();
                    txtName.Text = string.Empty;
                    txtPassword.Password = string.Empty;
                    screen.Title = loginId;
                    screen.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Password !!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in validation..");
            }
        }
    }
}
