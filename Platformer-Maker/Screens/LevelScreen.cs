using FarseerPhysics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.Models;
using System;

namespace Platformer_Maker.Screens
{
	public class LevelScreen : GameScreen
	{
		/// <summary>
		/// Keep the state of the original level
		/// </summary>
		private Level OriginalLevel { get; set; }
		private ActiveLevel CurrentLevel { get; set; }

		private World LevelWorld { get; set; }

		private Vector2 drawPosition;
		public LevelScreen(Level lvl)
		{
			drawPosition = new Vector2();
			LevelWorld = new World(new Vector2(0f, Metrics.GRAVITY));
			OriginalLevel = lvl;
			CurrentLevel = new ActiveLevel(OriginalLevel, LevelWorld);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//Draw Background

			//Draw Level
			DrawLevel(gameTime, spriteBatch);

			//Draw Player
			DrawPlayer(gameTime, spriteBatch); ;

			//Draw UI
		}

		
		private void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch)
		{
			GameObject[,] level = CurrentLevel.LevelGameObjects;
			for (int y = 0; y < level.GetLength(0); y++)
			{
				for (int x = 0; x < level.GetLength(1); x++)
				{
					GameObject gameObject = level[y, x];
					if (gameObject.PhysicsBody != null)
					{
						drawPosition.X = ConvertUnits.ToDisplayUnits(gameObject.PhysicsBody.Position.X);
						drawPosition.Y = ConvertUnits.ToDisplayUnits(gameObject.PhysicsBody.Position.Y);

						//Cull tiles that are not on screen
						if (gameObject.Properties.Visible &&
							drawPosition.X > -Metrics.TILE_WIDTH && drawPosition.X < Metrics.RENDER_WIDTH &&
							drawPosition.Y > -Metrics.TILE_HEIGHT && drawPosition.Y < Metrics.RENDER_HEIGHT)
						{
							gameObject.Draw(gameTime, spriteBatch, drawPosition);
						}
					}
				}
			}
		}

		private void DrawPlayer(GameTime gameTime, SpriteBatch spriteBatch)
		{
			drawPosition.X = ConvertUnits.ToDisplayUnits(CurrentLevel.Player.PhysicsBody.Position.X);
			drawPosition.Y = ConvertUnits.ToDisplayUnits(CurrentLevel.Player.PhysicsBody.Position.Y);
			CurrentLevel.Player.Draw(gameTime, spriteBatch, drawPosition);
			Console.WriteLine(drawPosition);
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
			//Upate Level
			UpdateLevel(gameTime);

			//Update Player / enemies
			UpdatePlayerAndEnemies(gameTime);

			//Update UI
		}

		private void UpdateLevel(GameTime gameTime)
		{
			GameObject[,] level = CurrentLevel.LevelGameObjects;
			for (int y = 0; y < level.GetLength(0); y++)
			{
				for (int x = 0; x < level.GetLength(1); x++)
				{
					GameObject gameObject = level[y, x];
					gameObject.Update(gameTime);
				}
			}
			LevelWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
		}

		private void UpdatePlayerAndEnemies(GameTime gameTime)
		{
			CurrentLevel.Player.Update(gameTime);
		}
	}
	/// <summary>
	/// Level with GameObjects as opposed to ids
	/// </summary>
	class ActiveLevel
	{
		public GameObject[,] LevelGameObjects { get; private set; }
		public Level OriginalLevel { get; private set; }

		public World LevelWorld { get; private set; }

		public GameObject Player;

		private Vector2 positon;

		public ActiveLevel(Level level, World world)
		{
			OriginalLevel = level;
			LevelWorld = world;
			Player = GameObjectFactory.GetGameObject(GameObjectID.Player);
			positon = new Vector2();
			ConstructLevel();
		}

		public void ResetLevel()
		{
			ConstructLevel();
		}

		private void ConstructLevel()
		{
			GameObjectID[,] levelData = OriginalLevel.LevelData;
			int height = levelData.GetLength(0);
			int width = levelData.GetLength(1);
			LevelGameObjects = new GameObject[height, width];
			for (int y = 0; y < height; y++)
			{
				for(int x = 0; x < width; x++)
				{
					GameObject gameObject = LevelGameObjects[y, x] = GameObjectFactory.GetGameObject(OriginalLevel.LevelData[y, x]);
					positon.X = (float)x * Metrics.TILE_WIDTH;
					positon.Y = (float)y * Metrics.TILE_HEIGHT;
					gameObject.InitializeBody(LevelWorld, positon);
				}
			}

			Player.SetTileX((int)OriginalLevel.StartPoint.X);
			Player.SetTileY((int)OriginalLevel.StartPoint.Y);
			positon.X = Player.X;
			positon.Y = Player.Y;
			Player.InitializeBody(LevelWorld, positon);
		}
	}
}
