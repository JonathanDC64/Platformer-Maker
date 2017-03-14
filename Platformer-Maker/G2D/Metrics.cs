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
		public const int TILE_SCREEN_WIDTH = 24;

		/// <summary>
		/// Number of tiles visible on the screens height
		/// </summary>
		public const int TILE_SCREEN_HEIGHT = 14;

		/// <summary>
		/// Default animation delay
		/// </summary>
		public const int ANIMATION_DELAY = 10;

		/// <summary>
		/// Global physics gravity
		/// </summary>
		public const float GRAVITY = 30f;

		public static readonly float MAX_GRAVITY = 30.0f * GRAVITY;

		public const float RENDER_WIDTH  = 1280.0f;
		public const float RENDER_HEIGHT = 720.0f;

		public static readonly float TILE_WIDTH	 = RENDER_WIDTH  / (float)TILE_SCREEN_WIDTH;
		public static readonly float TILE_HEIGHT = RENDER_HEIGHT / (float)TILE_SCREEN_HEIGHT;

		public static readonly float LEVEL_SCROLL_X_MAX = RENDER_WIDTH * (3f/4f);
		public static readonly float LEVEL_SCROLL_X_MIN = RENDER_WIDTH * (1f/4f);
	}
}
