using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class PongGame : Game
    {
        public static int ScreenWidth;
        public static int ScreenHeight;
        public static int Player1Score;
        public static int Player2Score;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D SpriteSheet;
        private SpriteFont TextFont;
        private SoundEffect PongHitSoundEffect;
        private SoundEffect PongScoreSoundEffect;

        private Player player1;
        private Player player2;

        private PongBall pongBall1;

        private InputManager inputManager;
        private CollisionManager collisionManager;
        private TextManager textManager;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteSheet = Content.Load<Texture2D>("PongSpriteSheet");
            TextFont = Content.Load<SpriteFont>("SpriteFont");
            PongHitSoundEffect = Content.Load<SoundEffect>("PongHitSound");
            PongScoreSoundEffect = Content.Load<SoundEffect>("PongScoreSound");

            pongBall1 = new PongBall(SpriteSheet, PongHitSoundEffect, PongScoreSoundEffect);

            player1 = new Player(SpriteSheet, new Vector2(50, 200));
            player2 = new Player(SpriteSheet, new Vector2(ScreenWidth - 50 - Player.PlayerSpriteWidth, 200));
            inputManager = new InputManager(player1, player2);
            collisionManager = new CollisionManager();
            textManager = new TextManager(TextFont);

            collisionManager.PlayerList.Add(player1);
            collisionManager.PlayerList.Add(player2);
            collisionManager.PongBallList.Add(pongBall1);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            pongBall1.Update(gameTime);
            player1.Update(gameTime);
            player2.Update(gameTime);
            inputManager.ProcessControls(gameTime);
            collisionManager.Update(gameTime);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            textManager.Draw(gameTime, _spriteBatch);
            pongBall1.Draw(gameTime, _spriteBatch);
            player1.Draw(gameTime, _spriteBatch);
            player2.Draw(gameTime, _spriteBatch);
            

            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}