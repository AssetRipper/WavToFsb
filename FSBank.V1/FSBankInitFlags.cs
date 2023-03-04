/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

using System;

namespace FSBank.V1
{
	/// <summary>
	/// Bit fields to use with FSBank_Init to control the general operation of the library.
	/// </summary>
	[Flags]
	public enum FSBankInitFlags
	{
		/// <summary>
		/// Initialize normally.
		/// </summary>
		Normal = Methods.FSBANK_INIT_NORMAL,
		/// <summary>
		/// Ignore individual subsound build errors, continue building for as long as possible.
		/// </summary>
		IgnoreErrors = Methods.FSBANK_INIT_IGNOREERRORS,
		/// <summary>
		/// Treat any warnings issued as errors.
		/// </summary>
		WarningsAsErrors = Methods.FSBANK_INIT_WARNINGSASERRORS,
		/// <summary>
		/// Create C header files with #defines defining indices for each member of the FSB.
		/// </summary>
		CreateIncludeHeader = Methods.FSBANK_INIT_CREATEINCLUDEHEADER,
		/// <summary>
		/// Ignore existing cache files.
		/// </summary>
		DontLoadCacheFiles = Methods.FSBANK_INIT_DONTLOADCACHEFILES,
		/// <summary>
		/// Generate status items that can be queried by another thread to monitor the build progress and give detailed error messages.
		/// </summary>
		GenerateProgressItems = Methods.FSBANK_INIT_GENERATEPROGRESSITEMS,
	}
}
