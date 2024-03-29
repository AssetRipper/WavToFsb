//C# bindings for FSBank generated by ClangSharp
//https://github.com/dotnet/ClangSharp
//
//FSBank is part of FMOD Studio, copyright © Firelight Technologies Pty, Ltd., 1994-2016.
//See FMOD_LICENSE.txt for full license terms and conditions.

using System.Runtime.InteropServices;

namespace FSBank.V1;

public static unsafe partial class Methods
{
    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_MemoryInit"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_MemoryInit([NativeTypeName("FSBANK_MEMORY_ALLOC_CALLBACK")] delegate* unmanaged[Stdcall]<uint, uint, sbyte*, void*> userAlloc, [NativeTypeName("FSBANK_MEMORY_REALLOC_CALLBACK")] delegate* unmanaged[Stdcall]<void*, uint, uint, sbyte*, void*> userRealloc, [NativeTypeName("FSBANK_MEMORY_FREE_CALLBACK")] delegate* unmanaged[Stdcall]<void*, uint, sbyte*, void> userFree);

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_Init"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_Init(FSBANK_FSBVERSION version, [NativeTypeName("FSBANK_INITFLAGS")] uint flags, [NativeTypeName("unsigned int")] uint numSimultaneousJobs, [NativeTypeName("const char *")] sbyte* cacheDirectory);

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_Release"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_Release();

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_Build"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_Build([NativeTypeName("const FSBANK_SUBSOUND *")] FSBANK_SUBSOUND* subSounds, [NativeTypeName("unsigned int")] uint numSubSounds, FSBANK_FORMAT encodeFormat, [NativeTypeName("FSBANK_BUILDFLAGS")] uint buildFlags, [NativeTypeName("unsigned int")] uint quality, [NativeTypeName("const char *")] sbyte* encryptKey, [NativeTypeName("const char *")] sbyte* outputFileName);

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_FetchFSBMemory"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_FetchFSBMemory([NativeTypeName("const void **")] void** data, [NativeTypeName("unsigned int *")] uint* length);

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_BuildCancel"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_BuildCancel();

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_FetchNextProgressItem"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_FetchNextProgressItem([NativeTypeName("const FSBANK_PROGRESSITEM **")] FSBANK_PROGRESSITEM** progressItem);

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_ReleaseProgressItem"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_ReleaseProgressItem([NativeTypeName("const FSBANK_PROGRESSITEM *")] FSBANK_PROGRESSITEM* progressItem);

    /// <include file='Methods.xml' path='doc/member[@name="Methods.FSBank_MemoryGetStats"]/*' />
    [DllImport("fsbank", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern FSBANK_RESULT FSBank_MemoryGetStats([NativeTypeName("unsigned int *")] uint* currentAllocated, [NativeTypeName("unsigned int *")] uint* maximumAllocated);

    [NativeTypeName("#define FSBANK_INIT_NORMAL 0x00000000")]
    public const int FSBANK_INIT_NORMAL = 0x00000000;

    [NativeTypeName("#define FSBANK_INIT_IGNOREERRORS 0x00000001")]
    public const int FSBANK_INIT_IGNOREERRORS = 0x00000001;

    [NativeTypeName("#define FSBANK_INIT_WARNINGSASERRORS 0x00000002")]
    public const int FSBANK_INIT_WARNINGSASERRORS = 0x00000002;

    [NativeTypeName("#define FSBANK_INIT_CREATEINCLUDEHEADER 0x00000004")]
    public const int FSBANK_INIT_CREATEINCLUDEHEADER = 0x00000004;

    [NativeTypeName("#define FSBANK_INIT_DONTLOADCACHEFILES 0x00000008")]
    public const int FSBANK_INIT_DONTLOADCACHEFILES = 0x00000008;

    [NativeTypeName("#define FSBANK_INIT_GENERATEPROGRESSITEMS 0x00000010")]
    public const int FSBANK_INIT_GENERATEPROGRESSITEMS = 0x00000010;

    [NativeTypeName("#define FSBANK_BUILD_DEFAULT 0x00000000")]
    public const int FSBANK_BUILD_DEFAULT = 0x00000000;

    [NativeTypeName("#define FSBANK_BUILD_DISABLESYNCPOINTS 0x00000001")]
    public const int FSBANK_BUILD_DISABLESYNCPOINTS = 0x00000001;

    [NativeTypeName("#define FSBANK_BUILD_DONTLOOP 0x00000002")]
    public const int FSBANK_BUILD_DONTLOOP = 0x00000002;

    [NativeTypeName("#define FSBANK_BUILD_FILTERHIGHFREQ 0x00000004")]
    public const int FSBANK_BUILD_FILTERHIGHFREQ = 0x00000004;

    [NativeTypeName("#define FSBANK_BUILD_DISABLESEEKING 0x00000008")]
    public const int FSBANK_BUILD_DISABLESEEKING = 0x00000008;

    [NativeTypeName("#define FSBANK_BUILD_OPTIMIZESAMPLERATE 0x00000010")]
    public const int FSBANK_BUILD_OPTIMIZESAMPLERATE = 0x00000010;

    [NativeTypeName("#define FSBANK_BUILD_FSB5_DONTWRITENAMES 0x00000080")]
    public const int FSBANK_BUILD_FSB5_DONTWRITENAMES = 0x00000080;

    [NativeTypeName("#define FSBANK_BUILD_NOGUID 0x00000100")]
    public const int FSBANK_BUILD_NOGUID = 0x00000100;

    [NativeTypeName("#define FSBANK_BUILD_WRITEPEAKVOLUME 0x00000200")]
    public const int FSBANK_BUILD_WRITEPEAKVOLUME = 0x00000200;

    [NativeTypeName("#define FSBANK_BUILD_OVERRIDE_MASK (FSBANK_BUILD_DISABLESYNCPOINTS | FSBANK_BUILD_DONTLOOP | FSBANK_BUILD_FILTERHIGHFREQ | FSBANK_BUILD_DISABLESEEKING | FSBANK_BUILD_OPTIMIZESAMPLERATE | FSBANK_BUILD_WRITEPEAKVOLUME)")]
    public const int FSBANK_BUILD_OVERRIDE_MASK = (0x00000001 | 0x00000002 | 0x00000004 | 0x00000008 | 0x00000010 | 0x00000200);

    [NativeTypeName("#define FSBANK_BUILD_CACHE_VALIDATION_MASK (FSBANK_BUILD_DONTLOOP | FSBANK_BUILD_FILTERHIGHFREQ | FSBANK_BUILD_OPTIMIZESAMPLERATE)")]
    public const int FSBANK_BUILD_CACHE_VALIDATION_MASK = (0x00000002 | 0x00000004 | 0x00000010);
}
