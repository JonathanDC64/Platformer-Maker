namespace Platformer_Maker.GameObjects
{
	public class GameObjectProperties
	{
		public enum Shape
		{
			Circle,
			Rectangle,
			None
		}

		/// Number of tiles the Game Object consiststs of 
		/// Ex: 2x2 where an [X] is a tile
		///	[X]	[X]	
		///	[X]	[X]	


		public string Name;
		public GameObjectID ID;

		/// <summary>
		/// Wether the gameobject is collideable with other Game Objects
		/// </summary>
		public bool Collisions = true;

		/// <summary>
		/// Wether to Draw the game object or not
		/// </summary>
		public bool Visible = true;

		/// <summary>
		/// Number of tiles the game object
		/// occupies along the X axis
		/// </summary>
		public int Width = 1;

		/// <summary>
		/// Number of tiles the game object
		/// occupies along the Y axis
		/// </summary>
		public int Height = 1;

		public Shape GameObjectShape = Shape.Rectangle;

		public bool Grabbable = false;

		public bool Physics = false;

		public GameObjectProperties Clone()
		{
			return new GameObjectProperties()
			{
				Name = this.Name,
				ID = this.ID,
				Collisions = this.Collisions,
				Visible = this.Visible
			};
		}
	}
}
