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
using System.Windows.Shapes;


// Class for the coach interaction with the solution
// This class control the skills development for each individual player



namespace SimplyRugby
{
    public partial class CoachMainWindow : Window
    {
        public CoachMainWindow()
        {
            InitializeComponent();
        }


        List<PlayerInfo> players = new List<PlayerInfo>(); // Use to store player details in a list

        #region methods


        // Method that search fro a player in the DB

        private void btnSearchPlayer_Click(object sender, RoutedEventArgs e)
        {


            string SRU = txtSearchSRUc.Text; // stores the SRU number which will be use to search for a player

            DataAccess data = new DataAccess(); //  creates a new object

            players = data.GetPlayers(SRU); // calls GetPlayer in DataAccess class and stores the details in players 



            foreach (var player in players) // loops thru the list and grabs player details and skills 
            {


                // all player details are desplayed individualy 
                txtNamec.Text = player.Name;

                txtContactNumberc.Text = player.PhoneNumber;

                txtDOBc.Text = player.DOB;

                txtEmailc.Text = player.Email;

                txtAgec.Text = Convert.ToString(player.Age);
                
                txtFront.Text = Convert.ToString(player.Front);

                txtGoal.Text = Convert.ToString(player.Goal);

                txtGrubber.Text = Convert.ToString(player.Grubber);

                txtPop.Text = Convert.ToString(player.Pop);

                txtPunt.Text = Convert.ToString(player.Punt);

                txtRear.Text = Convert.ToString(player.Rear);

                txtScrabble.Text = Convert.ToString(player.Scrabble);

                txtSide.Text = Convert.ToString(player.Side);

                txtSpin.Text = Convert.ToString(player.Side);

                txtStandar.Text = Convert.ToString(player.Side);

                txtDrop.Text = Convert.ToString(player.Front);

                txtComments.Text = player.Comments;

            }
        }


        // Method that grabs and sends the details of a player to be stored in the DB

        private void btnModifyPlayerSkills_Click(object sender, RoutedEventArgs e)
        {

            DataAccess data = new DataAccess(); // Creats a new object in DataAccess class 


           // All users inputs(coach) are stored indivudualy 

                int SRU = int.Parse(txtSearchSRUc.Text);
                int Standar = int.Parse(txtStandar.Text);
                int Spin = int.Parse(txtSpin.Text);
                int Pop = int.Parse(txtPop.Text);
                int Front = int.Parse(txtFront.Text);
                int Rear = int.Parse(txtRear.Text);
                int Side = int.Parse(txtSide.Text);
                int Scrabble = int.Parse(txtScrabble.Text);
                int Drop = int.Parse(txtDrop.Text);
                int Punt = int.Parse(txtPunt.Text);
                int Grubber = int.Parse(txtGrubber.Text);
                int Goal = int.Parse(txtGoal.Text);
                string Comments = txtComments.Text;

            // Calls method UpdatePlayerSkills in DataAcces and passes all variables 

                data.UpdatePlayerSkills(SRU, Standar, Spin, Pop, Front, Rear, Side, Scrabble, Drop, Punt, Grubber, Goal, Comments);

            MessageBox.Show("Player skills saved");
        }

        #endregion

        #region constructors

        // button that navigates to the squad window 

        private void btnSquads_Click(object sender, RoutedEventArgs e)
        {
            SquadPlayerWindow squadPlayerWindow = new SquadPlayerWindow();
            squadPlayerWindow.Show();
            this.Close();
        }

        // button that navigates back to the main window and logsout the user

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        #endregion
    }
}
