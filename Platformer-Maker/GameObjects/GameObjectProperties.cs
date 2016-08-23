namespace Platformer_Maker.GameObjects
{
	public class GameObjectProperties
	{
		/// Number of tiles the Game Object consiststs of 
		/// Ex: 2x2 where an [X] is a tile
		///	[X]	[X]	
		///	[X]	[X]	


		public string Name;
		public int ID;

		/// <summary>
		/// Wether the gameobject is collideable with other Game Objects
		/// </summary>
		public bool Collisions;
	}
}
