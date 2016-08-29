using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Models;

namespace Platformer_Maker.Screens
{
	public class LevelScreen : GameScreen
	{
		/// <summary>
		/// Keep the state of the original level
		/// </summary>
		private Level OriginalLevel { get; set; }
		private ActiveLevel CurrentLevel { get; set; }
		public LevelScreen(Level lvl)
		{
			OriginalLevel = lvl;
			CurrentLevel = new ActiveLevel(OriginalLevel);
		}

		double d = 0;
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//Draw Background
			//Draw Level
			DrawLevel(gameTime, spriteBatch);
			//Draw Player
			//Draw UI
		}

		private void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch)
		{
			GameObject[,] level = CurrentLevel.LevelGameObjects;
			for (int i = 0; i < level.GetLength(0); i++)
			{
				for (int j = 0; j < level.GetLength(1); j++)
				{
					GameObject gameObject = level[i, j];
					Vector2 position = new Vector2(((float)j * Metrics.TileWidth) + offset, (float)i * Metrics.TileHeight);
					gameObject.Draw(gameTime, spriteBatch, position);
				}
			}
		}

		public override void LoadAssets()
		{
			//Load all tiles
		}

		public override void UnloadAssets()
		{
			//Unload all tiles
		}

		float offset = 0;
		float speed = 100.0f;
		int delay = 100;
		/// <summary>
		/// All logic for processing the level
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Update(GameTime gameTime)
		{
			delay--;
			if (delay <= 0)
				offset -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
		}
	}
	/// <summary>
	/// Level with GameObjects as opposed to ids
	/// </summary>
	class ActiveLevel
	{
		public GameObject[,] LevelGameObjects { get; private set; }
		public Level OriginalLevel { get; private set; }

		public ActiveLevel(Level level)
		{
			OriginalLevel = level;
			ConstructLevel();
		}

		private void ConstructLevel()
		{
			GameObjectID[,] levelData = OriginalLevel.LevelData;
			int height = levelData.GetLength(0);
			int width = levelData.GetLength(1);
			LevelGameObjects = new GameObject[height, width];
			for (int i = 0; i < height; i++)
			{
				for(int j = 0; j < width; j++)
				{
					LevelGameObjects[i, j] = GameObjectFactory.GetGameObject(OriginalLevel.LevelData[i, j]);
				}
			}
		}
	}
}
