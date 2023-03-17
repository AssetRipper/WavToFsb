using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FMOD;
internal static class ModuleInitialization
{
	[ModuleInitializer]
	[SuppressMessage("Usage", "CA2255:The 'ModuleInitializer' attribute should not be used in libraries", Justification = "Required for native dll resolution.")]
	internal static void InitializeModule()
	{
		if (OperatingSystem.IsWindows() && Environment.Is64BitProcess)
		{
			NativeLibrary.SetDllImportResolver(typeof(ModuleInitialization).Assembly, ResolveFmod64);
		}
	}

	private static IntPtr ResolveFmod64(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	{
		return libraryName switch
		{
			"fmod" => NativeLibrary.Load("fmod64", assembly, searchPath),
			"fmod.dll" => NativeLibrary.Load("fmod64.dll", assembly, searchPath),
			_ => default,
		};
	}
}
