
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
		public GameObjectProperties Properties { get; private set; }

		/// <summary>
		/// Dictionary of animations associated with
		/// a game object state. Should be initialized
		/// in the Initialize Function
		/// </summary>
		public Dictionary<State, AnimatedSprite> Sprites { get; set; }

		public State CurrentState { get; protected set; }

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
			Sprites = new Dictionary<State, AnimatedSprite>();
			CurrentState = State.Normal;
			Initialize();
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


		public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position)
		{
			if(Properties.Visible)
			{
				Vector2 scale = new Vector2(Metrics.TileWidth / (float)CurrentSprite.CurrentFrame.Width, Metrics.TileHeight / (float)CurrentSprite.CurrentFrame.Height);
				CurrentSprite.Animate();
				spriteBatch.Draw(CurrentSprite.CurrentFrame, position, null, Color.White, CurrentSprite.Rotation, CurrentSprite.Center, scale, SpriteEffects.None, 0.0f);
			}
		}

		public static string idToString(GameObjectID id)
		{
			return id.ToString();
		}

		protected AnimatedSprite GenerateAnimatedSprite(GameObjectID id)
		{
			return new AnimatedSprite(Game.textures2D[id.ToString()], new Rectangle(0, 0, 1, 1), Vector2.Zero, Metrics.ANIMATION_DELAY);
		}
	}
}
