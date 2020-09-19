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
using System.Windows.Shapes;

namespace UserInformationSystem
{
    /// <summary>
    /// Interaction logic for ListViewScreen.xaml
    /// </summary>
    public partial class ListViewScreen : Window
    {
        public static HttpClient client = new HttpClient();
        public List<UserDetails> userDetailsList = new List<UserDetails>();
        public static UserDetails userDetails;
        public ListViewScreen()
        {
            InitializeComponent();
            ShowUserDetails();
        }

        public async void ShowUserDetails()
        {
            try
            {
                JArray details = await GetApiAsync("https://jsonplaceholder.typicode.com/todos");
                for (int i = 0; i < details.Count; i++)
                {
                    JToken a = details[i];
                    int UserId = (int)a["userId"];
                    int Id = (int)a["id"];
                    string Title = (string)a["title"];
                    bool Completed = (bool)a["completed"];
                    UserDetails userDetails = new UserDetails(UserId, Id, Title, Completed);
                    userDetailsList.Add(userDetails);
                }
                this.lstUserDetails.ItemsSource = userDetailsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }


        static async Task<JArray> GetApiAsync(string url)
        {
            JArray details = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    details = await response.Content.ReadAsAsync<JArray>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while calling api..");
            }
            return details;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                userDetails = (UserDetails)item.DataContext;
                DetailsViewScreen viewScreen = new DetailsViewScreen();
                viewScreen.Show();
            }
        }
    }
}
