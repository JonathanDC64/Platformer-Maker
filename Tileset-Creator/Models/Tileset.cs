using System.Collections.Generic;

namespace Platformer_Maker.Models
{
	class Tileset
	{
		#pragma warning disable 0649
		public string FileName;
		public int TileWidth;
		public int TileHeight;
		public int TilesetWidth; //Number of horizontal tiles
		public int TilesetHeight; //Number of vertical tiles

		public List<Tile> Tiles;
	}
}
