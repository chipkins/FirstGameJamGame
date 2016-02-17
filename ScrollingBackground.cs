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
#endregion

namespace GameJamFall2014
{
    class ScrollingBackground
    {
        public Vector2 screenPos;
        private Vector2 origin;
        public Vector2 textureSize;
        private Texture2D myTexture;
        private int screenHeight;
        private int screenWidth;

        public ScrollingBackground()
        {
        }

        public Vector2 ScreenPos
        {
            get { return screenPos; }
        }

        public Vector2 TextureSize
        {
            get { return textureSize; }
        }
        
        public void Load(GraphicsDevice device, Texture2D texture)
        {
            myTexture = texture;
            screenHeight = device.Viewport.Height;
            screenWidth = device.Viewport.Width;
            //set the origin so it draws from the top left corner
            origin = new Vector2(0, 0);
            //set the screen position to the center of the field
            screenPos = new Vector2(0, -200);
            //offset to draw the second texture when necessary
            textureSize = new Vector2(0, myTexture.Height);
        }

        public void Update(Player player, float deltaY)
        {
            if (player.position.Y <= (-screenPos.Y + 100))
            {
                if (screenPos.Y < 0)
                {
                    screenPos.Y += deltaY;
                    screenPos.Y = screenPos.Y % myTexture.Height;
                }
            }

            else if (player.position.Y >= (-screenPos.Y + 100))
            {
                if (screenPos.Y > -400)
                {
                    screenPos.Y -= deltaY;
                    screenPos.Y = screenPos.Y % myTexture.Height;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(screenPos.Y < screenHeight)
            {
                spriteBatch.Draw(myTexture, screenPos, null, Color.White, 0, origin, 1, SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(myTexture, screenPos - textureSize, null, Color.White, 0, origin, 1, SpriteEffects.None, 0f);
        }
    }
}
