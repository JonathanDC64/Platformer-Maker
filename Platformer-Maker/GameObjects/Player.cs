using Microsoft.Xna.Framework;
using Platformer_Maker.Input;

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
		}

		int speed = 500;
		int jump  = 1000;
		public override void Update(GameTime gameTime)
		{
			VelocityX = 0;
			VelocityY = 0;
			if (InputManager.Inputs[KeyNames.LEFT])
				VelocityX = -speed;
			if (InputManager.Inputs[KeyNames.RIGHT])
				VelocityX = speed;
			if (InputManager.Inputs[KeyNames.UP])
				VelocityY = -jump;
			if (InputManager.Inputs[KeyNames.DOWN])
				VelocityY = speed;
			base.Update(gameTime);
		}
	}
}
