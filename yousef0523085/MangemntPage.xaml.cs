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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace yousef0523085
{
    /// <summary>
    /// Interaction logic for MangemntPage.xaml
    /// </summary>
    public partial class MangemntPage : Page
    {
        sewedyEntities db = new sewedyEntities();

        public MangemntPage()
        {
            InitializeComponent();
            compo2.ItemsSource = db.Tasks.Select(x => x.Tstatues).Distinct().ToList();
            refrechmMANGMENT();
        }
        public void refrechmMANGMENT()
        {
            var task = db.Tasks
                            .Select(x => new { x.TTask_ID, x.Ttitle, x.Tdescription, statuse = x.Tstatues })
                            .ToList();
            datagride2.ItemsSource = task;
        }
        private void compo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string j = compo2.SelectedItem.ToString();
            if (!(j == null))
            {
                var USS = db.Tasks.Where(x => x.Tstatues == j).Select(uu => new { uu.TTask_ID, uu.Ttitle, uu.Tdescription, uu.Tstatues }).ToList();
                datagride2.ItemsSource = USS;

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("enterdata");
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (idmn.Text == "")
            {
                MessageBox.Show("enter id");
                return;
            }
            int id = int.Parse(idmn.Text);
            var yousef = db.Userrs.Where(x => x.UUSER_ID == id).FirstOrDefault();
            if (yousef != null)
            {
                db.Userrs.Remove(yousef);
                db.SaveChanges();
                MessageBox.Show("delete sucssuel");
               
            }
            refrechmMANGMENT();
        }
    }
}
