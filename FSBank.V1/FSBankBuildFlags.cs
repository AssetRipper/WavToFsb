/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

using System;

namespace FSBank.V1
{
	/// <summary>
	/// Bit fields to use with FSBank_Build and in FSBANK_SUBSOUND to control how subsounds are encoded.
	/// </summary>
	[Flags]
	public enum FSBankBuildFlags
	{
		/// <summary>
		/// Build with default settings.
		/// </summary>
		Default = Methods.FSBANK_BUILD_DEFAULT,
		/// <summary>
		/// Disable the storing of syncpoints in the output
		/// </summary>
		DisableSyncPoints = Methods.FSBANK_BUILD_DISABLESYNCPOINTS,
		/// <summary>
		/// Disable perfect loop encoding and sound stretching. Removes chirps from the start of oneshot MP2, MP3 and IMAADPCM sounds.
		/// </summary>
		DontLoop = Methods.FSBANK_BUILD_DONTLOOP,
		/// <summary>
		/// XMA only. Enable high frequency filtering.
		/// </summary>
		FilterHighFrequency = Methods.FSBANK_BUILD_FILTERHIGHFREQ,
		/// <summary>
		/// XMA only. Disable seek tables to save memory.
		/// </summary>
		DisableSeeking = Methods.FSBANK_BUILD_DISABLESEEKING,
		/// <summary>
		/// Attempt to optimize the sample rate down. Ignored if format is MP2, MP3 or if FSB4 basic headers flag is used.
		/// </summary>
		OptimizeSampleRate = Methods.FSBANK_BUILD_OPTIMIZESAMPLERATE,
		/// <summary>
		/// FSB5 format only. Do not write out a names chunk to the FSB to reduce file size.
		/// </summary>
		DontWriteNames = Methods.FSBANK_BUILD_FSB5_DONTWRITENAMES,
		/// <summary>
		/// FSB5 format only. Write out a null GUID for the FSB header.  The runtime will not use header caching for these FSB files.
		/// </summary>
		NoGuid = Methods.FSBANK_BUILD_NOGUID,
		/// <summary>
		/// FSB5 format only. Write peak volume for all subsounds.
		/// </summary>
		WritePeakVolume = Methods.FSBANK_BUILD_WRITEPEAKVOLUME,
		/// <summary>
		/// Build flag mask that specifies which settings can be overridden per subsound.
		/// </summary>
		OverrideMask = Methods.FSBANK_BUILD_OVERRIDE_MASK,
		/// <summary>
		/// Build flag mask that specifies which settings (when changed) invalidate a cache file.
		/// </summary>
		ValidationMask = Methods.FSBANK_BUILD_CACHE_VALIDATION_MASK,
	}
}
