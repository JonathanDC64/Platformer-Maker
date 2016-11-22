using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.Collision;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.LevelData;
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

		private Vector2 drawPosition;
		public LevelScreen(Level lvl)
		{
			drawPosition = new Vector2();
			OriginalLevel = lvl;
			CurrentLevel = new ActiveLevel(OriginalLevel);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//Draw Background

			//Draw Level
			CurrentLevel.Player.DrawShadow(gameTime, spriteBatch, 0f, 0f);
			DrawLevel(gameTime, spriteBatch);
			


			//Draw Player
			DrawPlayer(gameTime, spriteBatch); ;

			//Draw UI
		}

		
		private void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch)
		{
			GameObject[,] level = CurrentLevel.GameObjects;
			for (int y = 0; y < level.GetLength(0); y++)
			{
				for (int x = 0; x < level.GetLength(1); x++)
				{
					GameObject gameObject = level[y, x];

					drawPosition.X = gameObject.X + CurrentLevel.OffsetX;
					drawPosition.Y = gameObject.Y + CurrentLevel.OffsetY;

					//Cull tiles that are not on screen
					if (gameObject.Properties.Visible && IsOnScreen(drawPosition))
					{ 
						gameObject.DrawShadow(gameTime, spriteBatch, CurrentLevel.OffsetX, CurrentLevel.OffsetY);
						gameObject.Draw(gameTime, spriteBatch, drawPosition);
					}
				}
			}
		}

		private bool IsOnScreen(Vector2 pos)
		{
			return  pos.X > -Metrics.TILE_WIDTH && pos.X  < Metrics.RENDER_WIDTH &&
					pos.Y > -Metrics.TILE_HEIGHT && pos.Y < Metrics.RENDER_HEIGHT;
		}

		private void DrawPlayer(GameTime gameTime, SpriteBatch spriteBatch)
		{
			drawPosition.X = CurrentLevel.Player.X;
			drawPosition.Y = CurrentLevel.Player.Y;
			CurrentLevel.Player.Draw(gameTime, spriteBatch, drawPosition);
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
			GameObject[,] level = CurrentLevel.GameObjects;
			for (int y = 0; y < level.GetLength(0); y++)
			{
				for (int x = 0; x < level.GetLength(1); x++)
				{
					GameObject gameObject = level[y, x];
					gameObject.Update(gameTime);
				}
			}
		}

		private void UpdatePlayerAndEnemies(GameTime gameTime)
		{
			GameObject Player = CurrentLevel.Player;
			Player.Update(gameTime);
			Player.UpdateX(gameTime);
			CollisionManager.HandleWallsX(Player, CurrentLevel);
			Player.ApplyPhysics(gameTime);
			Player.UpdateY(gameTime);
			CollisionManager.HandleWallsY(Player, CurrentLevel);

			CurrentLevel.UpdateOffset(gameTime);
		}
	}
}
