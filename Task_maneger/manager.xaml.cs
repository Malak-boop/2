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
using System.Data.Entity.Migrations;

namespace Task_maneger
{
    /// <summary>
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Page
    {
        assigment2Entities db = new assigment2Entities();
        public manager()
        {
            InitializeComponent();
            combo.ItemsSource = db.task2.Select(dep => dep.TStatus).Distinct().ToList();

            var employee = db.task2.Include(x => x.userT2)
    .Select(s => new { employee = s.userT2.email ,s.TaskId, s.title, s.Tdescription, s.TStatus })
    .ToList();
            dg.ItemsSource = employee;
        }
        private void Button_Click_edit(object sender, RoutedEventArgs e)
        {
            if (txtid.Text=="")
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }
            int id = int.Parse(txtid.Text);


            var up = db.task2.FirstOrDefault(x => x.TaskId == id);

            if (up != null)
            {
                    db.task2.AddOrUpdate(up);
                    db.SaveChanges();
                var employee = db.task2.Include(x => x.userT2)
    .Select(s => new { employee = s.userT2.email ,s.TaskId, s.title, s.Tdescription, s.TStatus })
    .ToList();
                MessageBox.Show("Employee updated successfully.");
              
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }
    

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Please enter the Id");
                return;
            }
            int id = int.Parse(txtid.Text);
            var stu = db.task2.Where(s => s.TaskId == id).FirstOrDefault();
            if (stu != null)
            {
                db.task2.Remove(stu);
                db.SaveChanges();
                MessageBox.Show("Deleted Successfully");
            }
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {

            if (txtid.Text == "")
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }
            int id = int.Parse(txtid.Text);


            var up = db.task2.FirstOrDefault(x => x.TaskId == id);

            if (up != null)
            {
                db.task2.Add(up);
                db.SaveChanges();
                var employee = db.task2.Include(x => x.userT2)
    .Select(s => new { employee = s.userT2.email, s.TaskId, s.title, s.Tdescription, s.TStatus })
    .ToList();
                MessageBox.Show("Employee updated successfully.");

            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        






    }

        
    }
}
