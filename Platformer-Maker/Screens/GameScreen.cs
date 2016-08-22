using Microsoft.Xna.Framework;

namespace Platformer_Maker.Screens
{
	public class GameScreen
	{
		public bool IsActive = true;
		public bool IsPopup = false; // If screen covers entire display
		public Color BackgroundColor = Color.CornflowerBlue;

		public virtual void LoadAssets() { }
		public virtual void Update(GameTime gameTime) { }
		public virtual void Draw(GameTime gameTime) { }
		public virtual void UnloadAssets() { }
	}
}
