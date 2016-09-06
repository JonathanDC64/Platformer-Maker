using Microsoft.Xna.Framework;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Models;

namespace Platformer_Maker.LevelData
{
	/// <summary>
	/// Level with GameObjects as opposed to ids
	/// </summary>
	public class ActiveLevel
	{
		public GameObject[,] GameObjects { get; private set; }
		public Level OriginalLevel { get; private set; }
		public GameObject Player { get; private set; }
		public float OffsetX { get; set; }
		public float OffsetY{ get; set; }


		public ActiveLevel(Level level)
		{
			OriginalLevel = level;
			Player = GameObjectFactory.GetGameObject(GameObjectID.Player);
			ConstructLevel();
		}

		public void ResetLevel()
		{

			ConstructLevel();
		}

		public float Width
		{
			get
			{
				return (float)GameObjects.GetLength(1) * Metrics.TILE_WIDTH;
			}
		}

		public float Height
		{
			get
			{
				return (float)GameObjects.GetLength(0) * Metrics.TILE_HEIGHT;
			}
		}


		private void ConstructLevel()
		{
			OffsetX = 0f;
			OffsetY = 0f;
			GameObjectID[,] levelData = OriginalLevel.LevelData;
			int height = levelData.GetLength(0);
			int width = levelData.GetLength(1);
			GameObjects = new GameObject[height, width];
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					GameObject gameObject = GameObjects[y, x] = GameObjectFactory.GetGameObject(OriginalLevel.LevelData[y, x]);
					gameObject.SetTileX(x);
					gameObject.SetTileY(y);
					gameObject.Initialize();
				}
			}

			Player.SetTileX((int)OriginalLevel.StartPoint.X);
			Player.SetTileY((int)OriginalLevel.StartPoint.Y);
			Player.X = Player.X;
			Player.Y = Player.Y;
			Player.Initialize();
		}
	}
}
