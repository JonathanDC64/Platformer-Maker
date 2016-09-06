using Microsoft.Xna.Framework;

namespace Platformer_Maker.G2D
{
	public class Entity
	{
		public float X
		{
			get
			{
				return position.X;
			}
			set
			{
				position.X = value;
			}
		}

		public float Y
		{
			get
			{
				return position.Y;
			}
			set
			{
				position.Y = value;
			}
		}

		private Vector2 position;
		public Vector2 Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
			}
		}

		public void SetPosition(float x, float y)
		{
			X = x;
			Y = y;
		}

		public void translate(float xAmount, float yAmount)
		{
			translateX(xAmount);
			translateY(yAmount);
		}

		public void translateX(float xAmount)
		{
			X += xAmount;
		}

		public void translateY(float yAmount)
		{
			Y += yAmount;
		}

		public float Width
		{
			get
			{
				return bounds.X;
			}
			set
			{
				bounds.X = value;
			}
		}

		public float Height
		{
			get
			{
				return bounds.Y;
			}
			set
			{
				bounds.Y = value;
			}
		}

		private Vector2 bounds;
		public Vector2 Bounds
		{
			get
			{
				return bounds;
			}

			set
			{
				bounds = value;
			}
		}

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
