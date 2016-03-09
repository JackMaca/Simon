using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon
{
    public partial class GameOver : UserControl
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            //display the user's score
            scoreLabel.Text = "You got " + (Form1.pattern.Count - 1).ToString() + " in a row!";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //return to main screen on button click
            Form f = this.FindForm();
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
            f.Controls.Remove(this);
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }
    }
}
