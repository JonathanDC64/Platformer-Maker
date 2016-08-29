namespace Platformer_Maker.GameObjects
{
	public enum GameObjectID
	{
		Empty = 0,
		//regular Blocks That Only Have Collision//
		Ground1,
		Ground2,
		Stone1,
		Stone2,

		//regular Blocks With Interaction//
		Brick1,
		Brick2,
		ItemBlock,
		Hidden,

		//transportation Objects//
		Pipe,
		Door,

		//hazards//
		Spike,

		//moving Objects//
		SemiSolidPlatform,
		BouncePad,
		Raft,
		FallingBlock,
		Vine,
	}
}
