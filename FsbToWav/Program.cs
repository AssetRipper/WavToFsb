namespace FsbToWav;

internal class Program
{
	static void Main(string[] args)
	{
		if(args.Length != 1)
		{
			Console.WriteLine("This program takes exactly one argument: the path to an fsb file.");
			return;
		}

		string path = args[0];
		if (!File.Exists(path))
		{
			Console.WriteLine($"No file at {path}");
			return;
		}

		byte[] fsbData = File.ReadAllBytes(path);
		byte[]? wavData = FmodAudioConverter.ConvertToWav(fsbData);
		if (wavData is not null)
		{
			string fileName = Path.GetFileNameWithoutExtension(path);
			File.WriteAllBytes($"{fileName}.wav", wavData);
			Console.WriteLine("Done!");
		}
		else
		{
			Console.WriteLine("Could not convert the fsb data to wav");
		}
	}
}