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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        sewedyEntities db=new sewedyEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string emailadmin = "engsara@gmail.com";
            string passwordadmin = "123";

            string enterpass = password_log.Text;
            string enteremail = email_log.Text;

            if (enteremail == "" || enterpass == "")
            {
                MessageBox.Show("please enter email and password");
                return;
            }
            if (emailadmin == enteremail && passwordadmin == enterpass)
            {
                MangemntPage mange = new MangemntPage();
                NavigationService.Navigate(mange);
            }
            else
            {
                 Userr Us = new Userr();

                Us = db.Userrs.FirstOrDefault(x => x.Uemail == enteremail && x.Upassword == enterpass);
                if (Us != null)
                {
                    MessageBox.Show("data is correct");
                    viewTaskEmp EMP = new viewTaskEmp();
                    NavigationService.Navigate(EMP);
                }

                else
                {
                    MessageBox.Show("data in not correct database");
                }
            }
        }
    }
}

