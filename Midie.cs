#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace GameJamFall2014
{
    class Midie: Player
    {
        //Fields
        public Vector2 attackPosition;
        public Vector2 defensePosition;
        ScrollingBackground sB;
        public float goToAttack;
        public float goToDefense;

        /// <summary>
        /// Creates a new Attackman
        /// </summary>
        /// <param name="text">Player's texture sprite</param>
        /// <param name="bM">Texture sprite for icon marking player with the ball</param>
        /// <param name="x">Starting x position of player</param>
        /// <param name="y">Starting y position of the player</param>
        /// <param name="b">Ball being used</param>
        /// <param name="t">Team that player is on</param>
        /// <param name="p">Position that player plays</param>
        /// <param name="aP">Position that player will go to when team is on offense</param>
        /// <param name="dP">Position that player will go to when team is on defense</param>
        public Midie(Texture2D text, Texture2D bM, Vector2 sP, Ball b, Team t, Position p, Vector2 aP, Vector2 dP, ScrollingBackground sB) :
            base(text, bM, sP, b, t, p)
        {
            attackPosition = aP;
            defensePosition = dP;
            this.sB = sB;
            goToAttack = aP.Y;
            goToDefense = dP.Y;
        }

        /// <summary>
        /// Updates the player
        /// </summary>
        public override void Update()
        {
            attackPosition.Y = goToAttack + sB.screenPos.Y;
            defensePosition.Y = goToDefense + sB.screenPos.Y;

            if (position.Y < 0)
                position.Y = 0;

            if (position.Y > 575)
                position.Y = 575;

            if (position.X < 0)
                position.X = 0;

            if (position.X > 760)
                position.X = 760;

            base.Update();
        }
    }
}
