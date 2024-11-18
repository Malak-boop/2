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
using System.Data.Entity;

namespace Task_maneger
{
    /// <summary>
    /// Interaction logic for viewtask.xaml
    /// </summary>
    ///
    class employee
    {
        public string name { get; set; }
        public employee()
        { 

        }

    }
    public partial class viewtask : Page
    {
        assigment2Entities db = new assigment2Entities();

        public viewtask()
        {
            InitializeComponent();
            var employee = db.task2.Include(x => x.userT2)
    .Select(s => new { s.TaskId, s.title, s.Tdescription ,s.TStatus })
    .ToList();
            data.ItemsSource = employee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
