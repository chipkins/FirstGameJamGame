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
    class Player
    {
        //Fields
        public Vector2 position;
        public Vector2 startingPosition;
        public Texture2D texture;
        public Texture2D ballMarker;
        public Rectangle collisionBox;
        public Rectangle personalSpace;
        public Rectangle shootingSpace;
        public Ball ball;
        public int momentumX = 0;
        public int momentumY = 0;
        public bool hasBall = false;
        public int playerFace = 1;
        public Team team;
        public Position post;
        public bool teamHasBall;

        /// <summary>
        /// Creates a new Player
        /// </summary>
        /// <param name="text">Player's texture sprite</param>
        /// <param name="bM">Texture sprite for icon marking player with the ball</param>
        /// <param name="x">Starting x position of player</param>
        /// <param name="y">Starting y position of the player</param>
        /// <param name="b">Ball being used</param>
        /// <param name="t">Team that player is on</param>
        /// <param name="p">Position that player plays</param>
        public Player(Texture2D text, Texture2D bM, Vector2 sP, Ball b, Team t, Position p)
        {
            texture = text;
            ballMarker = bM;
            startingPosition = sP;
            position = startingPosition;
            collisionBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            personalSpace = new Rectangle((int)position.X, (int)position.Y, texture.Width + 50, texture.Height + 50);
            shootingSpace = new Rectangle((int)position.X, (int)position.Y, texture.Width + 200, texture.Height + 200);
            ball = b;
            team = t;
            post = p;
        }

        /// <summary>
        /// Reaction from when 2 players collide
        /// the ball is dropped if one was carrying it
        /// the player that got hit is knocked back
        /// </summary>
        /// <param name="hitMan">Opponent who hit the player</param>
        public void CollisionReaction(Player hitMan)
        {
            position = new Vector2(position.X + hitMan.momentumX, position.Y + hitMan.momentumY);
            collisionBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            personalSpace = new Rectangle((int)position.X, (int)position.Y, texture.Width + 50, texture.Height + 50);
            shootingSpace = new Rectangle((int)position.X, (int)position.Y, texture.Width + 200, texture.Height + 200);
        }

        /// <summary>
        /// Moves the ball along with the player
        /// </summary>
        /// <param name="ball"></param>
        public void CarryBall(Ball ball)
        {
            ball.position.X = position.X;
            ball.position.Y = position.Y;
        }

        /// <summary>
        /// Returns whether or not the player's team has the ball
        /// </summary>
        /// <returns></returns>
        public bool TeamHasBall()
        {
            return teamHasBall;
        }

        /// <summary>
        /// Updates the player's status
        /// </summary>
        public virtual void Update()
        {
            if(hasBall == true)
            {
                CarryBall(ball);
            }

            collisionBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            personalSpace = new Rectangle((int)position.X, (int)position.Y, texture.Width + 50, texture.Height + 50);
            shootingSpace = new Rectangle((int)position.X, (int)position.Y, texture.Width + 200, texture.Height + 200);
        }

        /// <summary>
        /// Draws the player
        /// If player has the ball, draws a blue triangle under him
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (hasBall)
                spriteBatch.Draw(ballMarker, position, Color.White);

            spriteBatch.Draw(texture, position, Color.White);

        }
    }
}
