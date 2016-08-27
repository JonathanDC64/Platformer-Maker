namespace Platformer_Maker.Models
{
	public class Tileset
	{
		public string FileName;

		public int TileWidth;
		public int TileHeight;

		/// <summary>
		/// Number of tiles along the X axis.
		/// Not the number of pixels as this can
		/// be calculated using TilesetWidth * TileWidth
		/// </summary>
		public int TilesetWidth;

		/// <summary>
		/// Number of tiles along the Y axis.
		/// Not the number of pixels as this can
		/// be calculated using TilesetHeight * TileHeight
		/// </summary>
		public int TilesetHeight;

		/// <summary>
		/// Coordinates on the tileset Texture for all tiles
		/// </summary>
		public TileInfo[] Tiles;
	}
}
