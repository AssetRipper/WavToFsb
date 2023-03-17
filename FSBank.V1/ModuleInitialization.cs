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
			NativeLibrary.Load("libfsbvorbis64", typeof(ModuleInitialization).Assembly, DllImportSearchPath.ApplicationDirectory);
		}
		else
		{
			NativeLibrary.Load("libfsbvorbis", typeof(ModuleInitialization).Assembly, DllImportSearchPath.ApplicationDirectory);
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
