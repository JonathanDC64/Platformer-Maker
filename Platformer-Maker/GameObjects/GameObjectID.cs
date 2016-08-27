namespace Platformer_Maker.GameObjects
{
	public enum GameObjectID
	{
		Empty = 0,
		//regular Blocks That Only Have Collision//
		Ground1 = 1,
		Ground2 = 2,
		Stone1 = 3,
		Stone2 = 4,

		//regular Blocks With Interaction//
		Brick = 5,
		ItemBlock = 6,
		Hidden = 7,

		//transportation Objects//
		Pipe = 8,
		Door = 9,

		//hazards//
		Spike = 10,

		//moving Objects//
		SemiSolidPlatform,
		BouncePad,
		Raft,
		FallingBlock,
		Vine,
	}
}
