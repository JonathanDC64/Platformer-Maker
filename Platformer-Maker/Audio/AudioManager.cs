using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
namespace Platformer_Maker.Audio
{
	public class AudioManager
	{
		public static float GlobalVolume = 1.0f;

		public void InitializeSFX(Microsoft.Xna.Framework.Content.ContentManager content)
		{
			Sounds.Jump = new Sound(content.Load<SoundEffect>("Audio/SFX/Jump"));
			Sounds.Coin = new Sound(content.Load<SoundEffect>("Audio/SFX/Coin"));
		}
	}
}
