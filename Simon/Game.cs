using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Windows.Forms;
// test commits


namespace Simon
{
    public partial class Game : UserControl
    {
        //random number to select the next item in the pattern.
        public static Random randNum = new Random();

        //global variables
        int guessIndex = 0;
        int pressValue = 0;

        SoundPlayer mistake = new SoundPlayer(Properties.Resources.mistake);

        public Game()
        {
            InitializeComponent();
        }       
        //resets stored pattern and gives user 3 seconds to take in the game screen.
        private void Game_Load(object sender, EventArgs e)
        {
            Form1.pattern.Clear();

            //let user see the game screen for 3 seconds
            Refresh();
            Thread.Sleep(3000);
            ComputerTurn();
        }

        public void ComputerTurn()
        {
            Thread.Sleep(500);
            // new random number (random colour)
            int rand = randNum.Next(1, 5);
            Form1.pattern.Add(rand);

            for (int i = 0; i < Form1.pattern.Count(); i++)
            {
                //flash colour of correct box depending on value.
                //*fix*button texts change to "1" to see 1st colour as the program sleeps through the first ComputerTurn
                if (Form1.pattern[i] == 1)
                {
                    greenButton.BackColor = Color.Lime;
                    Thread.Sleep(500);
                    Refresh();
                    greenButton.BackColor = Color.Green;
                    greenButton.Text = "1";
                }
                else if (Form1.pattern[i] == 2)
                {
                    redButton.BackColor = Color.Red;
                    Thread.Sleep(500);
                    Refresh();
                    redButton.BackColor = Color.DarkRed;
                    redButton.Text = "1";
                }
                else if (Form1.pattern[i] == 3)
                {
                    blueButton.BackColor = Color.Blue;
                    Thread.Sleep(500);
                    Refresh();
                    blueButton.BackColor = Color.RoyalBlue;
                    blueButton.Text = "1";
                }
                else if (Form1.pattern[i] == 4)
                {
                    yellowButton.BackColor = Color.Yellow;
                    Thread.Sleep(500);
                    Refresh();
                    yellowButton.BackColor = Color.Goldenrod;
                    yellowButton.Text = "1";
                }
                Thread.Sleep(500);
                guessIndex = 0;
                Refresh();
            }
        }
        public void PlayerTurn()
        {
                //correct button
                if (pressValue == Form1.pattern[guessIndex])
                {
                    //flash all colours white
                    yellowButton.BackColor = Color.White;
                    blueButton.BackColor = Color.White;
                    redButton.BackColor = Color.White;
                    greenButton.BackColor = Color.White;

                    Refresh();
                    Thread.Sleep(200);

                    yellowButton.BackColor = Color.Goldenrod;
                    blueButton.BackColor = Color.RoyalBlue;
                    redButton.BackColor = Color.DarkRed;
                    greenButton.BackColor = Color.Green;

                Refresh();

                //if finished the list, computer turn starts again, otherwise repeat
                if (guessIndex == Form1.pattern.Count() - 1)
                {
                    ComputerTurn();
                }
                else
                {
                    guessIndex++;
                }

            }
                //incorrect runs GameOver
                else
                {
                    mistake.Play();
                    GameOver();
                }
        }
        public void GameOver()
        {
            // go to Game Over user control to display score
            Form f = this.FindForm();
            GameOver go = new GameOver();
            f.Controls.Add(go);
            f.Controls.Remove(this);
            go.Location = new Point((this.Width - go.Width) / 2, (this.Height - go.Height) / 2);
        }
        #region Button Press Events
        //green button = 1
        private void greenButton_Click(object sender, EventArgs e)
        {
            pressValue = 1;
            PlayerTurn();
        }
        //red button = 2
        private void redButton_Click(object sender, EventArgs e)
        {
            pressValue = 2;
            PlayerTurn();
        }
        //blue button = 3
        private void blueButton_Click(object sender, EventArgs e)
        {
            pressValue = 3;
            PlayerTurn();
        }
        //yellow button = 4
        private void yellowButton_Click(object sender, EventArgs e)
        {
            pressValue = 4;
            PlayerTurn();
        }
        #endregion
    }
}
