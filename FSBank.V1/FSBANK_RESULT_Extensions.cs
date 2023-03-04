/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

namespace FSBank.V1
{
	public static class FSBANK_RESULT_Extensions
    {
		/// <summary>
		/// Convert a result into an error message.
		/// </summary>
		/// <remarks>
		/// Ported from FSBank_ErrorString in fsbank_errors.h
		/// </remarks>
		/// <param name="result">A result returned from an interop method.</param>
		/// <returns>An string representing this error</returns>
		public static string ToErrorString(this FSBANK_RESULT result)
		{
			return result switch
			{
				FSBANK_RESULT.FSBANK_OK => "No errors.",
				FSBANK_RESULT.FSBANK_ERR_CACHE_CHUNKNOTFOUND => "An expected chunk is missing from the cache, perhaps try deleting cache files.",
				FSBANK_RESULT.FSBANK_ERR_CANCELLED => "The build process was cancelled during compilation by the user.",
				FSBANK_RESULT.FSBANK_ERR_CANNOT_CONTINUE => "The build process cannot continue due to previously ignored errors.",
				FSBANK_RESULT.FSBANK_ERR_ENCODER => "Encoder for chosen format has encountered an unexpected error.",
				FSBANK_RESULT.FSBANK_ERR_ENCODER_INIT => "Encoder initialization failed.",
				FSBANK_RESULT.FSBANK_ERR_ENCODER_NOTSUPPORTED => "Encoder for chosen format is not supported on this platform.",
				FSBANK_RESULT.FSBANK_ERR_FILE_OS => "An operating system based file error was encountered.",
				FSBANK_RESULT.FSBANK_ERR_FILE_NOTFOUND => "A specified file could not be found.",
				FSBANK_RESULT.FSBANK_ERR_FMOD => "Internal error from FMOD sub-system.",
				FSBANK_RESULT.FSBANK_ERR_INITIALIZED => "Already initialized.",
				FSBANK_RESULT.FSBANK_ERR_INVALID_FORMAT => "The format of the source file is invalid.",
				FSBANK_RESULT.FSBANK_ERR_INVALID_PARAM => "An invalid parameter has been passed to this function.",
				FSBANK_RESULT.FSBANK_ERR_MEMORY => "Run out of memory.",
				FSBANK_RESULT.FSBANK_ERR_UNINITIALIZED => "Not initialized yet.",
				FSBANK_RESULT.FSBANK_ERR_WRITER_FORMAT => "Chosen encode format is not supported by this FSB version.",
				FSBANK_RESULT.FSBANK_WARN_CANNOTLOOP => "Source file is too short for seamless looping. Looping disabled.",
				FSBANK_RESULT.FSBANK_WARN_IGNORED_FILTERHIGHFREQ => "FSBANK_BUILD_FILTERHIGHFREQ flag ignored: feature only supported by XMA format.",
				FSBANK_RESULT.FSBANK_WARN_IGNORED_DISABLESEEKING => "FSBANK_BUILD_DISABLESEEKING flag ignored: feature only supported by XMA format.",
				FSBANK_RESULT.FSBANK_WARN_FORCED_DONTWRITENAMES => "FSBANK_BUILD_FSB5_DONTWRITENAMES flag forced: cannot write names when source is from memory.",
				FSBANK_RESULT.FSBANK_ERR_ENCODER_FILE_NOTFOUND => "External encoder dynamic library not found.",
				FSBANK_RESULT.FSBANK_ERR_ENCODER_FILE_BAD => "External encoder dynamic library could not be loaded, possibly incorrect binary format, incorrect architecture, or file corruption.",
				_ => "Unknown error.",
			};
		}

		public static bool IsOK(this FSBANK_RESULT result) => result == FSBANK_RESULT.FSBANK_OK;

		public static bool IsWarning(this FSBANK_RESULT result)
		{
			return result switch
			{
				FSBANK_RESULT.FSBANK_WARN_CANNOTLOOP => true,
				FSBANK_RESULT.FSBANK_WARN_IGNORED_FILTERHIGHFREQ => true,
				FSBANK_RESULT.FSBANK_WARN_IGNORED_DISABLESEEKING => true,
				FSBANK_RESULT.FSBANK_WARN_FORCED_DONTWRITENAMES => true,
				_ => false,
			};
		}

		public static bool IsError(this FSBANK_RESULT result)
		{
			return result switch
			{
				FSBANK_RESULT.FSBANK_ERR_CACHE_CHUNKNOTFOUND => true,
				FSBANK_RESULT.FSBANK_ERR_CANCELLED => true,
				FSBANK_RESULT.FSBANK_ERR_CANNOT_CONTINUE => true,
				FSBANK_RESULT.FSBANK_ERR_ENCODER => true,
				FSBANK_RESULT.FSBANK_ERR_ENCODER_INIT => true,
				FSBANK_RESULT.FSBANK_ERR_ENCODER_NOTSUPPORTED => true,
				FSBANK_RESULT.FSBANK_ERR_FILE_OS => true,
				FSBANK_RESULT.FSBANK_ERR_FILE_NOTFOUND => true,
				FSBANK_RESULT.FSBANK_ERR_FMOD => true,
				FSBANK_RESULT.FSBANK_ERR_INITIALIZED => true,
				FSBANK_RESULT.FSBANK_ERR_INVALID_FORMAT => true,
				FSBANK_RESULT.FSBANK_ERR_INVALID_PARAM => true,
				FSBANK_RESULT.FSBANK_ERR_MEMORY => true,
				FSBANK_RESULT.FSBANK_ERR_UNINITIALIZED => true,
				FSBANK_RESULT.FSBANK_ERR_WRITER_FORMAT => true,
				FSBANK_RESULT.FSBANK_ERR_ENCODER_FILE_NOTFOUND => true,
				FSBANK_RESULT.FSBANK_ERR_ENCODER_FILE_BAD => true,
				_ => false,
			};
		}
	}
}
