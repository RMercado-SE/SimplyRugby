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

// class to display a list of players tha are currently
// stored in the DB. Players are displayed depending on what squad the are. 
namespace SimplyRugby
{

    public partial class SquadPlayerWindow : Window
    {

        List<PlayerInfo> players = new List<PlayerInfo>();// stores a lis of player into players

        public SquadPlayerWindow()
        {
            InitializeComponent();

            ListDisplaySquad.DisplayMemberPath = "FullInfo"; // calls from PlayerInfo "FullInfo" where it determins how
                                                             // to display each of the players
        }

        #region squads 

        // each squad is contolled by a button where the button calls 
        // DataAccess calss.
        private void btn14Squad_Click(object sender, RoutedEventArgs e)
        {
            int Age = 14; // local variable 14 to call in the 14 squad

            DataAccess data = new DataAccess(); // creates a new object data 

            players = data.GetSquad(Age); // calls in method GetSquad in DataAccess and stores them in players

            ListDisplaySquad.Items.Clear(); // clears the list box of any prevoius players

            foreach (var player in players) // loop that go thru each player on players list
            {
                ListDisplaySquad.Items.Add(player); // displays each player to the list
            }

        }

        // functions the same as 14 squad method.
        private void btn15Squad_Click(object sender, RoutedEventArgs e)
        {
            int Age = 15;

            DataAccess data = new DataAccess();

            players = data.GetSquad(Age);

            ListDisplaySquad.Items.Clear();

            foreach (var player in players)
            {
                ListDisplaySquad.Items.Add(player);
            }
        }

        // functions the same as 14 squad method.
        private void btn16Squad_Click(object sender, RoutedEventArgs e)
        {
            int Age = 16;

            DataAccess data = new DataAccess();

            players = data.GetSquad(Age);

            ListDisplaySquad.Items.Clear();

            foreach (var player in players)
            {
                ListDisplaySquad.Items.Add(player);
            }
        }

        // functions the same as 14 squad method.
        private void btn18Squad_Click(object sender, RoutedEventArgs e)
        {
            int Age = 18;

            DataAccess data = new DataAccess();

            players = data.GetSquad(Age);

            ListDisplaySquad.Items.Clear();

            foreach (var player in players)
            {
                ListDisplaySquad.Items.Add(player);
            }
        }

        // functions the same as 14 squad method.
        private void btn20Squad_Click(object sender, RoutedEventArgs e)
        {
            int Age = 20;

            DataAccess data = new DataAccess();

            players = data.GetSquad(Age);

            ListDisplaySquad.Items.Clear();

            foreach (var player in players)
            {
                ListDisplaySquad.Items.Add(player);
            }
        }

        // functions the same as 14 squad method.
        private void btn21Squad_Click(object sender, RoutedEventArgs e)
        {
            int Age = 21;

            DataAccess data = new DataAccess();

            players = data.GetSquad(Age);

            ListDisplaySquad.Items.Clear();

            foreach (var player in players)
            {
                ListDisplaySquad.Items.Add(player);
            }
        }

        #endregion     

        // method that controls the actions of the button and takes the user 
        // back to the log in screen
        private void btnLogout_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
    
}
