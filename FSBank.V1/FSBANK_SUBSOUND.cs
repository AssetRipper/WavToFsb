/* Copyright (c) ds5678
 * See LICENSE.txt for full details
 */

namespace FSBank.V1
{
	public unsafe partial struct FSBANK_SUBSOUND
	{
		/// <summary>
		/// Flags that will reverse the equivalent <see cref="FSBankBuildFlags"/> flags passed to FSBank_Build.
		/// </summary>
		public FSBankBuildFlags OverrideFlags
		{
			get
			{
				return unchecked((FSBankBuildFlags)overrideFlags);
			}
			set
			{
				overrideFlags = unchecked((uint)value);
			}
		}
	}
}
