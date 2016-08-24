using Microsoft.Xna.Framework;

namespace Platformer_Maker.G2D
{
	public class Entity
	{
		public int X
		{
			get
			{
				return rect.X;
			}
			set
			{
				rect.X = value;
			}
		}

		public int Y
		{
			get
			{
				return rect.Y;
			}
			set
			{
				rect.Y = value;
			}
		}

		public Vector2 Position
		{
			get
			{
				return new Vector2(X, Y);
			}
			set
			{
				X = (int)value.X;
				Y = (int)value.Y;
			}
		}

		public void SetPosition(int x, int y)
		{
			X = x;
			Y = y;
		}

		public void translate(int xAmount, int yAmount)
		{
			translateX(xAmount);
			translateY(yAmount);
		}

		public void translateX(int xAmount)
		{
			X += xAmount;
		}

		public void translateY(int yAmount)
		{
			Y += yAmount;
		}

		public int Width
		{
			get
			{
				return rect.Width;
			}
			set
			{
				rect.Width = value;
			}
		}

		public int Height
		{
			get
			{
				return rect.Height;
			}
			set
			{
				rect.Height = value;
			}
		}

		public Rectangle Rect
		{
			get
			{
				return rect;
			}
			set
			{
				rect = value;
			}
		}

		private Rectangle rect;

		public Vector2 Center
		{
			get
			{
				return center;
			}
			set
			{
				center = value;
			}
		}

		private Vector2 center;

		public void SetCenterX(float x)
		{
			//center.X = x * Textures[0].Width;
			center.X = x * Width;
		}

		public void SetCenterY(float y)
		{
			//center.Y = y * Textures[0].Height;
			center.Y = y * Height;
		}

		public void SetCenter(float x, float y)
		{
			SetCenterX(x);
			SetCenterY(y);
		}

		public float Rotation
		{
			get
			{
				return rotation;
			}
			set
			{
				rotation = value % (2.0f * MathHelper.Pi);
			}
		}

		private float rotation;
	}
}
