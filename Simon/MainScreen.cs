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
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        //closes the program
        private void exitButton_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        //opens the game user control
        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            Game gm = new Game();
            f.Controls.Add(gm);
            f.Controls.Remove(this);
            gm.Location = new Point((this.Width - gm.Width) / 2, (this.Height - gm.Height) / 2);
        }
    }
}
