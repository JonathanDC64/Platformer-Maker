using Platformer_Maker.Input;
using System;
using System.Collections.Generic;

//http://higherorderfun.com/blog/2012/05/20/the-guide-to-implementing-2d-platformers/
namespace Platformer_Maker.GameObjects.Behaviors
{
	public class Controllable : GameObjectBehavior
	{
		private int speed = 500;
		private int accel = 20;
		private int jump = 1000;
		public void Execute(GameObject gameObject)
		{
			//gameObject.VelocityY += gameObject.VelocityY != 0 ? -1 * Sign(gameObject.VelocityY) * accel : 0;

			Dictionary<string, bool> inputs = InputManager.Inputs;

			if (inputs[KeyNames.LEFT])
				gameObject.VelocityX -= gameObject.VelocityX != -speed ? accel : 0;
			else
				gameObject.VelocityX += gameObject.VelocityX < 0 ? accel : 0;

			if (inputs[KeyNames.RIGHT])
				gameObject.VelocityX += gameObject.VelocityX != speed ? accel : 0;
			else
				gameObject.VelocityX -= gameObject.VelocityX > 0 ? accel : 0;


			if (inputs[KeyNames.UP] && gameObject.CurrentState != GameObject.State.Jumping)
			{
				gameObject.CurrentState = GameObject.State.Jumping;
				gameObject.VelocityY = -jump;
			}
				
			
			if (inputs[KeyNames.DOWN])
				gameObject.VelocityY = speed;

		}

		private float Sign(float num)
		{
			return num / Math.Abs(num);
		}
	}
}
