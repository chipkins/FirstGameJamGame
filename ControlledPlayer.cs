#region Using Statements
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class ControlledPlayer
    {
        //Fields
        Ball ball;
        List<Player> teamMates;
        List<Player> control;
        Goal goal;

        /// <summary>
        /// Creates a new player controller
        /// </summary>
        /// <param name="b">Ball being used</param>
        /// <param name="tM">List of players on same team</param>
        /// <param name="c">List of the players being controlled, should only contain 1 player at a time</param>
        /// <param name="g">Goal trying to score on</param>
        public ControlledPlayer(Ball b, List<Player> tM, List<Player> c, Goal g)
        {
            ball = b;
            teamMates = tM;
            control = c;
            goal = g;
        }

        /// <summary>
        /// Removes the currently controled player, removes the soon to be controlled caracter from the team mates list 
        /// and adds it to the control list
        /// </summary>
        /// <param name="player">Player to be controlled</param>
        public void SwitchControl(Player player)
        {
            teamMates.Remove(player);
            if (control.Count > 0)
            {
                control.RemoveAt(0);
            }
            control.Add(player);
        }

        /// <summary>
        /// Finds the closest team mate to the controlled player
        /// </summary>
        /// <param name="player">Player acting as origion</param>
        /// <returns>Returns the closest team mate</returns>
        public Player closestTeamMate(Player player)
        {
            double closePlayer = 1000;
            double playerDistance;
            List<Player> closePlayers = new List<Player>();
            for (int n = 1; n < teamMates.Count; n++)
            {
                playerDistance = (Vector2.Distance(player.position, teamMates[n].position));
                if (playerDistance < closePlayer)
                {
                    closePlayer = playerDistance;
                    closePlayers.Add(teamMates[n]);
                }
            }
            return closePlayers[closePlayers.Count - 1];
        }

        /// <summary>
        /// Recieves inputs from user and moves player accordingly
        /// </summary>
        public void Update()
        {
            //Sets player being moved from the control list
            Player player = control[0];
            if (KeyboardHelper.IsKeyDown(KeyCode.Right))
            {
                player.position.X += 5;
                player.momentumX = 20;
                player.playerFace = 2;
            }

            if (KeyboardHelper.IsKeyDown(KeyCode.Left))
            {
                player.position.X -= 5;
                player.momentumX = -20;
                player.playerFace = 4;
            }

            if (KeyboardHelper.IsKeyDown(KeyCode.Up))
            {
                player.position.Y -= 5;
                player.momentumY = -20;
                player.playerFace = 1;
            }

            if (KeyboardHelper.IsKeyDown(KeyCode.Down))
            {
                player.position.Y += 5;
                player.momentumY = 20;
                player.playerFace = 3;
            }

            //Space will pass the ball
            if (KeyboardHelper.IsKeyDown(KeyCode.Space))
            {
                if (player.hasBall)
                {
                    double shortDistance = 1000;
                    double passDistance;
                    List<Player> passee = new List<Player>();
                    for (int n = 1; n < teamMates.Count; n++)
                    {
                        passDistance = (Vector2.Distance(player.position, teamMates[n].position));
                        if (passDistance < shortDistance)
                        {
                            shortDistance = passDistance;
                            passee.Add(teamMates[n]);
                        }
                    }
                    ball.Pass(player, passee[passee.Count - 1]);
                    ball.isPassed = true;
                }
            }

            //X will shoot the ball
            if(KeyboardHelper.IsKeyDown(KeyCode.Key_X))
            {
                if (player.hasBall)
                {
                    ball.Shoot(player, goal);
                    ball.isShot = true;
                }
            }

            //Z will change player being controlled to closest team mate
            if(KeyboardHelper.IsKeyDown(KeyCode.Key_Z))
            {
                teamMates.Add(player);
                SwitchControl(closestTeamMate(player));
            }
        }
    }
}
