using Microsoft.Xna.Framework;

namespace Platformer_Maker.GameObjects
{
	public class GameObjectFactory
	{
		public static GameObject GetGameObject(GameObjectID ID)
		{
			//GameObjects that only block the player
			if (ID == GameObjectID.Ground1	|| ID == GameObjectID.Ground2 ||
				ID == GameObjectID.Stone1	|| ID == GameObjectID.Stone2)
			{
				return new Block(ID);
			}
			return new Empty();
		}
	}
}
