using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Audio;
using Platformer_Maker.Files;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Input;
using Platformer_Maker.Models;
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
		public static Dictionary<string, Texture2D[]> textures2D;
        public static Dictionary<string, SpriteFont> fonts;
		public static List<GameScreen> screens;
		public static ContentManager contentManager;
		public static G2D.Tileset currentTileset;

		private static SpriteFont debugFont;


		public static SpriteBatch targetBatch;
		public static RenderTarget2D target;

		private const string DEFAULT_TILESET_FILE = "tileset1.tileset";

		public Game()
        {
            graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
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
			textures2D		= new Dictionary<string, Texture2D[]>();
			fonts			= new Dictionary<string, SpriteFont>();
			screens			= new List<GameScreen>();
			contentManager = Content;

			targetBatch = new SpriteBatch(GraphicsDevice);
			target = new RenderTarget2D(GraphicsDevice, (int)Metrics.RENDER_WIDTH, (int)Metrics.RENDER_HEIGHT);
			currentTileset = new G2D.Tileset(FileManager.ReadObjectFile<Models.Tileset>(DEFAULT_TILESET_FILE));
			LoadTileset();
			AddScreen(new LevelScreen(FileManager.ReadObjectFile<Level>("level1.lvl")));

			debugFont = Content.Load<SpriteFont>("Fonts/wasco");

			base.Initialize();
        }

		private static void LoadTileset()
		{
			foreach(GameObjectID id in Enum.GetValues(typeof(GameObjectID)))
			{
				try
				{
					textures2D[id.ToString()] = currentTileset.GetTile(id);
				}
				catch(Exception e)
				{
					Console.WriteLine("ERROR: " + e.Message);
				}
			}
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



		int _total_frames = 0;
		float _elapsed_time = 0.0f;
		int _fps = 0;

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
        {
			// Update

			_elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			// 1 Second has passed
			if (_elapsed_time >= 1000.0f)
			{
				_fps = _total_frames;
				_total_frames = 0;
				_elapsed_time = 0;
			}

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
            base.Update(gameTime);
        }


		private Rectangle targetRect = new Rectangle();
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
			// Only update total frames when drawing
			_total_frames++;

			GraphicsDevice.SetRenderTarget(target);
			//nearest neighboor scaling
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
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
			spriteBatch.End();

			//set rendering back to the back buffer
			GraphicsDevice.SetRenderTarget(null);

			//render target to back buffer
			targetBatch.Begin();
			targetRect.Width = Window.ClientBounds.Width;
			targetRect.Height = Window.ClientBounds.Height;
			targetBatch.Draw(target, targetRect, Color.White);
			targetBatch.DrawString(debugFont, string.Format("FPS={0} FrameTime={1}", _fps, gameTime.ElapsedGameTime.TotalSeconds),
				new Vector2(10.0f, 20.0f), Color.White);
			targetBatch.End();

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
				textures2D.Add(textureName, new Texture2D[] { contentManager.Load<Texture2D>(textureName) });
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
	}
}
