using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer_Maker.Screens
{
	public abstract class GameScreen
	{
		public bool IsActive = true;
		public bool IsPopup = false; // If screen covers entire display
		public Color BackgroundColor = Color.CornflowerBlue;
		
		public abstract void LoadAssets();
		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
		public abstract void UnloadAssets();
	}
}
