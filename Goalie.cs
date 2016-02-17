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
    class Goalie: Player
    {
        public static Random save;
        public int savePecentage;

        ScrollingBackground sB;

        /// <summary>
        /// Creates a new Goalie
        /// </summary>
        /// <param name="text">Player's texture sprite</param>
        /// <param name="bM">Texture sprite for icon marking player with ball</param>
        /// <param name="x">Starting x position</param>
        /// <param name="y">Starting y position</param>
        /// <param name="b">Ball being used</param>
        /// <param name="t">Team that player is on</param>
        /// <param name="p">Position that player plays</param>
        /// <param name="saveP">Percent of shots goalie will save</param>
        public Goalie(Texture2D text, Texture2D bM, Vector2 sP, Ball b, Team t, Position p, int saveP, ScrollingBackground sB):
            base(text, bM, sP, b, t, p)
        {
            save = new Random();
            savePecentage = saveP;
            this.sB = sB;
        }

        /// <summary>
        /// Randomly checks to see if the goalie will make a save
        /// </summary>
        /// <param name="ball">Ball that was shot</param>
        /// <returns>Whether or not the Goalie saved the shot</returns>
        public bool MakeSave(Ball ball)
        {
            if (save.Next(100) < savePecentage)
                return true;
            else
                return false;
        }

        public override void Update()
        {
            if(team == Team.One)
            {
                position.Y = 860 + sB.screenPos.Y;
            }

            if (team == Team.Two)
            {
                position.Y = 110 + sB.screenPos.Y;
            }
            base.Update();
        }
    }
}
