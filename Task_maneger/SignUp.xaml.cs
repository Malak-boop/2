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
using Task_maneger;

namespace Task_maneger
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        assigment2Entities db = new assigment2Entities();
        userT2 U = new userT2();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click_Signup(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nametxt.Text == "" || passtxt.Text == "" || conftxt.Text == "" || emailtxt.Text == "" || roletxt.Text == "")
                {
                    MessageBox.Show("unfilled fields");
                    return;
                }
                if (passtxt.Text != conftxt.Text)
                {
                    MessageBox.Show("Not Match");
                    return;
                }
                if (!(Regex.IsMatch(passtxt.Text, "[a-z]") && Regex.IsMatch(passtxt.Text, "[A-Z]") && Regex.IsMatch(passtxt.Text, "[@#$%&*]") && Regex.IsMatch(passtxt.Text, "[8]")))
                {
                    MessageBox.Show("Please Enter Strong Password");
                    return;
                }
                if (!(roletxt.Text == "manager" || roletxt.Text == "user"))
                {
                    MessageBox.Show(" role rong");
                }
                if (!(Regex.IsMatch(nametxt.Text, "[\\d]")))
                {
                    MessageBox.Show("rong");
                }
                if (U.email==emailtxt.Text)
                {
                    MessageBox.Show("please enter unique email");
                    return;
                }

                //if(nametxt.Text.Length>5)
                //{
                //    MessageBox.Show("enter name more than 5 digit");
                //    return;
                //}
                U.email = emailtxt.Text;
                U.UName = nametxt.Text;
                U.urole = roletxt.Text;
                U.UPassword = passtxt.Text;
                db.userT2.Add(U);
                db.SaveChanges();
                MessageBox.Show("Sign up succssfully");
                this.NavigationService.Navigate(new LogIN());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
           
        }
    }
}


