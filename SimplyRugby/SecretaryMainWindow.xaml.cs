using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;


// This class takes and passes the players details to the DB
// Class where the secretary has interaction and can save, modify or delete player profiles

namespace SimplyRugby
{
    
    public partial class SecretaryMainWindow : Window
    {

        List<PlayerInfo> players = new List<PlayerInfo>();  // list of player where all the details will be stored.

        public SecretaryMainWindow()
        {
            InitializeComponent();
        }

        // Method that validates the E-mail
        private static bool VerifyEmail(string text) 
        {
            bool ValidEmail = false;
            Regex regEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if(text.Length > 0)
            {
                ValidEmail = regEMail.IsMatch(text);
            }
            return ValidEmail;
        }



        #region create a player

        // method that allows the user to gather player details and store them in the DB

        public void btnCreateNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            // variables that controls the methods outcomes
            bool ok = true; 
            bool focus = false;


            DataAccess data = new DataAccess(); // creates a new object call data in DataAccess
            try
            {
                // local variables
                int SRU = int.Parse(txtSRU.Text);

                int Age = int.Parse(txtAge.Text);

                // method that verifyies the e-mail
                if (VerifyEmail(txtEmail.Text.Trim()) == false)
                {
                    MessageBox.Show("E-Mail format is not valid");
                    if (!focus)
                    {
                        txtEmail.Focus();
                        focus = true;
                    }
                    ok = false;

                    if (VerifyEmail(txtEmail.Text.Trim()) == true)
                    {
                        ok = true;
                    }

                }

                // SRU validation
                if (SRU < 100000 || SRU > 999999)
                {
                    MessageBox.Show("SRU Number must contain 6 numbers from a range of 100000 to 999999");
                    ok = false;

                }

                // Age validation
                if (Age > 120)
                {
                    MessageBox.Show("Age number not valid");
                    if (!focus)
                    {
                        txtAge.Focus();
                        focus = true;
                    }
                    ok = false;
                }

                // Junior squad age validation
                if (Age <= 18)
                {
                    if ((bool)chkParental.IsChecked) // parental box cheked ok to proceede 
                    {
                        ok = true;
                    }
                    else // player under the age of 21 needs parental consent 
                    {
                        MessageBox.Show("You must ensure parental consent is given for this player");
                        if (!focus)
                        {
                            txtAge.Focus();
                            focus = true;
                        }
                        ok = false;
                    }
                }
                
              // if validation statements are ok this statement is activated
                if (ok)
                {
                    

                    MessageBox.Show("Player profile saved");

                    data.InsertPlayer(SRU, txtName.Text, Age, txtDOB.Text, txtEmail.Text, txtContactNumber.Text);

                    txtName.Text = "";
                    txtAge.Text = "";
                    txtDOB.Text = "";
                    txtEmail.Text = "";
                    txtSRU.Text = "";
                    txtContactNumber.Text = "";
                }
            }
            catch // any other validation
            {
                MessageBox.Show("All fields must conatin data");
            }
        }
        #endregion


        #region search player

        // method that allows user to search for a player in the DB

        public void btnSearchPlayer_Click(object sender, RoutedEventArgs e)
        {
            string SRU = txtSearchSRU.Text; // loval variable to store the SRU that will be use to search for a player

            DataAccess data = new DataAccess(); // creates an object call data in DataAccess

            players = data.GetPlayers(SRU); // gathers the players details from the DB calling method GetPlayers in DataAcces and stroes the in players

            

           foreach (var player in players) // loop interates and displays all details from the player
           {


                // details are displayed indicidual to screen
                txtSRU.Text = Convert.ToString(player.SRU);
                
                txtName.Text = player.Name;

                txtContactNumber.Text = player.PhoneNumber;

                txtDOB.Text = player.DOB;

                txtEmail.Text = player.Email;

                txtAge.Text = Convert.ToString(player.Age);
                



           }

            txtSearchSRU.Text = " ";
        }
        #endregion


        #region delete player

        // method that delets a player from the DB
        public void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            string SRU = txtSRU.Text; // loval variable to store the SRU that will be use to get the player from the DB

            DataAccess data = new DataAccess(); // creates an object call data

             data.DeletPlayer(SRU); // calls method DeletePlayer from DataAccesss

            MessageBox.Show("Player deleted from data base"); // inform user that the player has been deleted from DB

            // clears all boxses
            txtName.Text = "";
            txtAge.Text = "";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtSRU.Text = "";
            txtContactNumber.Text = "";


        }
        #endregion


        #region construcctor

        // allows user to navigate back to main screen and log out
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // allows user to navigate to the squad window.
        private void btnSquads_Click(object sender, RoutedEventArgs e)
        {
            SquadPlayerWindow squadPlayerWindow = new SquadPlayerWindow();
            squadPlayerWindow.Show();
            this.Close();
        }

        #endregion
    }
}
