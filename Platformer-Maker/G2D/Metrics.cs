namespace Platformer_Maker.G2D
{
	/// <summary>
	/// Used for dunamic measurements
	/// such as accounting for different
	/// screen resolutions / window sizes
	/// </summary>
	public class Metrics
	{
		/// <summary>
		/// Number of tiles visible on the screens width
		/// </summary>
		public static readonly int TILE_SCREEN_WIDTH = 24;

		/// <summary>
		/// Number of tiles visible on the screens height
		/// </summary>
		public static readonly int TILE_SCREEN_HEIGHT = 14;

		/// <summary>
		/// Default animation delay
		/// </summary>
		public static readonly int ANIMATION_DELAY = 10;

		/// <summary>
		/// Width of the game window
		/// can vary
		/// </summary>
		public static int WindowWidth;

		/// <summary>
		/// Height of the game window
		/// can vary
		/// </summary>
		public static int WindowHeight;

		/// <summary>
		/// Width of a single tile.
		/// Depends on the window size
		/// </summary>
		public static float TileWidth;

		/// <summary>
		/// Height of a single tile.
		/// Depends on the window size
		/// </summary>
		public static float TileHeight;

		/// <summary>
		/// Used to scale tiles when the windows width changes
		/// </summary>
		public static float ScaleX;

		/// <summary>
		/// Used to scale tiles when the windows height changes
		/// </summary>
		public static float ScaleY;
	}
}
