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
					if (gameObject.Properties.Visible &&
						drawPosition.X > -Metrics.TILE_WIDTH  && drawPosition.X < Metrics.RENDER_WIDTH &&
						drawPosition.Y > -Metrics.TILE_HEIGHT && drawPosition.Y < Metrics.RENDER_HEIGHT)
					{ 
						gameObject.DrawShadow(gameTime, spriteBatch, CurrentLevel.OffsetX, CurrentLevel.OffsetY);
						gameObject.Draw(gameTime, spriteBatch, drawPosition);
					}
				}
			}
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
			CurrentLevel.Player.Update(gameTime);
			CurrentLevel.Player.UpdateX(gameTime);
			CollisionManager.HandleWallsX(CurrentLevel.Player, CurrentLevel, CurrentLevel.OffsetX, CurrentLevel.OffsetY);
			CurrentLevel.Player.ApplyPhysics(gameTime);
			CurrentLevel.Player.UpdateY(gameTime);
			CollisionManager.HandleWallsY(CurrentLevel.Player, CurrentLevel, CurrentLevel.OffsetX, CurrentLevel.OffsetY);

			if (CurrentLevel.OffsetX > 0)
			{
				CurrentLevel.OffsetX = 0;
			}

			if (CurrentLevel.OffsetX < -CurrentLevel.Width + Metrics.RENDER_WIDTH)
			{
				CurrentLevel.OffsetX = -CurrentLevel.Width + Metrics.RENDER_WIDTH;
			}


			if (CurrentLevel.Player.X > Metrics.LEVEL_SCROLL_X_MAX && CurrentLevel.OffsetX != -CurrentLevel.Width + Metrics.RENDER_WIDTH)
			{
				CurrentLevel.Player.X = Metrics.LEVEL_SCROLL_X_MAX;
				CurrentLevel.OffsetX -= CurrentLevel.Player.VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds;
			}
			if (CurrentLevel.Player.X < Metrics.LEVEL_SCROLL_X_MIN && CurrentLevel.OffsetX != 0)
			{
				CurrentLevel.Player.X = Metrics.LEVEL_SCROLL_X_MIN;
				CurrentLevel.OffsetX -= CurrentLevel.Player.VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds;
			}

			

		}
	}
}
