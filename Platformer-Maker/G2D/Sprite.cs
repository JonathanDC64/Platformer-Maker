using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Maker.G2D
{
    public class Sprite : Entity
    {
        public Sprite(Texture2D texture, Vector2 position, Vector2 bounds, Vector2 origin, float rotation)
        {
            Textures = new Texture2D[] { texture };
			Position = position;
			Bounds = bounds;
            Center = origin;
            Rotation = rotation;
        }

		public Sprite() : this(null, Vector2.Zero, Vector2.Zero, Vector2.Zero, 0) { }

		public Sprite(Texture2D texture, Vector2 position, Vector2 bounds) : this(texture, position, bounds, Vector2.Zero, 0.0f) {   }

        public Sprite(Sprite sprite) : this(sprite.Textures[0], sprite.Position, sprite.Bounds, sprite.Center, sprite.Rotation) {  }

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
