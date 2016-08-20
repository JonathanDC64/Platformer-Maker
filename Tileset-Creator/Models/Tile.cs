using System.Collections.Generic;
namespace Platformer_Maker.Models
{
	public class Tile
	{
		public string Name;
		public int ID;
		public TilePoint[,] Points; //Grid of points from the tileset which corespond to certain tiles
	}
}