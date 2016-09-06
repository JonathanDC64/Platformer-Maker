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

		public float VelocityX { get; set; }
		public float VelocityY { get; set; }

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
			scale = new Vector2();
			shadowPosition = new Vector2();
			Width = Properties.Width;
			Height = Properties.Height;
			VelocityX = 0f;
			VelocityY = 0f;
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
		public virtual void Update(GameTime gameTime)
		{
			
			
		}

		public void UpdateX(GameTime gameTime)
		{
			X += (VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds);
		}

		public void UpdateY(GameTime gameTime)
		{
			Y += (VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds);
		}

		public void ApplyPhysics(GameTime gameTime)
		{
			Y += Metrics.GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
		}

		private Vector2 scale;
		private Vector2 shadowPosition;
		private readonly Color shadow = new Color(0, 0, 0, 100);
		public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position)
		{
			if(Properties.Visible)
			{
				scale.X = Metrics.TILE_WIDTH / (float)CurrentSprite.CurrentFrame.Width;
				scale.Y = Metrics.TILE_HEIGHT / (float)CurrentSprite.CurrentFrame.Height;
				CurrentSprite.Animate();
			
				//draw gameobject
				spriteBatch.Draw(CurrentSprite.CurrentFrame, position, null, Color.White, Rotation, Center, scale, SpriteEffects.None, 1.0f);
			}
		}

		public void DrawShadow(GameTime gameTime, SpriteBatch spriteBatch, float offsetX, float offsetY)
		{
			if (Properties.Visible)
			{
				shadowPosition.X = (X + Metrics.TILE_WIDTH  * 0.22222222f) + offsetX;
				shadowPosition.Y = (Y + Metrics.TILE_HEIGHT * 0.22222222f) + offsetY;
				//draw shadow
				spriteBatch.Draw(CurrentSprite.CurrentFrame, shadowPosition, null, shadow, Rotation, Center, scale, SpriteEffects.None, 0.0f);
			}
		}

		public void SetTileX(int x)
		{
			X = (Metrics.TILE_WIDTH * (float)x);
		}

		public void SetTileY(int y)
		{
			Y = (Metrics.TILE_HEIGHT * (float)y);
		}

		public float GetTileX()
		{
			return (float)X * Metrics.TILE_WIDTH;
		}

		public float GetTileY()
		{
			return (float)Y * Metrics.TILE_HEIGHT;
		}

		public float GetTileWidth()
		{
			return (float)Width * Metrics.TILE_WIDTH;
		}

		public float GetTileHeight()
		{
			return (float)Height * Metrics.TILE_HEIGHT;
		}

		public Rectangle Rect
		{
			get
			{
				return new Rectangle((int)X, (int)Y, (int)GetTileWidth(), (int)GetTileHeight());
			}
		}

		//public void InitializeBody(World world, Vector2 position)
		//{
		//	float width = ConvertUnits.ToSimUnits(GetTileWidth());
		//	float height = ConvertUnits.ToSimUnits(GetTileHeight());
		//	if(Properties.GameObjectShape == GameObjectProperties.Shape.Rectangle)
		//		PhysicsBody = BodyFactory.CreateRectangle(world, width, height, 1f, ConvertUnits.ToSimUnits(position));
		//	else if (Properties.GameObjectShape == GameObjectProperties.Shape.Circle)
		//		PhysicsBody = BodyFactory.CreateCircle(world, height / 2.0f, 1f, ConvertUnits.ToSimUnits(position));
		//	else
		//		PhysicsBody = null;

		//	if (PhysicsBody != null)
		//	{
		//		if(Properties.Physics)
		//		{
		//			PhysicsBody.BodyType = BodyType.Dynamic;
		//			PhysicsBody.IsStatic = false;
		//		}
		//		else
		//		{
		//			PhysicsBody.BodyType = BodyType.Static;
		//			PhysicsBody.IsStatic = true;
		//		}
		//		PhysicsBody.FixedRotation = true;
		//		PhysicsBody.Friction = 1.2f;
		//	}
		//}


		public static string idToString(GameObjectID id)
		{
			return id.ToString();
		}

		protected AnimatedSprite GenerateAnimatedSprite(GameObjectID id)
		{
			return new AnimatedSprite(Game.textures2D[id.ToString()], new Vector2(0, 0), new Vector2(0, 0), Vector2.Zero, Metrics.ANIMATION_DELAY);
		}
	}
}
