using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class PongBall 
    {
        private const int PongBallSpriteStartPosX = 17; 
        private const int PongBallSpriteStartPosY = 0;
        private const int PongBallSpriteWidth = 16;
        private const int PongBallSpriteHeight = 16;

        public float PongBallSpeed = 500f;

        private float RotationAngle;

        public Rectangle Rectangle { get; set; }

        public Vector2 Position;
        private Vector2 Centre = new Vector2(PongGame.ScreenWidth / 2 - PongBallSpriteWidth, PongGame.ScreenHeight / 2 - PongBallSpriteHeight);
        private Vector2 Direction;

        private Sprite PongBallSprite;
        private SoundEffect PongHitSound;
        private SoundEffect PongScoreSound;
        private Random random;

        public PongBall(Texture2D texture, SoundEffect pongHitSound, SoundEffect pongScoreSound) 
        {
            Position = Centre;
            PongHitSound = pongHitSound;
            PongScoreSound = pongScoreSound;
            
            PongBallSprite = new Sprite(texture, PongBallSpriteStartPosX, PongBallSpriteStartPosY, PongBallSpriteWidth, PongBallSpriteHeight);
            random = new Random();
            RandomDirection();
        }

        public void Update(GameTime gameTime)
        {
            CheckBorders();

            Rectangle = new Rectangle( (int)Position.X, (int)Position.Y, PongBallSpriteWidth, PongBallSpriteHeight );

            Position += Direction * PongBallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            RotationAngle = MathF.Atan2(Direction.Y, Direction.X);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            PongBallSprite.Draw(spriteBatch, Position);
        }

        public void CheckBorders()
        {
            if (Position.Y < 0) 
            {
                Position.Y = 1; Direction.Y *= -1; PongHitSound.Play(0.75f, 0f, 0f);
            }
            if (Position.Y > PongGame.ScreenHeight - PongBallSpriteHeight)
            {
                Position.Y = PongGame.ScreenHeight - PongBallSpriteHeight - 1; Direction.Y *= -1; PongHitSound.Play(0.75f, 0f, 0f);
            }
            if (Position.X < 0)
            {
                Position = Centre; RandomDirection(); PongGame.Player2Score++; PongScoreSound.Play(0.5f, 0f, 0f);
            }
            if (Position.X > PongGame.ScreenWidth - PongBallSpriteWidth)
            {
                Position = Centre; RandomDirection(); PongGame.Player1Score++; PongScoreSound.Play(0.5f, 0f, 0f);
            }

        }

        public void CheckPlayerCollision(Player player)
        {
            if (IsTouchingRight(player))
            {
                Position.X = player.Rectangle.Right + 1; Direction.X *= -1; PongHitSound.Play(0.75f, 0f, 0f);
            }
            else if (IsTouchingLeft(player))
            {
                Position.X = player.Rectangle.Left - PongBallSpriteWidth - 1; Direction.X *= -1; PongHitSound.Play(0.75f, 0f, 0f);
            }
            else if (IsTouchingBottom(player))
            {
                Position.Y = player.Rectangle.Bottom + 1; Direction.Y *= -1; PongHitSound.Play(0.75f, 0f, 0f);
            }
            else if (IsTouchingTop(player))
            {
                Position.Y = player.Rectangle.Top - PongBallSpriteHeight - 1; Direction.Y *= -1; PongHitSound.Play(0.75f, 0f, 0f);
            }
        }

        public bool IsTouchingRight(Player player)
        {
            return Rectangle.Left + Direction.X < player.Rectangle.Right &&
                   Rectangle.Right > player.Rectangle.Right &&
                   Rectangle.Top < player.Rectangle.Bottom &&
                   Rectangle.Bottom > player.Rectangle.Top;
        }
        public bool IsTouchingLeft(Player player)
        {
            return Rectangle.Left < player.Rectangle.Left &&
                   Rectangle.Right + Direction.X > player.Rectangle.Left &&
                   Rectangle.Top < player.Rectangle.Bottom &&
                   Rectangle.Bottom > player.Rectangle.Top;
        }
        public bool IsTouchingBottom(Player player)
        {
            return Rectangle.Left < player.Rectangle.Right &&
                   Rectangle.Right > player.Rectangle.Left &&
                   Rectangle.Top + Direction.Y < player.Rectangle.Bottom &&
                   Rectangle.Bottom > player.Rectangle.Bottom;
        }
        public bool IsTouchingTop(Player player)
        {
            return Rectangle.Left < player.Rectangle.Right &&
                   Rectangle.Right > player.Rectangle.Left &&
                   Rectangle.Top < player.Rectangle.Top &&
                   Rectangle.Bottom + Direction.Y > player.Rectangle.Top;
        }

        public void RandomDirection()
        {
            RotationAngle = MathHelper.ToRadians(random.Next(-60, 60) + (random.Next(0, 2) * 180));
            Direction = new Vector2(MathF.Cos(RotationAngle), MathF.Sin(RotationAngle));
        }


    }
}
