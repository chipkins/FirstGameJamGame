#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace GameJamFall2014
{
    class Goal
    {
        //Fields
        public Rectangle net;
        public Team team;
        public int score1;
        public int score2;
        public int netLocation;
        public bool goalScored;
        Ball ball;
        ScrollingBackground sB;

        /// <summary>
        /// Creates a new goal
        /// </summary>
        /// <param name="x">Starting x position</param>
        /// <param name="y">Starting y position</param>
        /// <param name="b">Ball being used</param>
        /// <param name="t">Team goal belongs to</param>
        public Goal(int x, int y, Ball b, Team t, ScrollingBackground sB)
        {
            net = new Rectangle(x, y, 80, 1);
            team = t;
            ball = b;
            netLocation = y;
            this.sB = sB;
        }

        /// <summary>
        /// Determines whether a goal has been scored
        /// </summary>
        public void Update()
        {
            net.Y = netLocation + (int)sB.screenPos.Y;
            if (net.Intersects(ball.collisionBox))
            {
                if (team == Team.One)
                    score2++;
                else
                    score1++;

                goalScored = true;
            }
                
        }
    }
}
