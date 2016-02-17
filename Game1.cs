#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace GameJamFall2014
{
    public enum Team
    {
        One,
        Two
    }

    public enum Position
    {
        Defense,
        Midie,
        Attack,
        Goalie
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static KeyboardState KBSTATE;
        public Texture2D field;
        private List<Player> laxTeam1 = new List<Player>();
        private List<Player> laxTeam2 = new List<Player>();
        private List<Player> control = new List<Player>();
        private ControlledPlayer controlee;
        private AIPlayer zombie1;
        private AIPlayer zombie2;
        private Ball ball;
        private Texture2D goalie;
        private Texture2D shortStick;
        private Texture2D longStick;
        private Texture2D goalie2;
        private Texture2D shortStick2;
        private Texture2D longStick2;
        private Texture2D ballMarker;
        public SpriteFont font;
        private Goal goal1;
        private Goal goal2;
        public Texture2D colon;
        public Texture2D hyphen;
        public Texture2D zero;
        public Texture2D one;
        public Texture2D two;
        public Texture2D three;
        public Texture2D four;
        public Texture2D five;
        public Texture2D six;
        public Texture2D seven;
        public Texture2D eight;
        public Texture2D nine;
        private ScoreBoard scoreBoard;
        ScrollingBackground myBackground = new ScrollingBackground();
        
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            field = Content.Load<Texture2D>("LacrosseField.bmp");
            myBackground.Load(GraphicsDevice, field);
            ball = new Ball(Content.Load<Texture2D>("Ball"), new Vector2(392, 290));
            ballMarker = Content.Load<Texture2D>("BallMarker.bmp");
            //font = Content.Load<SpriteFont>("kooten.ttf");
            goal1 = new Goal(360, 920, ball, Team.One, myBackground);
            goal2 = new Goal(360, 110, ball, Team.Two, myBackground);
            scoreBoard = new ScoreBoard(Content.Load<Texture2D>("Colon.bmp"), Content.Load<Texture2D>("Hyphen.png"), Content.Load<Texture2D>("Zero.bmp"), Content.Load<Texture2D>("One.bmp"), Content.Load<Texture2D>("Two.bmp"), Content.Load<Texture2D>("Three.bmp"), Content.Load<Texture2D>("Four.bmp"), Content.Load<Texture2D>("Five.bmp"), Content.Load<Texture2D>("Six.bmp"), Content.Load<Texture2D>("Seven.bmp"), Content.Load<Texture2D>("Eight.bmp"), Content.Load<Texture2D>("Nine.png"), goal1, goal2);

            controlee = new ControlledPlayer(ball, laxTeam1, control, goal2);
            zombie1 = new AIPlayer(ball, goal2, laxTeam2, laxTeam1);
            zombie2 = new AIPlayer(ball, goal1, laxTeam1, laxTeam2);

            //Loads team1's sprites
            goalie = Content.Load<Texture2D>("LacrossePlayerG.bmp");
            shortStick = Content.Load<Texture2D>("LacrossePlayerSS.bmp");
            longStick = Content.Load<Texture2D>("LacrossePlayerLS.bmp");

            //Loads team2's sprites
            goalie2 = Content.Load<Texture2D>("LacrossePlayerG2.bmp");
            shortStick2 = Content.Load<Texture2D>("LacrossePlayerSS2.bmp");
            longStick2 = Content.Load<Texture2D>("LacrossePlayerLS2.bmp");

            //Adds players to team1
            laxTeam1.Add(new Goalie(goalie, ballMarker, new Vector2(380, 860 + (int)myBackground.screenPos.Y), ball, Team.One, Position.Goalie, 60, myBackground));
            laxTeam1.Add(new Defense(longStick, ballMarker, new Vector2(250, 450), ball, Team.One, Position.Defense, new Vector2(250, 550), new Vector2(250, 875), myBackground));
            laxTeam1.Add(new Defense(longStick, ballMarker, new Vector2(400, 450), ball, Team.One, Position.Defense, new Vector2(400, 550), new Vector2(385, 800), myBackground));
            laxTeam1.Add(new Defense(longStick, ballMarker, new Vector2(550, 450), ball, Team.One, Position.Defense, new Vector2(550, 550), new Vector2(550, 875), myBackground));
            laxTeam1.Add(new Attack(shortStick, ballMarker, new Vector2(250, 150), ball, Team.One, Position.Attack, new Vector2(175, 125), new Vector2(250, 460), myBackground));
            laxTeam1.Add(new Attack(shortStick, ballMarker, new Vector2(400, 150), ball, Team.One, Position.Attack, new Vector2(385, 65), new Vector2(400, 460), myBackground));
            laxTeam1.Add(new Attack(shortStick, ballMarker, new Vector2(550, 150), ball, Team.One, Position.Attack, new Vector2(635, 125), new Vector2(550, 460), myBackground));
            laxTeam1.Add(new Midie(shortStick, ballMarker, new Vector2(100, 350), ball, Team.One, Position.Midie, new Vector2(225, 225), new Vector2(275, 775), myBackground));
            laxTeam1.Add(new Midie(shortStick, ballMarker, new Vector2(660, 250), ball, Team.One, Position.Midie, new Vector2(385, 250), new Vector2(385, 750), myBackground));
            laxTeam1.Add(new Midie(shortStick, ballMarker, new Vector2(385, 350), ball, Team.One, Position.Midie, new Vector2(525, 250), new Vector2(475, 775), myBackground));
            controlee.SwitchControl(laxTeam1[laxTeam1.Count - 1]);

            //Adds players to team2
            laxTeam2.Add(new Goalie(goalie2, ballMarker, new Vector2(380, 110 + (int)myBackground.screenPos.Y), ball, Team.Two, Position.Goalie, 60, myBackground));
            laxTeam2.Add(new Defense(longStick2, ballMarker, new Vector2(250, 125), ball, Team.Two, Position.Defense, new Vector2(250, 420), new Vector2(250, 125), myBackground));
            laxTeam2.Add(new Defense(longStick2, ballMarker, new Vector2(400, 125), ball, Team.Two, Position.Defense, new Vector2(400, 420), new Vector2(385, 175), myBackground));
            laxTeam2.Add(new Defense(longStick2, ballMarker, new Vector2(550, 125), ball, Team.Two, Position.Defense, new Vector2(550, 420), new Vector2(550, 125), myBackground));
            laxTeam2.Add(new Attack(shortStick2, ballMarker, new Vector2(250, 425), ball, Team.Two, Position.Attack, new Vector2(175, 875), new Vector2(250, 510), myBackground));
            laxTeam2.Add(new Attack(shortStick2, ballMarker, new Vector2(400, 425), ball, Team.Two, Position.Attack, new Vector2(385, 965), new Vector2(400, 510), myBackground));
            laxTeam2.Add(new Attack(shortStick2, ballMarker, new Vector2(550, 425), ball, Team.Two, Position.Attack, new Vector2(625, 875), new Vector2(550, 510), myBackground));
            laxTeam2.Add(new Midie(shortStick2, ballMarker, new Vector2(100, 250), ball, Team.Two, Position.Midie, new Vector2(225, 750), new Vector2(275, 200), myBackground));
            laxTeam2.Add(new Midie(shortStick2, ballMarker, new Vector2(660, 350), ball, Team.Two, Position.Midie, new Vector2(385, 725), new Vector2(385, 225), myBackground));
            laxTeam2.Add(new Midie(shortStick2, ballMarker, new Vector2(385, 220), ball, Team.Two, Position.Midie, new Vector2(525, 750), new Vector2(475, 200), myBackground));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        //Clock variablea
        int countSeconds = 0;
        int countTenSecconds = 0;
        int countMinutes = 0;
        int secLimit = 10;
        int minLimit = 6;
        float countDuration = 1f; //every  2s.
        float currentTime = 0f;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape) || goal1.score2 == 10 || goal2.score1 == 10)
            {
                if(goal2.score1 == 10)
                {
                    WinScreen win = new WinScreen();
                    win.ShowDialog();
                }

                if(goal1.score2 == 10)
                {
                    LoseScreen lose = new LoseScreen();
                    lose.ShowDialog();
                }

                Exit();

            }

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            goal1.Update();
            goal2.Update();

            if(goal1.goalScored || goal2.goalScored)
            {
                myBackground.screenPos = new Vector2(0, -180);
                ball.position = ball.startingPosition;
                ball.isGB = true;
                control[0].position = control[0].startingPosition;

                for(int i = 0; i < laxTeam1.Count; i ++)
                {
                    laxTeam1[i].position = laxTeam1[i].startingPosition;
                    laxTeam1[i].teamHasBall = false;
                    laxTeam1[i].hasBall = false;
                }

                for (int x = 0; x < laxTeam2.Count; x++)
                {
                    laxTeam2[x].position = laxTeam2[x].startingPosition;
                    laxTeam2[x].teamHasBall = false;
                    laxTeam2[x].hasBall = false;
                }

                goal1.goalScored = false;
                goal2.goalScored = false;
            }

            //currentTime += (float)gameTime.TotalGameTime.TotalSeconds;

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Time passed since last Update() 

            if (currentTime >= countDuration)
            {
                countSeconds++;
                currentTime -= countDuration; // "use up" the time
                //any actions to perform
            }

            if(countSeconds == secLimit)
            {
                countTenSecconds++;
                countSeconds = 0;
            }

            if (countTenSecconds == minLimit)
            {
                countMinutes++;
                countTenSecconds = 0;
            }

            if(countMinutes == 2)
            {
                if(goal2.score1 > goal1.score2)
                {
                    WinScreen win = new WinScreen();
                    win.ShowDialog();
                }

                if(goal2.score1 <= goal1.score1)
                {
                    LoseScreen lose = new LoseScreen();
                    lose.ShowDialog();
                }

                Exit();
            }

            // TODO: Add your update logic here
            scoreBoard.Update(countSeconds, countTenSecconds, countMinutes);

            ball.Update();

            laxTeam1[0].Update();

            //Checks to see if ball contacts goalie1 starting calling the MakeSave method if true
            if (laxTeam1[0].collisionBox.Intersects(ball.collisionBox))
            {
                if ((laxTeam1[0] as Goalie).MakeSave(ball))
                {
                    ball.PickUp(laxTeam1[0]);
                    ball.Pass(laxTeam1[0], zombie1.closestPlayer(laxTeam1[0]));
                }               
            }

            for (int x = 0; x < laxTeam2.Count; x++)
            {
                if (control[0].collisionBox.Intersects(laxTeam2[x].collisionBox))
                {
                    control[0].CollisionReaction(laxTeam2[x]);
                    if (control[0].hasBall)
                    {
                        ball.DropBall(control[0]);
                        control[0].teamHasBall = false;
                    }
                }
            }

            //Checks if anyone is in contact and should pickup the ball
            if (control[0].collisionBox.Intersects(ball.collisionBox) && ball.isGB == true)
            {
                ball.PickUp(control[0]);
                control[0].teamHasBall = true;
            }

            //Updates the controlled player
            controlee.Update();
            control[0].Update();

            //Scrolls the backgrounds
            myBackground.Update(control[0], elapsed * 200);

            //Loops through rest of team1 to update them
            for (int i = 1; i < laxTeam1.Count; i++)
            {
                //Loops through other team to check for collisions
                for (int x = 0; x < laxTeam2.Count; x++)
                {
                    if (laxTeam1[i].collisionBox.Intersects(laxTeam2[x].collisionBox))
                    {
                        laxTeam1[i].CollisionReaction(laxTeam2[x]);
                        if (laxTeam1[i].hasBall)
                        {
                            ball.DropBall(laxTeam1[i]);
                            for (int q = 1; q < laxTeam1.Count; q++)
                            {
                                laxTeam1[q].teamHasBall = false;
                            }
                        }
                    }
                }

                //Checks if anyone is in contact and should pickup the ball
                if (laxTeam1[i].collisionBox.Intersects(ball.collisionBox) && ball.isGB == true)
                {
                    ball.PickUp(laxTeam1[i]);
                    laxTeam1.Add(control[0]);
                    controlee.SwitchControl(laxTeam1[i]);
                    for (int q = 1; q < laxTeam1.Count; q++)
                    {
                        laxTeam1[q].teamHasBall = true;
                    }
                }

                //Updates the AI players
                zombie1.Update(laxTeam1[i]);

                laxTeam1[i].Update();
            }

            //Same code for team2
            laxTeam2[0].Update();

            if (laxTeam2[0].collisionBox.Intersects(ball.collisionBox))
            {
                if ((laxTeam2[0] as Goalie).MakeSave(ball))
                {
                    ball.PickUp(laxTeam2[0]);
                    ball.Pass(laxTeam2[0], zombie2.closestPlayer(laxTeam2[0]));
                }
            }

            for (int j = 1; j < laxTeam2.Count; j++)
            {
                if (laxTeam2[j].collisionBox.Intersects(control[0].collisionBox))
                {
                    laxTeam2[j].CollisionReaction(control[0]);
                    if(control[0].hasBall)
                    ball.DropBall(laxTeam2[j]);

                    for (int q = 1; q < laxTeam2.Count; q++)
                    {
                        laxTeam2[q].teamHasBall = false;
                    }
                }
                for (int n = 0; n < laxTeam1.Count; n++)
                {
                    if (laxTeam2[j].collisionBox.Intersects(laxTeam1[n].collisionBox))
                    {
                        laxTeam2[j].CollisionReaction(laxTeam1[n]);
                        if (laxTeam2[j].hasBall)
                        {
                            ball.DropBall(laxTeam2[j]);
                            for (int q = 1; q < laxTeam2.Count; q++)
                            {
                                laxTeam2[q].teamHasBall = false;
                            }
                        }
                    }
                }

                if (laxTeam2[j].collisionBox.Intersects(ball.collisionBox) && ball.isGB == true)
                {
                    ball.PickUp(laxTeam2[j]);
                    for (int q = 1; q < laxTeam2.Count; q++)
                    {
                        laxTeam2[q].teamHasBall = true;
                    }
                }

                zombie2.Update(laxTeam2[j]);

                laxTeam2[j].Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Green);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //Draws the field
            myBackground.Draw(spriteBatch);

            //spriteBatch.DrawString(font, goal2.score1 + " : " + goal1.score2, new Vector2(400, 10), Color.LightGray);

            ball.Draw(spriteBatch);

            scoreBoard.Draw(spriteBatch);

            control[0].Draw(spriteBatch);

            for (int i = 0; i < laxTeam1.Count; i++)
            {
                laxTeam1[i].Draw(spriteBatch);
            }

            for (int j = 0; j < laxTeam2.Count; j++)
            {
                laxTeam2[j].Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
