using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Player
    {
        private const int PlayerSpriteStartPosX = 0;
        private const int PlayerSpriteStartPosY = 0;
        public const int PlayerSpriteWidth = 16;
        public const int PlayerSpriteHeight = 64;

        private const float PlayerSpeed = 400f;
        public Input PlayerInputs { get; set; }
        public Rectangle Rectangle { get; set; }

        public Vector2 Position;

        private Sprite PlayerSprite;
        

        public Player(Texture2D texture, Vector2 position) 
        {
            Position = position;

            PlayerSprite = new Sprite(texture, PlayerSpriteStartPosX, PlayerSpriteStartPosY, PlayerSpriteWidth , PlayerSpriteHeight);
        }

        public void Update(GameTime gameTime)
        {
            Rectangle = new Rectangle( (int)Position.X, (int)Position.Y, PlayerSpriteWidth, PlayerSpriteHeight );

            if (Position.Y < 0)
            {
                Position.Y = 1;
            }
            if (Position.Y > PongGame.ScreenHeight - PlayerSpriteHeight)
            {
                Position.Y = PongGame.ScreenHeight - 1 - PlayerSpriteHeight;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            PlayerSprite.Draw(spriteBatch, Position);
        }

        public void MovePlayer(Input playerInputs, KeyboardState KeyState, GameTime gameTime)
        {
            if (KeyState.IsKeyDown(playerInputs.Up)) 
            {
                Position.Y -= PlayerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (KeyState.IsKeyDown(playerInputs.Down))
            {
                Position.Y += PlayerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

        }

    }
}
