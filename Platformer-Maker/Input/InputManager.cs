
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Files;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Platformer_Maker.Input
{
	public class InputManager : KeyNames
	{
		/// <summary>
		/// Input stream used to check if a button is being held;
		/// </summary>
		public  static Dictionary<string, bool> Inputs		= new Dictionary<string, bool>();

		/// <summary>
		/// Used to check if a key has been pressed rather than held
		/// </summary>
		private static Dictionary<string, bool> OldInputs	= new Dictionary<string, bool>();

		private KeyboardState keyboardState;
		private GamePadState gamePadState;
		private InputConfig inputConfig;

		public InputManager()
		{
			inputConfig = new InputConfig();
		}

		public void InitializeInput()
		{
			if (FileManager.FileExists(InputConfig.Filename))
				inputConfig = FileManager.ReadObjectFile<InputConfig>(InputConfig.Filename);
			else
				FileManager.WriteObjectFile<InputConfig>(inputConfig, InputConfig.Filename);
			
			Update();
		}

		public void Update()
		{
			keyboardState	= Keyboard.GetState();
			gamePadState	= GamePad.GetState(0);//First controller
			Inputs[UP]		= keyboardState.IsKeyDown(inputConfig.Up)		|| gamePadState.IsButtonDown(Buttons.DPadUp);
			Inputs[DOWN]	= keyboardState.IsKeyDown(inputConfig.Down)		|| gamePadState.IsButtonDown(Buttons.DPadDown);
			Inputs[LEFT]	= keyboardState.IsKeyDown(inputConfig.Left)		|| gamePadState.IsButtonDown(Buttons.DPadLeft);
			Inputs[RIGHT]	= keyboardState.IsKeyDown(inputConfig.Right)	|| gamePadState.IsButtonDown(Buttons.DPadRight);
			Inputs[JUMP]	= keyboardState.IsKeyDown(inputConfig.Jump)		|| gamePadState.IsButtonDown(Buttons.A);
			Inputs[RUN]		= keyboardState.IsKeyDown(inputConfig.Run)		|| gamePadState.IsButtonDown(Buttons.X);
			Inputs[PAUSE]	= keyboardState.IsKeyDown(inputConfig.Pause)	|| gamePadState.IsButtonDown(Buttons.Start);
			OldInputs		= Inputs.ToDictionary(entry => entry.Key, entry => entry.Value);
		}

		public static bool KeyPressed(string key)
		{
			return Inputs[key] && !OldInputs[key];
		}

		public static Keys StringToKey(string text)
		{
			return (Keys)Enum.Parse(typeof(Keys), text);
		}
	}
}
