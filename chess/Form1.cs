using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class Chess : Form
    {
        public Chess()
        {
            InitializeComponent();
            TimeLimit.Text = "00:00";
        }

        private void StartGame_Click(object sender, EventArgs e)
        {   
            //checkarei an einai ola letters 
            if(Player1.Text.All(char.IsLetter)&& Player2.Text.All(char.IsLetter) )
            {
                //checkarei to timer na einai se morfi 12:00 to prwto number einai proeraitiko (?)
                string timer = TimeLimit.Text;
                bool validtimer = Regex.IsMatch(timer, @"^[0-9]?[0-9]:[0-9][0-9]$");
                if (validtimer)
                {
                    Form2 form = new Form2();
                    form.Show();
                    Form2.instance.lab1.Text = Player1.Text;
                    Form2.instance.lab2.Text = Player2.Text;
                    Form2.instance.tb1.Text = TimeLimit.Text;
                    Form2.instance.tb2.Text = TimeLimit.Text;
                }
                else { MessageBox.Show("Time Limit should contain only numbers in the Form of 12:02 "); }             
            } 
            else {
                MessageBox.Show("Players name should contain only text");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
