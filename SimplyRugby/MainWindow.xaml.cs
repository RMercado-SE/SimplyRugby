using FakeItEasy;
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

namespace SimplyRugby
{
   // welcome window where the user is asked to type a password, 
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // password fix for secretary
        private string secretaryPassword = "secretarySR50";
        // password fix for coach
        private string coachPassword = "coachSR50";

        // method that controls navigation 
        // depending on what password was typed
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (secretaryPassword == passBox.Password) // statment that will ocuur if secretary password was typed
            {

                SecretaryMainWindow secretaryMainWindow = new SecretaryMainWindow();
                secretaryMainWindow.Show();
                this.Close();

            }
            else if(coachPassword == passBox.Password)// statement that will ocurr if coach password was typed
            {
                CoachMainWindow coachMainWindow = new CoachMainWindow();
                coachMainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password invalid please try again"); // will inform user to try again.
            }
        }
    }
}
