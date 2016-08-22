using Microsoft.Xna.Framework.Input;
using Platformer_Maker.Files;

namespace Platformer_Maker.Input
{
	public class InputConfig
	{
		public static string Filename = "input.config";

		public Keys Jump	= Keys.V;
		public Keys Run		= Keys.C;

		public Keys Up		= Keys.Up;
		public Keys Down	= Keys.Down;

		public Keys Left	= Keys.Left;
		public Keys Right	= Keys.Right;	
	}
}
