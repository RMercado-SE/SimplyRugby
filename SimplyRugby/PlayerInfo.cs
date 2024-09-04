using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


// class that contains all the variables related to a player
// this include personal details and development skills

namespace SimplyRugby
{
    public class PlayerInfo
    {
        #region player details variables

        public int SRU { get; set; }

        public string Name { get; set; }
     
        public string DOB { get;  set; }

        public string PhoneNumber { get;  set; }

        public string Email { get; set; }
        
        public int Age { get;  set; }

        public string tempSRU { get; set; }

        #endregion

        #region skills variables

        private int standar;
        public int Standar
        { 
            
            get
            {
                return standar;
            }
            
            
          set
            {
                if (value >= 1 && value <= 5)
                    standar = value;
                else

                    MessageBox.Show("Standar Skill must be between 1 and 5");


            }
        
        
        }

        private int spin;
        public int Spin
        {

            get
            {
                return spin;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    spin = value;
                else

                    MessageBox.Show("Spin Skill must be between 1 and 5");


            }


        }

        private int pop;
        public int Pop
        {

            get
            {
                return pop;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    pop = value;
                else

                    MessageBox.Show("Pop Skill must be between 1 and 5");


            }


        }

        private int front;
        public int Front
        {

            get
            {
                return front;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    front = value;
                else

                    MessageBox.Show("Front Skill must be between 1 and 5");


            }


        }

        private int rear;
        public int Rear
        {

            get
            {
                return rear;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    rear = value;
                else

                    MessageBox.Show("Rear Skill must be between 1 and 5");


            }


        }

        private int side;
        public int Side
        {

            get
            {
                return side;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    side = value;
                else

                    MessageBox.Show("Side Skill must be between 1 and 5");


            }


        }

        private int scrabble;
        public int Scrabble
        {

            get
            {
                return scrabble;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    scrabble = value;
                else

                    MessageBox.Show("Scrabble Skill must be between 1 and 5");


            }


        }

        private int drop;
        public int Drop
        {

            get
            {
                return drop;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    drop = value;
                else

                    MessageBox.Show("Drop Skill must be between 1 and 5");


            }


        }

        private int punt;
        public int Punt
        {

            get
            {
                return punt;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    punt = value;
                else

                    MessageBox.Show("Punt Skill must be between 1 and 5");


            }


        }

        private int grubber;
        public int Grubber
        {

            get
            {
                return grubber;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    grubber = value;
                else

                    MessageBox.Show("Grubber Skill must be between 1 and 5");


            }


        }

        private int goal;
        public int Goal
        {

            get
            {
                return goal;
            }


            set
            {
                if (value >= 1 && value <= 5)
                    goal = value;
                else

                    MessageBox.Show("Goal Skill must be between 1 and 5");


            }


        }

        #endregion

        // use to temporary store comments from coach
        public string Comments { get; set; }

        // use to return a string format from the player details
        public string FullInfo
        {
            get
            {
                return $"{SRU}  {Name}  {DOB}  {PhoneNumber}  {Email}  {Age}";
            }

        }

        

     


    }
}
