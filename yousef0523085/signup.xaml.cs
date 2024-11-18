using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        sewedyEntities db = new sewedyEntities();

        public signup()
        {
            InitializeComponent();
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {

            if (nameuptxt.Text == "" || emailuptxt.Text == "" || passworduptxt.Text == "" || confirmpassworduptxt.Text == "" || roleup.Text == "")
            {
                MessageBox.Show("please enter all data");
                return;
            }

            if (passworduptxt.Text != roleup.Text)
            {
                MessageBox.Show("Password not match");
                return;
            }

            if (!(Regex.IsMatch(passworduptxt.Text, "[8]")))
            {
                MessageBox.Show("not corect pass");
                return;
            }


            if (!(roleup.Text == "manager" || roleup.Text == "user"))
            {
                MessageBox.Show(" role rong");
            }
            Userr userr = new Userr();
            if (emailuptxt.Text == userr.Uemail)
            {
                MessageBox.Show("email un corrct");
            }

            if (!(Regex.IsMatch(nameuptxt.Text, "[//d]")))
            {
                MessageBox.Show("rong");
            }
            else
            {
                Userr us= new Userr();
                us.UName = nameuptxt.Text;
                us.Uemail = emailuptxt.Text;
                us.Upassword = passworduptxt.Text;
                us.Urole = roleup.Text;

                us = db.Userrs.Add(us);
                db.SaveChanges();
                Login login = new Login();
                NavigationService.Navigate(login);
                MessageBox.Show("DONE");
                return;
            }

        }

    }
}
