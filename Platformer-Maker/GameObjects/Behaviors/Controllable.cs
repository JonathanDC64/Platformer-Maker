using Platformer_Maker.Audio;
using Platformer_Maker.G2D;
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

		private static readonly int JUMP_INC = 100;
		private static readonly int MAX_JUMP = 1000;
		private static readonly int JUMP_INIT = MAX_JUMP / JUMP_INC;
		private float jump = 1000;
		private bool jumped = false;
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


			//if (inputs[KeyNames.UP])
			//{
			//	if (gameObject.CurrentState != GameObject.State.Jumping)
			//	{
			//		gameObject.CurrentState = GameObject.State.Jumping;
			//		jumped = false;
			//	}

			//	if(jump < MAX_JUMP && gameObject.CurrentState == GameObject.State.Jumping && !jumped)
			//	{
			//		jump += JUMP_INC;
			//		gameObject.VelocityY = -jump;
			//	}


			//}
			//else
			//{
			//	if (gameObject.CurrentState != GameObject.State.Jumping)
			//		jump = JUMP_INIT;
			//	jumped = true;
			//}

			if (inputs[KeyNames.UP])
			{
				if (gameObject.CurrentState != GameObject.State.Jumping)
				{
					gameObject.CurrentState = GameObject.State.Jumping;
					jumped = false;
					gameObject.VelocityY = -jump;
				}
			}
			else
			{
				if (gameObject.VelocityY < -jump/8)
					gameObject.VelocityY = -jump / 8;
				//jumped = true;
			}


			//if (inputs[KeyNames.DOWN])
			//	gameObject.VelocityY = speed;

			//Console.WriteLine(gameObject.CurrentState.ToString());

		}

		private float Sign(float num)
		{
			return num / Math.Abs(num);
		}
	}
}
