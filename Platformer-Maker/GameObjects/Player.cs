using Microsoft.Xna.Framework;
using Platformer_Maker.GameObjects.Behaviors;

namespace Platformer_Maker.GameObjects
{
	class Player : GameObject
	{
		public Player() : 
		base(new GameObjectProperties()
		{
			ID = GameObjectID.Player,
			Name = GameObject.idToString(GameObjectID.Player),
			Physics = true
		}){}

		public override void Initialize()
		{
			CurrentState = State.Still;
			Sprites[State.Still] = GenerateAnimatedSprite(Properties.ID);
			Sprites[State.Jumping] = GenerateAnimatedSprite(Properties.ID);
			Behaviors.Add(new Controllable());
		}
	}
}
