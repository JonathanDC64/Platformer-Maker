
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.G2D;
using System.Collections.Generic;

namespace Platformer_Maker.GameObjects
{
	public class GameObject
	{

		public GameObjectProperties Properties;

		/// <summary>
		/// Creates a Game Object
		/// </summary>
		/// <param name="properties">Info about the agame Object</param>
		/// <param name="sprites">
		///		Associative Array of animated sprites for when the 
		///		Game Object has multiple states of animation (state, animation)
		/// </param>
		public GameObject(GameObjectProperties properties, Dictionary<string, AnimatedSprite> sprites)
		{
			Properties = properties;
		}

		/// <summary>
		/// Insert behaviour for a game object in here
		/// </summary>
		/// <param name="gameTime"></param>
		public virtual void Update(GameTime gameTime) { }
	}
}
