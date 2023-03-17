using FSBank.V1;

namespace WavToFsb
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine("This program takes exactly two arguments: the path to a wav file and an output path for an fsb file.");
				return;
			}

			string pathToWav = args[0];

			string outputPath = args[1];

			Convert(pathToWav, outputPath);

			Console.WriteLine("Done!");
		}

		private static void Convert(string pathToWav, string outputPath)
		{
			string cachePath = GetRandomCachePath();
			Directory.CreateDirectory(cachePath);

			Methods.FSBank_Init(FSBankInitFlags.Normal, cachePath, 2);

			byte[] data = File.ReadAllBytes(pathToWav);

			uint quality = 1;

			Methods.FSBank_Build(data, FSBANK_FORMAT.FSBANK_FORMAT_VORBIS, FSBankBuildFlags.DisableSyncPoints, quality, outputPath);

			Directory.Delete(cachePath, true);
		}
		
		private static string GetRandomCachePath()
		{
			string path;
			do
			{
				path = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName());
			} while (Directory.Exists(path));
			return path;
		}
	}
}