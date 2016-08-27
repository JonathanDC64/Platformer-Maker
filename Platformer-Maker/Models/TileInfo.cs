using Microsoft.Xna.Framework;
using Platformer_Maker.GameObjects;

namespace Platformer_Maker.Models
{
	public class TileInfo
	{
		public GameObjectID ID;

		/// <summary>
		/// Specifies coordinates of the tile.
		/// X and Y are the starting points.
		/// Z and W are the end points.
		/// They form a rectangle that is used 
		/// to extract the tile.
		/// An array is used for if the tile is animated.
		/// Each indice of the array is one frame of animation
		/// </summary>
		public Vector4[] TileCoordinates;
	}
}
