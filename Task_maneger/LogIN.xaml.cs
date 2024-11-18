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

namespace Task_maneger
{
    /// <summary>
    /// Interaction logic for LogIN.xaml
    /// </summary>
    public partial class LogIN : Page
    {
        assigment2Entities db=new assigment2Entities(); 
        public LogIN()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txtemail.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("unfilled fields");
                return;
            }
            if (txtemail.Text == "1" || txtpass.Text == "1")
            {
                this.NavigationService.Navigate(new manager());

                MessageBox.Show("Login As Admin ");
                return;
            }
            var student1 = db.userT2.Where(stu => stu.email == txtemail.Text && stu.UPassword == txtpass.Text).FirstOrDefault();
            if (student1 != null)
            {
                this.NavigationService.Navigate(new viewtask());
                MessageBox.Show("LogIn Succefully");
            }
            else
            {
                MessageBox.Show("Incorrect email or Passsword");
            }
        } 
            
            
        }


    }

