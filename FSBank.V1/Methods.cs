/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FSBank.V1
{
	public static unsafe partial class Methods
	{
		public static void FSBank_Init(FSBankInitFlags flags, string cacheDirectory, uint numSimultaneousJobs = 1)
		{
			if (!Directory.Exists(cacheDirectory))
			{
				throw new DirectoryNotFoundException();
			}

			nint cacheDirectoryPtr = Marshal.StringToHGlobalAnsi(cacheDirectory);
			FSBANK_RESULT result = FSBank_Init(FSBANK_FSBVERSION.FSBANK_FSBVERSION_FSB5, unchecked((uint)flags), numSimultaneousJobs, (sbyte*)cacheDirectoryPtr);
			Marshal.FreeHGlobal(cacheDirectoryPtr);

			ThrowHelper.MaybeWarnOrThrowFSBankException(result);
		}
		
		public static void FSBank_Build(FSBANK_SUBSOUND subSound, FSBANK_FORMAT encodeFormat, FSBankBuildFlags buildFlags, uint quality, string outputFileName)
		{
			nint outputFileNamePtr = Marshal.StringToHGlobalAnsi(outputFileName);
			FSBANK_RESULT result = FSBank_Build(&subSound, 1, encodeFormat, unchecked((uint)buildFlags), quality, default, (sbyte*)outputFileNamePtr);
			Marshal.FreeHGlobal(outputFileNamePtr);

			ThrowHelper.MaybeWarnOrThrowFSBankException(result);
		}

		public static void FSBank_Build(ReadOnlySpan<byte> audioData, FSBANK_FORMAT encodeFormat, FSBankBuildFlags buildFlags, uint quality, string outputFileName)
		{
			fixed (byte* audioDataPtr = audioData)
			{
				uint audioDataLength = (uint)audioData.Length;
				FSBANK_SUBSOUND subsound = new()
				{
					fileNames = default,
					fileData = (void**)&audioDataPtr,
					fileDataLengths = &audioDataLength,
					numFiles = 1,
					percentOptimizedRate = 100f,
				};
				FSBank_Build(subsound, encodeFormat, buildFlags, quality, outputFileName);
			}
		}
	}
}
