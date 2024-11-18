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
    /// Interaction logic for viewTaskEmp.xaml
    /// </summary>
    /// 

    public partial class viewTaskEmp : Page
    {   
        sewedyEntities db = new sewedyEntities();
        public viewTaskEmp()
        {
            InitializeComponent();
            compo.ItemsSource = db.Tasks.Select(x => x.Tstatues).Distinct().ToList();
            refrechD1();
        }

        public void refrechD1()
        {
            var task = db.Tasks
                            .Select(x => new { x.TTask_ID, x.Ttitle, x.Tdescription, statuse = x.Tstatues})
                            .ToList();
            awldatagrid.ItemsSource = task;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string j = compo.SelectedItem.ToString();
            if (!(j == null))
            {
                var USS = db.Tasks.Where(x => x.Tstatues == j).Select(uu => new {uu.TTask_ID,uu.Ttitle,uu.Tdescription,uu.Tstatues}).ToList();
                awldatagrid.ItemsSource = USS;

            }
        }
    }
}


