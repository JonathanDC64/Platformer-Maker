namespace Platformer_Maker.GameObjects
{
	public class GameObjectProperties
	{
		/// Number of tiles the Game Object consiststs of 
		/// Ex: 2x2 where an [X] is a tile
		///	[X]	[X]	
		///	[X]	[X]	


		public string Name;
		public GameObjectID ID;

		/// <summary>
		/// Wether the gameobject is collideable with other Game Objects
		/// </summary>
		public bool Collisions;

		/// <summary>
		/// Wether to Draw the game object or not
		/// </summary>
		public bool Visible;

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
