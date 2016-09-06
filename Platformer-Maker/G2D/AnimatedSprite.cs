using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Maker.G2D
{
	public class AnimatedSprite : Sprite
	{
		public Texture2D CurrentFrame;
		private int CurrentFrameIndex;
		private int AnimationDelay;
		public AnimatedSprite(Texture2D[] texture, Vector2 position, Vector2 bounds, Vector2 origin, int animationDelay)
		{
			Textures = texture;
			Position = position;
			Bounds = bounds;
			Center = origin;
			Rotation = 0.0f;
			AnimationDelay = animationDelay;
			CurrentFrameIndex = 0;
			CurrentFrame = Textures[CurrentFrameIndex];
		}

		private int tick = 0;
		public void Animate()
		{
			if(tick == AnimationDelay)
			{
				CurrentFrame = Textures[++CurrentFrameIndex % Textures.Length];
				tick = 0;
			}
			tick++;
		}
	}
}
