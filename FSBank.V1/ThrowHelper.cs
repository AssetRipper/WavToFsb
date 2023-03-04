/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

using System;

namespace FSBank.V1
{
	internal static class ThrowHelper
	{
		public static void MaybeThrowFSBankException(FSBANK_RESULT errorCode, bool treatWarningAsError = false)
		{
			if (!errorCode.IsOK() && (!errorCode.IsWarning() || treatWarningAsError))
			{
				throw new FSBankException(errorCode);
			}
		}

		public static void MaybeWarnOrThrowFSBankException(FSBANK_RESULT errorCode)
		{
			if (errorCode.IsError())
			{
				throw new FSBankException(errorCode);
			}
			else if (errorCode.IsWarning())
			{
				Console.WriteLine(errorCode.ToErrorString());
			}
		}
	}
}
