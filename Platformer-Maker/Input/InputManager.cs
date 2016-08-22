
using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Files;
using System;

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
			{
				inputConfig = FileManager.ReadObjectFile<InputConfig>(InputConfig.Filename);
			}
			else
			{
				FileManager.WriteObjectFile<InputConfig>(inputConfig, InputConfig.Filename);
			}

			//todo add extra stuff here
		}

		public void Update()
		{
			keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(inputConfig.Up))
			{
				
			}
			if (keyboardState.IsKeyDown(inputConfig.Down))
			{

			}
			if (keyboardState.IsKeyDown(inputConfig.Left))
			{

			}
			if (keyboardState.IsKeyDown(inputConfig.Right))
			{

			}
			if (keyboardState.IsKeyDown(inputConfig.Jump))
			{

			}
			if (keyboardState.IsKeyDown(inputConfig.Run))
			{

			}
		}


		public static Keys StringToKey(string text)
		{
			return (Keys)Enum.Parse(typeof(Keys), text);
		}
	}
}
