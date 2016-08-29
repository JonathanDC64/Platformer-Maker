using Platformer_Maker.GameObjects;

namespace Platformer_Maker.Models
{
	public class Level
	{
		public string ID;
		public string Author;
		public string Name;
		public int TimeLimit;

		/// <summary>
		/// Contains ids for all gameobjects in a level
		/// and in a 2d grid (2d array) used to know
		/// how to shape the level
		/// </summary>
		public GameObjectID[,] LevelData;

		public Level Clone()
		{
			return new Level()
			{
				ID = this.ID,
				Author = this.Author,
				Name = this.Name,
				TimeLimit = this.TimeLimit,
				LevelData = (GameObjectID[,])this.LevelData.Clone()
			};
		}
	}
}
