using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FSBank.V1;
internal static class ModuleInitialization
{
	[ModuleInitializer]
	[SuppressMessage("Usage", "CA2255:The 'ModuleInitializer' attribute should not be used in libraries", Justification = "Required for native dll resolution.")]
	internal static void InitializeModule()
	{
		if (OperatingSystem.IsWindows() && Environment.Is64BitProcess)
		{
			NativeLibrary.SetDllImportResolver(typeof(ModuleInitialization).Assembly, ResolveFSBank64);
		}
		LoadLibFsbVorbis();
	}

	private static void LoadLibFsbVorbis()
	{
		//Loading this library is required for fsbank to function properly.
		//If it's not loaded into the process before using fsbank, fsbank might search for it and fail to find it.
		//We use TryLoad because native libraries aren't available for direct project references, ie unit testing.
		//If the native libraries are moved to their own package, this can be switched back to Load.
		if (OperatingSystem.IsWindows() && Environment.Is64BitProcess)
		{
			NativeLibrary.TryLoad("libfsbvorbis64", typeof(ModuleInitialization).Assembly, DllImportSearchPath.ApplicationDirectory, out _);
		}
		else
		{
			NativeLibrary.TryLoad("libfsbvorbis", typeof(ModuleInitialization).Assembly, DllImportSearchPath.ApplicationDirectory, out _);
		}
	}

	private static IntPtr ResolveFSBank64(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		return libraryName switch
		{
			"fsbank" => NativeLibrary.Load("fsbank64", assembly, searchPath),
			"fsbank.dll" => NativeLibrary.Load("fsbank64.dll", assembly, searchPath),
			_ => default,
		};
	}
}
