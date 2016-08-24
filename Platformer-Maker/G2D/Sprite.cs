using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Maker.G2D
{
    public class Sprite : Entity
    {
        public Sprite(Texture2D texture, Rectangle rect, Vector2 origin, float rotation)
        {
            Textures = new Texture2D[] { texture };
            Rect = rect;
            Center = origin;
            Rotation = rotation;
        }

		public Sprite() : this(null, Rectangle.Empty, Vector2.Zero, 0) { }

		public Sprite(Texture2D texture, Rectangle rect) : this(texture, rect, Vector2.Zero, 0.0f) {   }

        public Sprite(Texture2D texture, Vector2 position, Vector2 bounds) : this(texture, new Rectangle((int)position.X, (int)position.Y, (int)bounds.X, (int)bounds.Y)){  }

        public Sprite(Sprite sprite) : this(sprite.Textures[0], sprite.Rect, sprite.Center, sprite.Rotation) {  }

		/// <summary>
		/// First texture
		/// </summary>
		public Texture2D Texture
		{
			get
			{
				return Textures[0];
			}
		}

        protected Texture2D[] Textures { get; set; }
    }
}
