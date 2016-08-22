using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Audio;
using Platformer_Maker.G2D;
using Platformer_Maker.Input;

namespace Platformer_Maker
{
	//todo implement ScreenManager http://www.dreamincode.net/forums/topic/276045-simple-screen-management-in-xna/

	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private AudioManager audioManager;
		private InputManager inputManager;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
			audioManager = new AudioManager();
			inputManager = new InputManager();
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
			audioManager.InitializeSFX(Content);
			inputManager.InitializeInput();
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
			// TODO: Unload any non ContentManager content here
			Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if(this.IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

				// TODO: Add your update logic here
				inputManager.Update();

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            //this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            // TODO: Add your drawing code here

            //nearest neighboor scaling
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			

			spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawSprite(Sprite sprite)
        {
            spriteBatch.Draw(sprite.Texture, sprite.Rect, null, Color.White, sprite.Rotation, sprite.Center, SpriteEffects.None, 0);
        }
    }
}
