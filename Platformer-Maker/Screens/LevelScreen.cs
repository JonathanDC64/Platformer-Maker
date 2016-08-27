using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.G2D;
using Platformer_Maker.Models;

namespace Platformer_Maker.Screens
{
	public class LevelScreen : GameScreen
	{
		/// <summary>
		/// Keep the state of the original level
		/// </summary>
		private Level OriginalLevel;
		private Level CurrentLevel;
		Texture2D t;
		public LevelScreen(Level lvl)
		{
			OriginalLevel = lvl;
			CurrentLevel = OriginalLevel.Clone();
			t = Game.contentManager.Load<Texture2D>("Graphics/ground");
		}

		double d = 0;
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			for (int i = 0; i < CurrentLevel.LevelData.GetLength(0); i++)
			{
				for(int j = 0; j < CurrentLevel.LevelData.GetLength(1); j++)
				{
					if(CurrentLevel.LevelData[i,j] == 1)
					{
						//spriteBatch.Draw(t, new Rectangle(j * w, i * h, w, h), j % 2 == 0 ? Color.White : Color.Black);
						spriteBatch.Draw(t, new Vector2((j * Metrics.TileWidth) + (float)d, i * Metrics.TileHeight), null, Color.White, 0.0f, Vector2.Zero, new Vector2(Metrics.TileWidth/t.Width, Metrics.TileHeight/t.Height), SpriteEffects.None, 0.0f);
					}
				}
			}
			//Draw Background
			//Draw Level
			//Draw Player
			//Draw UI
		}

		public override void LoadAssets()
		{
			//Load all tiles
		}

		public override void UnloadAssets()
		{
			//Unload all tiles
		}

		/// <summary>
		/// All logic for processing the level
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Update(GameTime gameTime)
		{
			//d -= (75.0 * gameTime.ElapsedGameTime.TotalSeconds);
		}
	}
}
