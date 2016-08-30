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
		/// Global physics gravity
		/// </summary>
		public static readonly float GRAVITY = 9.82f;

		public static readonly float RENDER_WIDTH  = 1280.0f;
		public static readonly float RENDER_HEIGHT = 720.0f;

		public static readonly float TILE_WIDTH	 = RENDER_WIDTH  / (float)TILE_SCREEN_WIDTH;
		public static readonly float TILE_HEIGHT = RENDER_HEIGHT / (float)TILE_SCREEN_HEIGHT;
	}
}
