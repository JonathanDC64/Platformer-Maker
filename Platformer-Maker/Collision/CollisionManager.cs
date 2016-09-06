using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.G2D;
using Platformer_Maker.GameObjects;
using Platformer_Maker.LevelData;
using System;

namespace Platformer_Maker.Collision
{
	public static class CollisionManager
	{
		private enum Axis
		{
			X,
			Y
		}

		private const int STEP_X = 3;
		private const int STEP_Y = 3;

		private static Rectangle currentObjectRect = new Rectangle();

		/// <summary>
		/// Checks in a grid of nine tiles of the specified 
		/// gameobject is trying to pass through a wall and
		/// moves that gameobject accordingly
		/// </summary>
		/// <param name="gameObject"></param>
		/// <param name="level"></param>
		private static void HandleWalls(GameObject gameObject, ActiveLevel level, Axis axis, float offsetX, float offsetY)
		{
			int startX = (int)((((gameObject.X - offsetX) / Metrics.TILE_WIDTH) - 1));
			int startY = (int)((((gameObject.Y + offsetY) / Metrics.TILE_HEIGHT) - 1));
			int stopX  =  startX + STEP_X  <= level.GameObjects.GetLength(1) ? startX + STEP_X : level.GameObjects.GetLength(1);
			int stopY  =  startY + STEP_Y  <= level.GameObjects.GetLength(0) ? startY + STEP_Y : level.GameObjects.GetLength(0);
			for(int y = startY; y < stopY; y++)
			{
				for(int x = startX; x < stopX; x++)
				{
					if (x < 0)
						x = 0;
					if (y < 0)
						y = 0;

					GameObject currentObject = level.GameObjects[y, x];
					
					//offlevel to the left
					if (gameObject.X < 0)
						gameObject.X = 0;

					//offlevel to the right
					if (gameObject.X + gameObject.GetTileWidth() > Metrics.RENDER_WIDTH)
						gameObject.X = Metrics.RENDER_WIDTH - gameObject.GetTileWidth();


					//Only process GameObjects that have collisions enabled
					if (currentObject.Properties.Collisions)
					{
						currentObjectRect.X			= (int)(currentObject.X + offsetX);
						currentObjectRect.Y			= (int)(currentObject.Y + offsetY);
						currentObjectRect.Width		= (int)(currentObject.GetTileWidth());
						currentObjectRect.Height	= (int)(currentObject.GetTileHeight());

						if (gameObject.Rect.Intersects(currentObjectRect))
						{
							Vector2 depth = GetIntersectionDepth(gameObject.Rect, currentObjectRect);
							if (axis == Axis.Y)
								gameObject.Y += depth.Y;
							else if (axis == Axis.X)
								gameObject.X += depth.X;
						}
					}
				}
			}	
		}

		public static void HandleWallsX(GameObject gameObject, ActiveLevel level, float offsetX, float offsetY)
		{
			HandleWalls(gameObject, level, Axis.X, offsetX, offsetY);
		}

		public static void HandleWallsY(GameObject gameObject, ActiveLevel level, float offsetX, float offsetY)
		{
			HandleWalls(gameObject, level, Axis.Y, offsetX, offsetY);
		}

		public static Vector2 GetIntersectionDepth(this Rectangle rectA, Rectangle rectB)
		{
			// Calculate half sizes.
			float halfWidthA = rectA.Width / 2.0f;
			float halfHeightA = rectA.Height / 2.0f;
			float halfWidthB = rectB.Width / 2.0f;
			float halfHeightB = rectB.Height / 2.0f;

			// Calculate centers.
			Vector2 centerA = new Vector2(rectA.Left + halfWidthA, rectA.Top + halfHeightA);
			Vector2 centerB = new Vector2(rectB.Left + halfWidthB, rectB.Top + halfHeightB);

			// Calculate current and minimum-non-intersecting distances between centers.
			float distanceX = centerA.X - centerB.X;
			float distanceY = centerA.Y - centerB.Y;
			float minDistanceX = halfWidthA + halfWidthB;
			float minDistanceY = halfHeightA + halfHeightB;

			// If we are not intersecting at all, return (0, 0).
			if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
				return Vector2.Zero;

			// Calculate and return intersection depths.
			float depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
			float depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
			return new Vector2(depthX, depthY);
		}

		public static bool IsOnTop(GameObject gameObject, GameObject currentObject)
		{
			return	gameObject.Y + gameObject.GetTileHeight() > currentObject.Y &&
					gameObject.Y + gameObject.GetTileHeight() < currentObject.Y + currentObject.GetTileHeight() &&
					InBetweenX(gameObject, currentObject);
		}

		public static bool IsOnBottom(GameObject gameObject, GameObject currentObject)
		{
			return	gameObject.Y < currentObject.Y + currentObject.GetTileHeight() &&
					gameObject.Y > currentObject.Y &&
					InBetweenX(gameObject, currentObject);
		}

		public static bool IsOnLeft(GameObject gameObject, GameObject currentObject)
		{
			return	gameObject.X + gameObject.GetTileWidth() > currentObject.X &&
					gameObject.X + gameObject.GetTileWidth() < currentObject.X + currentObject.GetTileWidth() &&
					InBetweenY(gameObject, currentObject);
		}

		public static bool IsOnRight(GameObject gameObject, GameObject currentObject)
		{
			return	gameObject.X < currentObject.X + currentObject.GetTileWidth() &&
					gameObject.X > currentObject.X &&
					InBetweenY(gameObject, currentObject);
		}

		public static bool InBetweenX(GameObject gameObject, GameObject currentObject)
		{
			return	gameObject.X + gameObject.GetTileWidth() >= currentObject.X &&
					gameObject.X <= currentObject.X + currentObject.GetTileWidth();
		}

		public static bool InBetweenY(GameObject gameObject, GameObject currentObject)
		{
			return	gameObject.Y + gameObject.GetTileHeight() >= currentObject.Y &&
					gameObject.Y <= currentObject.Y + currentObject.GetTileHeight();
		}

		public static void DebugDraw(SpriteBatch spriteBatch)
		{
			DrawRectangle(spriteBatch, currentObjectRect, Color.LightGreen,2);
		}

		private static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth)
		{
			Texture2D _pointTexture = _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
			_pointTexture.SetData<Color>(new Color[] { Color.White });
			

			spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
			spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
			spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
			spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
		}
	}
}
