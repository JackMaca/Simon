/// Jack MacAlpine
/// March 2, 2016
/// Simon Game - copy the pattern of colours that the computer chooses
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon
{
    public partial class Form1 : Form
    {
        //list to store the pattern
        public static List<int> pattern = new List<int>();

        public Form1()
        {
            InitializeComponent();

            //opens Mainscreen user control
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            ms.Show();
        }
    }
}
