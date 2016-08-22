using Microsoft.Xna.Framework.Audio;

namespace Platformer_Maker.Audio
{
	public class Sound
	{
		private SoundEffect SFX;
		private SoundEffectInstance SFXInstance;

		public float Volume
		{
			get
			{
				return SFXInstance.Volume;
			}
			set
			{
				SFXInstance.Volume = value;
			}
		}

		public float Pan
		{
			get
			{
				return SFXInstance.Pan;
			}
			set
			{
				SFXInstance.Pan = value;
			}
		}

		public float Pitch
		{
			get
			{
				return SFXInstance.Pitch;
			}
			set
			{
				SFXInstance.Pitch = value;
			}
		}

		public bool Loop
		{
			get
			{
				return SFXInstance.IsLooped;
			}
			set
			{
				SFXInstance.IsLooped = value;
			}
		}

		public SoundState State
		{
			get
			{
				return SFXInstance.State;
			}
		}

		public Sound(SoundEffect sfx)
		{
			SFX = sfx;
			SFXInstance = SFX.CreateInstance();
		}

		public void Play()
		{
			SFXInstance.Play();
		}

		public void Pause()
		{
			SFXInstance.Pause();
		}

		public void Stop()
		{
			SFXInstance.Stop();
		}

		public Sound Clone()
		{
			return new Sound(SFX);
		}
	}
}
