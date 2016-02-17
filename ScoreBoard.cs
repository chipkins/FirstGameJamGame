#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace GameJamFall2014
{
    class ScoreBoard
    {
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
        public Goal goal1;
        public Goal goal2;
        /*public int countSeconds = 0;
        public int countTenSeconds = 0;
        public int countMinutes = 0;*/
        public Texture2D displaySeconds;
        public Texture2D displayTenSeconds;
        public Texture2D displayMinutes;
        public Texture2D displayScore1;
        public Texture2D displayScore2;

        public ScoreBoard(Texture2D c, Texture2D h, Texture2D z, Texture2D o, Texture2D t, Texture2D th, Texture2D f, Texture2D fi, Texture2D s, Texture2D se, Texture2D e, Texture2D n, Goal g1, Goal g2)
        {
            colon = c;
            hyphen = h;
            zero = z;
            one = o;
            two = t;
            three = th;
            four = f;
            five = fi;
            six = s;
            seven = se;
            eight = e;
            nine = n;
            goal1 = g1;
            goal2 = g2;
        }

        public void Update(int countSec, int CountTSec, int countMin)
        {
               switch(countMin)
               {
                   case 0:
                       displayMinutes = zero;
                       break;
                   case 1:
                       displayMinutes = one;
                       break;
                   case 2:
                       displayMinutes = two;
                       break;
                   case 3:
                       displayMinutes = three;
                       break;
                   case 4:
                       displayMinutes = four;
                       break;
                   case 5:
                       displayMinutes = five;
                       break;
                   case 6:
                       displayMinutes = six;
                       break;
                   case 7:
                       displayMinutes = seven;
                       break;
                   case 8:
                       displayMinutes = eight;
                       break;
                   case 9:
                       displayMinutes = nine;
                       break;
               }

               switch (CountTSec)
               {
                   case 0:
                       displayTenSeconds = zero;
                       break;
                   case 1:
                       displayTenSeconds = one;
                       break;
                   case 2:
                       displayTenSeconds = two;
                       break;
                   case 3:
                       displayTenSeconds = three;
                       break;
                   case 4:
                       displayTenSeconds = four;
                       break;
                   case 5:
                       displayTenSeconds = five;
                       break;
                   case 6:
                       displayTenSeconds = six;
                       break;
                   case 7:
                       displayTenSeconds = seven;
                       break;
                   case 8:
                       displayTenSeconds = eight;
                       break;
                   case 9:
                       displayTenSeconds = nine;
                       break;
               }

               switch (countSec)
               {
                   case 0:
                       displaySeconds = zero;
                       break;
                   case 1:
                       displaySeconds = one;
                       break;
                   case 2:
                       displaySeconds = two;
                       break;
                   case 3:
                       displaySeconds = three;
                       break;
                   case 4:
                       displaySeconds = four;
                       break;
                   case 5:
                       displaySeconds = five;
                       break;
                   case 6:
                       displaySeconds = six;
                       break;
                   case 7:
                       displaySeconds = seven;
                       break;
                   case 8:
                       displaySeconds = eight;
                       break;
                   case 9:
                       displaySeconds = nine;
                       break;
               }

               switch (goal2.score1)
               {
                   case 0:
                       displayScore1 = zero;
                       break;
                   case 1:
                       displayScore1 = one;
                       break;
                   case 2:
                       displayScore1 = two;
                       break;
                   case 3:
                       displayScore1 = three;
                       break;
                   case 4:
                       displayScore1 = four;
                       break;
                   case 5:
                       displayScore1 = five;
                       break;
                   case 6:
                       displayScore1 = six;
                       break;
                   case 7:
                       displayScore1 = seven;
                       break;
                   case 8:
                       displayScore1 = eight;
                       break;
                   case 9:
                       displayScore1 = nine;
                       break;
               }

               switch (goal1.score2)
               {
                   case 0:
                       displayScore2 = zero;
                       break;
                   case 1:
                       displayScore2 = one;
                       break;
                   case 2:
                       displayScore2 = two;
                       break;
                   case 3:
                       displayScore2 = three;
                       break;
                   case 4:
                       displayScore2 = four;
                       break;
                   case 5:
                       displayScore2 = five;
                       break;
                   case 6:
                       displayScore2 = six;
                       break;
                   case 7:
                       displayScore2 = seven;
                       break;
                   case 8:
                       displayScore2 = eight;
                       break;
                   case 9:
                       displayScore2 = nine;
                       break;
               }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(colon, new Vector2(50, 15), Color.White);
            spriteBatch.Draw(hyphen, new Vector2(710, 25), Color.White);

            spriteBatch.Draw(displayMinutes, new Vector2(20, 10), Color.White);
            spriteBatch.Draw(displayTenSeconds, new Vector2(70, 10), Color.White);
            spriteBatch.Draw(displaySeconds, new Vector2(100, 10), Color.White);

            spriteBatch.Draw(displayScore1, new Vector2(675, 10), Color.White);
            spriteBatch.Draw(displayScore2, new Vector2(750, 10), Color.White);
        }
    }
}
