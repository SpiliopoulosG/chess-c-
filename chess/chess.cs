using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace chess
{
    public partial class Chess : Form
    {
        static Random rand = new Random();
        public Chess() {
            InitializeComponent();
            Player1.Text = GenerateRandomName();
            Player2.Text = GenerateRandomName();
            TimeLimit.Text = "10:00";
            this.FormBorderStyle = FormBorderStyle.None; 
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(400, 240);
            this.Select();
        }

        private void cross_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void startGame_Click_1(object sender, EventArgs e) {
            if (Player1.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) && Player2.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))) {
                string timer = TimeLimit.Text;
                bool validtimer = Regex.IsMatch(timer, @"^[0-9]?[0-9]:[0-9][0-9]$");
                if (validtimer) {
                    this.Hide();

                    ChessGame form = new ChessGame();
                    form.Show();
                    ChessGame.instance.player1Label.Text = Player1.Text;
                    ChessGame.instance.player2Label.Text = Player2.Text;
                    ChessGame.instance.tb1.Text = TimeLimit.Text;
                    ChessGame.instance.tb2.Text = TimeLimit.Text;
                }
                else { 
                    MessageBox.Show("Time Limit should contain only numbers in the Form of 12:02 "); 
                }
            }
            else {
                MessageBox.Show("Players name should contain only text");
            }
        }

        private void history_Click(object sender, EventArgs e) {

        }

        static string GenerateRandomName()
        {
            List<string> colors = new List<string> { "Red", "Blue", "Green", "Yellow", "Purple", "Orange", "Pink", "Brown", "Gray", "White", "Turquoise", "Magenta", "Lime", "Teal", "Indigo", "Cyan", "Olive", "Maroon", "Navy", "Aqua", "Salmon", "Violet", "Gold", "Silver", "Bronze" };
            List<string> animals = new List<string> { "Lion", "Elephant", "Monkey", "Tiger", "Giraffe", "Penguin", "Snake", "Kangaroo", "Zebra", "Hippo", "Cheetah", "Panda", "Koala", "Gorilla", "Leopard", "Rhino", "Dolphin", "Ostrich", "Peacock", "Sloth", "Chameleon", "Jaguar", "Koala", "Polar Bear", "Flamingo" };

            string randomColor = colors[rand.Next(colors.Count)];
            string randomAnimal = animals[rand.Next(animals.Count)];

            return $"{randomColor} {randomAnimal}";
        }
    }
}
