using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Audio;
using Platformer_Maker.Files;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Input;
using Platformer_Maker.Screens;
using System;
using System.Collections.Generic;

namespace Platformer_Maker
{
	//todo implement ScreenManager http://www.dreamincode.net/forums/topic/276045-simple-screen-management-in-xna/

	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game : Microsoft.Xna.Framework.Game
    {
		//Because the Game object acts like a Singleton, we can have static access to members

        public static GraphicsDeviceManager graphics;
		public static SpriteBatch spriteBatch;
		public static AudioManager audioManager;
		public static InputManager inputManager;
		public static Dictionary<string, Texture2D> textures2D;
        public static Dictionary<string, SpriteFont> fonts;
		public static List<GameScreen> screens;
		public static ContentManager contentManager;


		AnimatedSprite a;

		public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			IsFixedTimeStep = false;
			Window.AllowUserResizing = true;
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
			audioManager	= new AudioManager();
			inputManager	= new InputManager();
			textures2D		= new Dictionary<string, Texture2D>();
			fonts			= new Dictionary<string, SpriteFont>();
			screens			= new List<GameScreen>();
			contentManager = Content;

			AddScreen(new TestScreen());

			Tileset t = new Tileset(Content.Load<Texture2D>("Graphics/mario"),14, 1, 32);
			a = new AnimatedSprite(new Texture2D[] {
				t.GetTile(1),
				t.GetTile(2),
				t.GetTile(3),
			}, new Rectangle(0,0, 32, 32), new Vector2(16,16), 5);
			
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
			
			foreach(GameScreen screen in screens)
				screen.LoadAssets();
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
			// TODO: Unload any non ContentManager content here
			foreach (GameScreen screen in screens)
				screen.UnloadAssets();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			inputManager.Update();

			if(screens.Count > 0)
			{
				int startIndex = screens.Count - 1;
				while (screens[startIndex].IsPopup && screens[startIndex].IsActive)
				{
					startIndex--;
				}
				for (int i = startIndex; i < screens.Count; i++)
				{
					screens[i].Update(gameTime);
				}
			}

			double delta = gameTime.ElapsedGameTime.TotalSeconds;
			a.X += (int)((t ? 150.0 : -150.0) * gameTime.ElapsedGameTime.TotalSeconds);
			a.Y = Window.ClientBounds.Height - 16;
			if (a.X > Window.ClientBounds.Width)
				t = false;
			if (a.X < 0)
				t = true;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
			//GraphicsDevice.Clear(Color.CornflowerBlue);
			//this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
			// TODO: Add your drawing code here

			var startIndex = screens.Count - 1;
			while (screens[startIndex].IsPopup)
			{
				startIndex--;
			}

			GraphicsDevice.Clear(screens[startIndex].BackgroundColor);
			graphics.GraphicsDevice.Clear(screens[startIndex].BackgroundColor);

			for (var i = startIndex; i < screens.Count; i++)
			{
				screens[i].Draw(gameTime, spriteBatch);
			}


			//nearest neighboor scaling
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			DrawAnimatedSprite(a);
			spriteBatch.End();

            base.Draw(gameTime);
        }

		public static void AddFont(string fontName)
		{
			if (!fonts.ContainsKey(fontName))
			{
				fonts.Add(fontName, contentManager.Load<SpriteFont>(fontName));
			}
		}

		public static void RemoveFont(string fontName)
		{
			if (fonts.ContainsKey(fontName))
			{
				fonts.Remove(fontName);
			}
		}

		public static void AddTexture2D(string textureName)
		{
			if (!textures2D.ContainsKey(textureName))
			{
				textures2D.Add(textureName, contentManager.Load<Texture2D>(textureName));
			}
		}

		public static void RemoveTexture2D(string textureName)
		{
			if (textures2D.ContainsKey(textureName))
			{
				textures2D.Remove(textureName);
			}
		}

		public static void AddScreen(GameScreen gameScreen)
		{
			gameScreen.LoadAssets();
			if (screens == null)
			{
				screens = new List<GameScreen>();
			}
			screens.Add(gameScreen);
			gameScreen.LoadAssets();
		}

		public static void RemoveScreen(GameScreen gameScreen)
		{
			gameScreen.UnloadAssets();
			screens.Remove(gameScreen);
		}

		public static void ChangeScreens(GameScreen currentScreen, GameScreen targetScreen)
		{
			RemoveScreen(currentScreen);
			AddScreen(targetScreen);
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
