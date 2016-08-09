using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.G2D;
using System;

namespace Platformer_Maker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite link;
        Tileset tileset;
        Sprite tile;

        public Game1()
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
            link = new Sprite(Content.Load<Texture2D>("link"), new Rectangle(0,0,50,50));
            link.SetCenter(0.5f, 0.5f);
            tileset = new Tileset(Content.Load<Texture2D>("mario"), 19, 12, 16);
            tile = new Sprite(tileset.GetTile(227), new Rectangle(0, 0, 50, 50));

            
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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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
                link.Rotation += (2.0f * MathHelper.Pi) / 360.0f;
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
            this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            // TODO: Add your drawing code here

            //nearest neighboor scaling
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawSprite(tile);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawSprite(Sprite sprite)
        {
            spriteBatch.Draw(sprite.Texture, sprite.Rect, null, Color.White, sprite.Rotation, sprite.Center, SpriteEffects.None, 0);
        }
    }
}
