using FMOD;
using System.Runtime.InteropServices;

namespace FsbToWav
{
	public static class FmodAudioConverter
	{
		/*public static bool IsSupported(IAudioClip audioClip)
		{
			if (audioClip.Has_Type_C83())
			{
				switch ((Core.Classes.AudioClip.FMODSoundType)audioClip.Type_C83)
				{
					case Core.Classes.AudioClip.FMODSoundType.AIFF:
					case Core.Classes.AudioClip.FMODSoundType.IT:
					case Core.Classes.AudioClip.FMODSoundType.MOD:
					case Core.Classes.AudioClip.FMODSoundType.S3M:
					case Core.Classes.AudioClip.FMODSoundType.XM:
					case Core.Classes.AudioClip.FMODSoundType.XMA:
					case Core.Classes.AudioClip.FMODSoundType.VAG:
					case Core.Classes.AudioClip.FMODSoundType.AUDIOQUEUE:
						return true;
					default:
						return false;
				}
			}
			else
			{
				switch ((Core.Classes.AudioClip.AudioCompressionFormat)audioClip.CompressionFormat_C83)
				{
					case Core.Classes.AudioClip.AudioCompressionFormat.PCM:
					case Core.Classes.AudioClip.AudioCompressionFormat.Vorbis:
					case Core.Classes.AudioClip.AudioCompressionFormat.ADPCM:
					case Core.Classes.AudioClip.AudioCompressionFormat.MP3:
					case Core.Classes.AudioClip.AudioCompressionFormat.VAG:
					case Core.Classes.AudioClip.AudioCompressionFormat.HEVAG:
					case Core.Classes.AudioClip.AudioCompressionFormat.XMA:
					case Core.Classes.AudioClip.AudioCompressionFormat.GCADPCM:
					case Core.Classes.AudioClip.AudioCompressionFormat.ATRAC9:
						return true;
					default:
						return false;
				}
			}
		}*/

		public static byte[]? ConvertToWav(byte[] fmodData)
		{
			RESULT result = Factory.System_Create(out FMOD.System system);
			if (result != RESULT.OK)
			{
				return null;
			}

			try
			{
				result = system.init(1, INITFLAGS.NORMAL, IntPtr.Zero);
				if (result != RESULT.OK)
				{
					return null;
				}

				CREATESOUNDEXINFO exinfo = new CREATESOUNDEXINFO();
				exinfo.cbsize = Marshal.SizeOf(exinfo);
				exinfo.length = (uint)fmodData.Length;
				result = system.createSound(fmodData, MODE.OPENMEMORY, ref exinfo, out Sound sound);
				if (result != RESULT.OK)
				{
					return null;
				}

				try
				{
					result = sound.getSubSound(0, out Sound subsound);
					if (result != RESULT.OK)
					{
						return null;
					}

					try
					{
						result = subsound.getFormat(out SOUND_TYPE type, out SOUND_FORMAT format, out int numChannels, out int bitsPerSample);
						if (result != RESULT.OK)
						{
							return null;
						}

						result = subsound.getDefaults(out float frequency, out int priority);
						if (result != RESULT.OK)
						{
							return null;
						}

						int sampleRate = (int)frequency;
						result = subsound.getLength(out uint length, TIMEUNIT.PCMBYTES);
						if (result != RESULT.OK)
						{
							return null;
						}

						result = subsound.@lock(0, length, out IntPtr ptr1, out IntPtr ptr2, out uint len1, out uint len2);
						if (result != RESULT.OK)
						{
							return null;
						}

						const int WavHeaderLength = 44;
						int bufferLen = (int)(WavHeaderLength + len1);
						byte[] buffer = new byte[bufferLen];
						using (MemoryStream stream = new MemoryStream(buffer))
						{
							using BinaryWriter writer = new BinaryWriter(stream);
							writer.Write(RiffFourCC);
							writer.Write(36 + len1);
							writer.Write(WaveEightCC);
							writer.Write(16);
							writer.Write((short)1);
							writer.Write((short)numChannels);
							writer.Write(sampleRate);
							writer.Write(sampleRate * numChannels * bitsPerSample / 8);
							writer.Write((short)(numChannels * bitsPerSample / 8));
							writer.Write((short)bitsPerSample);
							writer.Write(DataFourCC);
							writer.Write(len1);
						}
						Marshal.Copy(ptr1, buffer, WavHeaderLength, (int)len1);
						subsound.unlock(ptr1, ptr2, len1, len2);
						return buffer;
					}
					finally
					{
						subsound.release();
					}
				}
				finally
				{
					sound.release();
				}
			}
			finally
			{
				system.release();
			}
		}

		/// <summary>
		/// 'RIFF' ascii
		/// </summary>
		private const uint RiffFourCC = 0x46464952;
		/// <summary>
		/// 'WAVEfmt ' ascii
		/// </summary>
		private const ulong WaveEightCC = 0x20746D6645564157;
		/// <summary>
		/// 'data' ascii
		/// </summary>
		private const uint DataFourCC = 0x61746164;
	}
}