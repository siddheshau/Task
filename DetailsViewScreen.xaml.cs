using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for DetailsViewScreen.xaml
    /// </summary>
    public partial class DetailsViewScreen : Window
    {
        public DetailsViewScreen()
        {
            InitializeComponent();
            //Details view screen will show the details of user present in List view

            txtBlkUserid.Text = ListViewScreen.userDetails.UserId.ToString();
            txtBlkId.Text = ListViewScreen.userDetails.Id.ToString();
            txtBlkTitle.Text = ListViewScreen.userDetails.Title;
            txtBlkCompleted.Text = ListViewScreen.userDetails.Completed.ToString();
            
        }
    }
}
