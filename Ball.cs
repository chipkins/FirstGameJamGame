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
    class Ball
    {
        //Feilds
        public Vector2 position;
        public Vector2 startingPosition;
        public Texture2D texture;
        public Rectangle collisionBox;
        private Random rand;
        private Player guyWithBall;
        private Player target;
        private Goal goal;
        public int distancetraveledX = 0;
        public int distancetraveledY = 0;
        public bool isGB = true;
        public bool isPassed = false;
        public bool isShot = false;

        /// <summary>
        /// Creates a new ball
        /// </summary>
        /// <param name="text">Ball's Sprite</param>
        /// <param name="x">Ball's initial x position</param>
        /// <param name="y">Ball's initial y position</param>
        public Ball(Texture2D text, Vector2 sP)
        {
            texture = text;
            startingPosition = sP;
            position = startingPosition;
            collisionBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            rand = new Random();
        }
        
        /// <summary>
        /// Method has player pick up the ball and stops the ball from being thrown
        /// </summary>
        /// <param name="gBMan">Player that picks up ball</param>
        public void PickUp(Player gBMan)
        {
            gBMan.hasBall = true;
            isGB = false;
            isPassed = false;
            isShot = false;
            distancetraveledX = 0;
            distancetraveledY = 0;
            
        }

        /// <summary>
        /// Method has player drop ball, moving it a random distance away
        /// </summary>
        /// <param name="gBMan">Player that drops ball</param>
        public void DropBall(Player gBMan)
        {
            gBMan.hasBall = false;
            isGB = true;
            
            position.X += rand.Next(-100, 100);
            position.Y += rand.Next(-100, 100);
        }

        /// <summary>
        /// Passes the ball to a team mate, ball will only travel 400 pixels before stopping
        /// </summary>
        /// <param name="passer">player passing the ball</param>
        /// <param name="target">player recieving the ball</param>
        public void Pass(Player passer, Player target)
        {
            passer.hasBall = false;
            isGB = true;
            guyWithBall = passer;
            this.target = target;
        }

        /// <summary>
        /// Shots the ball at the goal, only tavels 400 pixels before stopping
        /// </summary>
        /// <param name="shooter"></param>
        /// <param name="goal"></param>
        public void Shoot(Player shooter, Goal goal)
        {
            shooter.hasBall = false;
            isGB = true;
            guyWithBall = shooter;
            this.goal = goal;
        }

        /// <summary>
        /// Keeps the ball within the field of play
        /// </summary>
        public void Update()
        {
            if (position.X < 0)
                position.X = 0;

            if (position.X > 800)
                position.X = 800;

            if (position.Y < 0)
                position.Y = 0;

            if (position.Y > 1200)
                position.Y = 1200;

            if (isPassed)
            {
                if ((distancetraveledX + distancetraveledY) < 400)
                {
                    if (position.X > target.position.X)
                    {
                        position.X -= 10;
                        distancetraveledX += 10;
                    }

                    if (position.X < target.position.X)
                    {
                        position.X += 10;
                        distancetraveledX += 10;
                    }

                    if (position.Y < target.position.Y)
                    {
                        position.Y += 10;
                        distancetraveledY += 10;
                    }

                    if (position.Y > target.position.Y)
                    {
                        position.Y -= 10;
                        distancetraveledY += 10;
                    }
                }
            }

            if(isShot)
            {
                if ((distancetraveledX + distancetraveledY) < 400)
                {
                    if (position.X > goal.net.X + 40)
                    {
                        position.X -= 10;
                        distancetraveledX += 10;
                    }

                    if (position.X < goal.net.X + 40)
                    {
                        position.X += 10;
                        distancetraveledX += 10;
                    }

                    if (position.Y < goal.net.Y)
                    {
                        position.Y += 10;
                        distancetraveledY += 10;
                    }

                    if (position.Y > goal.net.Y)
                    {
                        position.Y -= 10;
                        distancetraveledY += 10;
                    }
                }
            }

            collisionBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        /// <summary>
        /// Draws the ball at its current position
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
