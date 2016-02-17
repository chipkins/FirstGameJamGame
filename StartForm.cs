#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace GameJamFall2014
{
    public partial class StartForm : Form
    {
        private Bitmap background;
        private Game1 game;

        public StartForm()
        {
            background = new Bitmap("StartScreen.bmp");
            InitializeComponent();
            pictureBox1.Image = (Image)background;
        }

#if WINDOWS || LINUX
        private void startButton_Click(object sender, EventArgs e)
        {
            using (var game = new Game1())
                game.Run();
        }

        private void optionButton_Click(object sender, EventArgs e)
        {
            Instructions help = new Instructions();
            help.ShowDialog();
        }
#endif
    }
}
