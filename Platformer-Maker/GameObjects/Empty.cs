using System;
using Microsoft.Xna.Framework;

namespace Platformer_Maker.GameObjects
{
	class Empty : GameObject
	{
		public Empty() 
			: base(new GameObjectProperties() { ID = GameObjectID.Empty, Collisions = false, Name = GameObjectID.Empty.ToString(), Visible = false, GameObjectShape = GameObjectProperties.Shape.None})
		{}
		public override void Initialize(){}

		public override void Update(GameTime gameTime){}
	}
}
