using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Audio;
using Platformer_Maker.Files;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Input;
using System;

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
		AnimatedSprite a;

		public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			IsFixedTimeStep = false;
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
			Tileset t = new Tileset(Content.Load<Texture2D>("Graphics/mario"),14, 1, 32);
			a = new AnimatedSprite(new Texture2D[] {
				t.GetTile(1),
				t.GetTile(2),
				t.GetTile(3),
			}, new Rectangle(0,0, 32, 32), new Vector2(16,16), 5);
			a.Y = Window.ClientBounds.Height - 16;
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


		bool t = true;
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
				double delta = gameTime.ElapsedGameTime.TotalSeconds;
				a.X += (int)((t ? 150.0 : -150.0) * gameTime.ElapsedGameTime.TotalSeconds);
				if (a.X > Window.ClientBounds.Width)
					t = false;
				if (a.X < 0)
					t = true;
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            // TODO: Add your drawing code here

            //nearest neighboor scaling
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

			DrawAnimatedSprite(a);
			spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawSprite(Sprite sprite)
        {
            spriteBatch.Draw(sprite.Texture, sprite.Rect, null, Color.White, sprite.Rotation, sprite.Center, SpriteEffects.None, 0);
        }

		private void DrawAnimatedSprite(AnimatedSprite sprite)
		{
			sprite.Animate();
			spriteBatch.Draw(sprite.CurrentFrame, sprite.Rect, null, Color.White, sprite.Rotation, sprite.Center, SpriteEffects.None, 0);
		}

	}
}
