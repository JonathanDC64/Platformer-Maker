
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer_Maker.G2D;
using System;
using System.Collections.Generic;

namespace Platformer_Maker.GameObjects
{
	/// <summary>
	/// A GameObject for levels
	/// Can be a block, an enemie, etc..
	/// </summary>
	/// <typeparam name="StateEnum">The generic type represents the Enum used for the objects state</typeparam>
	public abstract class GameObject : Entity
	{
		public enum State
		{
			Normal,
			Hit,
			MovingLeft,
			MovingRight,
			Still,
			Jumping,
			Dying
		}

		/// <summary>
		/// Information on the game object
		/// (Id, Name, etc).
		/// Used in serialization.
		/// </summary>
		public GameObjectProperties Properties { get; set; }

		/// <summary>
		/// Dictionary of animations associated with
		/// a game object state. Should be initialized
		/// in the Initialize Function
		/// </summary>
		public Dictionary<State, AnimatedSprite> Sprites { get; set; }

		public State CurrentState { get; }

		public AnimatedSprite CurrentSprite
		{
			get
			{
				return Sprites[CurrentState];
			}
		}
		
		/// <summary>
		/// Creates a Game Object
		/// </summary>
		/// <param name="properties">Info about the agame Object</param>
		/// <param name="sprites">
		///		Associative Array of animated sprites for when the 
		///		Game Object has multiple states of animation (state, animation)
		/// </param>
		public GameObject(GameObjectProperties properties)
		{
			Properties = properties;
		}

		/// <summary>
		/// Insert all the necessary things to create the Game Object
		/// Ex: Sprites
		/// </summary>
		public abstract void Initialize();

		/// <summary>
		/// Insert behaviour for a game object and
		/// update object state here
		/// </summary>
		/// <param name="gameTime"></param>
		public abstract void Update(GameTime gameTime);


		protected void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			CurrentSprite.Animate();
			if(Properties.Visible)
				spriteBatch.Draw(CurrentSprite.CurrentFrame, CurrentSprite.Rect, null, Color.White, CurrentSprite.Rotation, CurrentSprite.Center, SpriteEffects.None, 0);
		}
	}
}
