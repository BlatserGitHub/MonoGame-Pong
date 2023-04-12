using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class TextManager
    {
        private const int Player1ScorePosX = 50;
        private const int Player1ScorePosY = 50;
        private int Player2ScorePosX = 600;
        private const int Player2ScorePosY = 50;

        private SpriteFont TextSprite;
        public TextManager(SpriteFont spriteFont) 
        {
            TextSprite = spriteFont;
        }

        public void Update(GameTime gameTime)
        {

        }
            
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(TextSprite, "Player 1: " + PongGame.Player1Score.ToString(), new Vector2(Player1ScorePosX, Player1ScorePosY), Color.White);
            spriteBatch.DrawString(TextSprite, "Player 2: " + PongGame.Player2Score.ToString(), new Vector2(Player2ScorePosX, Player2ScorePosY), Color.White);
        }
    }
}
