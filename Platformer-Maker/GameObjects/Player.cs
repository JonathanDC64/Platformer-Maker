using System;
using Microsoft.Xna.Framework;
using Platformer_Maker.Input;
using FarseerPhysics.Factories;
using FarseerPhysics;

namespace Platformer_Maker.GameObjects
{
	class Player : GameObject
	{
		public Player() : base(new GameObjectProperties() {ID = GameObjectID.Player, Name = GameObject.idToString(GameObjectID.Player), Physics = true })
		{}
		public override void Initialize()
		{
			CurrentState = State.Still;
			Sprites[State.Still] = GenerateAnimatedSprite(Properties.ID);
		}

		float speed = 50f;
		float jump  = 1000f;
		public override void Update(GameTime gameTime)
		{
			if (InputManager.Inputs[KeyNames.RIGHT])
				PhysicsBody.ApplyLinearImpulse(ConvertUnits.ToSimUnits(new Vector2(speed, 0)));
			if (InputManager.Inputs[KeyNames.LEFT])
				PhysicsBody.ApplyLinearImpulse(ConvertUnits.ToSimUnits(new Vector2(-speed, 0)));
			if (InputManager.Inputs[KeyNames.JUMP])
				PhysicsBody.ApplyLinearImpulse(ConvertUnits.ToSimUnits(new Vector2(0, -jump)));
		}
	}
}
