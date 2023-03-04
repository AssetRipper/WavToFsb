/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

using System;

namespace FSBank.V1
{
	public sealed class FSBankException : Exception
    {
		public FSBANK_RESULT ErrorCode { get; }
		public FSBankException(FSBANK_RESULT errorCode)
		{
			ErrorCode = errorCode;
		}

        public override string Message => ErrorCode.ToErrorString();
    }
}
