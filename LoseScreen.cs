using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameJamFall2014
{
    public partial class LoseScreen : Form
    {
        private Bitmap background;
        private Game1 game;

        public LoseScreen()
        {
            background = new Bitmap("StartScreen.bmp");
            InitializeComponent();
            pictureBox1.Image = (Image)background;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
