
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Files;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Platformer_Maker.Input
{
	public class InputManager
	{
		private KeyboardState keyboardState;
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

		public static Dictionary<string, bool> Inputs = new Dictionary<string, bool>();

		public void Update()
		{
			keyboardState	= Keyboard.GetState();
			Inputs["Up"]	= keyboardState.IsKeyDown(inputConfig.Up);
			Inputs["Down"]	= keyboardState.IsKeyDown(inputConfig.Down);
			Inputs["Left"]	= keyboardState.IsKeyDown(inputConfig.Left);
			Inputs["Right"] = keyboardState.IsKeyDown(inputConfig.Right);
			Inputs["Jump"]	= keyboardState.IsKeyDown(inputConfig.Jump);
			Inputs["Run"]	= keyboardState.IsKeyDown(inputConfig.Run);
		}

		public static Keys StringToKey(string text)
		{
			return (Keys)Enum.Parse(typeof(Keys), text);
		}
	}
}
