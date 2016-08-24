using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

		public LevelScreen(Level lvl)
		{
			OriginalLevel = lvl;
			CurrentLevel = OriginalLevel.Clone();
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
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
			
		}
	}
}
