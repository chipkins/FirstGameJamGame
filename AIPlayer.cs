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
    class AIPlayer
    {
        //Fields
        Ball ball;
        Goal goal;
        List<Player> opponents;
        List<Player> teamMates;
        static Random rand;

        /// <summary>
        /// Creates a new AI Player
        /// </summary>
        /// <param name="b">Ball used for play</param>
        /// <param name="g">Goal to be scored on</param>
        /// <param name="o">List of opponents</param>
        /// <param name="tM">List of Team Mates</param>
        public AIPlayer(Ball b, Goal g, List<Player> o, List<Player> tM)
        {
            ball = b;
            goal = g;
            opponents = o;
            teamMates = tM;
            rand = new Random();
        }

        /// <summary>
        /// Method returns the closest player of the opposing team
        /// </summary>
        /// <param name="player">Player to be compared to</param>
        /// <returns>Opponent cosest to 'player'</returns>
        public Player closestPlayer(Player player)
        {
            double closePlayer = 1000;
            double playerDistance;
            List<Player> closePlayers = new List<Player>();
            for (int n = 1; n < opponents.Count; n++)
            {
                playerDistance = (Vector2.Distance(player.position, opponents[n].position));
                if (playerDistance < closePlayer)
                {
                    closePlayer = playerDistance;
                    closePlayers.Add(opponents[n]);
                }
            }
            if (closePlayers.Count == 0)
                return null;
            else
                return closePlayers[closePlayers.Count - 1];
        }

        /// <summary>
        /// If an opponent gets to close, finds the closest team mate and throws them the ball
        /// </summary>
        /// <param name="player">Player with ball</param>
        public void Throw(Player player)
        {
            //Loops through opposing roster
            for(int i = 1; i < opponents.Count; i++)
            {
                //Determins if any opponents are intruding on personal space and randomly decides if ball should be thrown
                if (player.personalSpace.Intersects(opponents[i].collisionBox) && rand.Next(100) < 25)
                {
                    //Determines the closest team mate
                    double shortDistance = 1000;
                    double passDistance;
                    //List adds players who are closer to player than players already in the list, last person is closest team mate
                    List<Player> passee = new List<Player>();
                    for(int n = 1; n < teamMates.Count; n++)
                    {
                        passDistance = (Vector2.Distance(player.position, teamMates[n].position));
                        if(passDistance < shortDistance)
                        {
                            shortDistance = passDistance;
                            passee.Add(teamMates[n]);
                        }
                    }
                    //Passes the ball to last player in the passee list
                    ball.Pass(player, passee[passee.Count - 1]);
                    ball.isPassed = true;
                }
            }
        }

        /// <summary>
        /// If gets close to the net then shoots at the net
        /// </summary>
        /// <param name="player">Player with ball</param>
        public void Shoot(Player player)
        {
            if(player.shootingSpace.Intersects(goal.net))
            {
                ball.Shoot(player, goal);
                ball.isShot = true;
            }
        }

        public void MovePlayer(Player player, Vector2 position)
        {
            if (position.X > player.position.X)
            {
                player.position.X += 3;
                player.momentumX = 10;
                player.playerFace = 2;
            }

            else if (position.X < player.position.X)
            {
                player.position.X -= 3;
                player.momentumX = -10;
                player.playerFace = 4;
            }

            else if (position.Y > player.position.Y)
            {
                player.position.Y += 3;
                player.momentumY = 10;
                player.playerFace = 1;
            }

            else if (position.Y < player.position.Y)
            {
                player.position.Y -= 3;
                player.momentumY = -10;
                player.playerFace = 3;
            }

            else
            {
                player.momentumX = 0;
                player.momentumY = 0;
            }
        }

        /// <summary>
        /// All the logic for the AI
        /// </summary>
        /// <param name="player">Player to be updated</param>
        public void Update(Player player)
        {
            //Closest opponent to player
            Player target = closestPlayer(player);

            //If doesn't have ball
            if(player.hasBall == false)
            {
                //if ball is on the ground
                if(ball.isGB == true)
                {
                    //Head towards the ball
                    MovePlayer(player, ball.position);
                }

                //If ball is not on the ground
                else
                {
                    //If player's team has the ball
                    if(player.TeamHasBall() == true)
                     {
                        //Determines the player's offensive course of action based on the position they play
                        if(player.post == Position.Defense)
                        {
                            MovePlayer(player, (player as Defense).attackPosition);
                        }

                        else if(player.post == Position.Midie)
                        {
                            MovePlayer(player, (player as Midie).attackPosition);
                        }

                        else if(player.post == Position.Attack)
                        {
                            MovePlayer(player, (player as Attack).attackPosition);
                        }
                    }
                    //If team doesn't have the ball
                    else
                    {
                        //Determine's the player's defensive courve of action depending on position
                        if (player.post == Position.Defense)
                        {
                            MovePlayer(player, (player as Defense).defensePosition);
                        }

                        else if (player.post == Position.Midie)
                        {
                            MovePlayer(player, (player as Midie).defensePosition);
                        }

                        else if (player.post == Position.Attack)
                        {
                            MovePlayer(player, (player as Attack).defensePosition);
                        }

                        //If the closest opponent to the player has the ball, pursues them
                        if(target.hasBall == true)
                        {
                                MovePlayer(player, target.position);
                        }
                    }
                }
            }

            //If player does have the ball then heads towrads the goal
            else
            {
                if (player.position.X < goal.net.X)
                {
                    player.position.X += 3;
                    player.momentumX = 10;
                    player.playerFace = 2;
                }

                if (player.position.X > goal.net.X)
                {
                    player.position.X -= 3;
                    player.momentumX = -10;
                    player.playerFace = 4;
                }

                if (player.position.Y > goal.net.Y)
                {
                    player.position.Y -= 3;
                    player.momentumY = -10;
                    player.playerFace = 1;
                }

                if (player.position.Y < goal.net.Y)
                {
                    player.position.Y += 3;
                    player.momentumY = 10;
                    player.playerFace = 3;
                }

                else
                {
                    player.momentumX = 0;
                    player.momentumY = 0;
                }

                //Determines if player shoud throw or shoot the ball
                Throw(player);
                Shoot(player);
            }                     
        }
    }
}
