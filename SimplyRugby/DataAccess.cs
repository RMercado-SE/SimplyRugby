using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;


// class that conects the solution to the DB base
// all variables stored in thios application are passes thru this classs where a conection is open to the DB
// and then stored in DB

namespace SimplyRugby
{
    public class DataAccess
    {
        public PlayerInfo player { get; set; } // variable that will store all players details 

     
        // variable that controls comunication between the solution and the DB
        public string conectString = "Data source=DESKTOP-FCO52KJ\\SQLEXPRESS; Initial Catalog=SimplyRugbyDB; Integrated Security = True";

        #region methods


        // method that gets a player from the DB using the SRU

        public List<PlayerInfo> GetPlayers(string SRU)
        {
            player = new PlayerInfo();
            player.tempSRU = SRU;
            SqlConnection con = new SqlConnection(conectString);
            con.Open(); // connection open to DB

            var players = con.Query<PlayerInfo>("dbo.GetPlayer @tempSRU", player); // opens conetcion to DB and stores the details of that sepecific player in players
            

            return players.ToList(); // return details of players to player variable as a list 

            con.Close(); // connection closed to DB

        }

        // method that allows user to create a new player profile 

        public void InsertPlayer(int sru,string name,int age,string dob,string email,string phonenumber) // variables passed from SecretaryMainWindow
        {

            player = new PlayerInfo(); // storing variables in player

            SqlConnection con = new SqlConnection(conectString); // new conection establish

            con.Open(); // connection to DB open

            // saves local variables to player
            player.SRU = sru;
            player.Name = name;
            player.Age = age;
            player.DOB = dob;
            player.PhoneNumber = phonenumber;
            player.Email = email;

            con.Execute("dbo.New_Update_Player @SRU,@Name,@DOB,@PhoneNumber,@Email,@Age", player); // executes stored procedure in DB and saves player details

            

            con.Close(); // connection to DB closed
        }

        // method that allows user to delet a player

        public void DeletPlayer(string SRU) // variable passed from SecretaryMainWindow
        {

            player = new PlayerInfo(); // new object call player 
            player.tempSRU = SRU;

            SqlConnection con = new SqlConnection(conectString); // new connection to DB

            con.Open(); // open connection to DB

            con.Execute("dbo.DeletePlayer @tempSRU", player); // executes stored procedure in DB, player deleted

            con.Close(); // connection closed
        }


        // method that grabs a list of players from each squad

        public List<PlayerInfo> GetSquad(int age) // variable age passed from SquadPlayerWindow
        {
            player = new PlayerInfo(); // new object player 
            player.Age = age; // age variable will determin which squad to grab from DB

            SqlConnection con = new SqlConnection(conectString); // new connection establish

            con.Open();// open connection to DB

            var players = con.Query<PlayerInfo>("dbo.GetSquad @Age", player).ToList(); // executes stored procedure inDB and grabs the squad of players

            return players; // returns a list of players 

            con.Close(); // connection closed
        }


        // method that allows user to update a player skills

        public void UpdatePlayerSkills(int sru, int standar, int spin, int pop,
                                       int front, int rear, int side, int scrabble,
                                       int drop, int punt, int grubber, int goal, string comments) // variables passed from CoachMainWindow
        {

            player = new PlayerInfo(); // creates a new object player


            SqlConnection con = new SqlConnection(conectString); // new connection

            con.Open(); // connecdtion open


            // individual variables stored in player object
            player.SRU = sru;
            player.Standar = standar;
            player.Spin = spin;
            player.Pop = pop;
            player.Front = front;
            player.Rear = rear;
            player.Side = side;
            player.Scrabble = scrabble;
            player.Drop = drop;
            player.Punt = punt;
            player.Grubber = grubber;
            player.Goal = goal;
            player.Comments = comments;


            // executes stored procedure in DB and saves player skills
            con.Execute("dbo.UpdatePlayerSkills @SRU,@Standar,@Spin,@Pop,@Front,@Rear,@Side,@Scrabble,@Drop,@Punt,@Grubber,@Goal,@Comments", player);

            con.Close(); // connection closed



        }

        #endregion
    }
}
