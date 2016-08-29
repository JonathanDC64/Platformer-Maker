using Microsoft.Xna.Framework;

namespace Platformer_Maker.GameObjects
{
	class Block : GameObject
	{
		public Block(GameObjectID id) 
			: base(new GameObjectProperties() { ID = id, Collisions = true, Name = GameObject.idToString(id), Visible = true })
		{}

		public override void Initialize()
		{
			Sprites[State.Normal] = GenerateAnimatedSprite(Properties.ID);
		}

		public override void Update(GameTime gameTime)
		{
			
		}
	}
}
