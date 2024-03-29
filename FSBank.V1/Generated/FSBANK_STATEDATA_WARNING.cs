//C# bindings for FSBank generated by ClangSharp
//https://github.com/dotnet/ClangSharp
//
//FSBank is part of FMOD Studio, copyright © Firelight Technologies Pty, Ltd., 1994-2016.
//See FMOD_LICENSE.txt for full license terms and conditions.

namespace FSBank.V1;

/// <include file='FSBANK_STATEDATA_WARNING.xml' path='doc/member[@name="FSBANK_STATEDATA_WARNING"]/*' />
public unsafe partial struct FSBANK_STATEDATA_WARNING
{
    /// <include file='FSBANK_STATEDATA_WARNING.xml' path='doc/member[@name="FSBANK_STATEDATA_WARNING.warnCode"]/*' />
    public FSBANK_RESULT warnCode;

    /// <include file='FSBANK_STATEDATA_WARNING.xml' path='doc/member[@name="FSBANK_STATEDATA_WARNING.warningString"]/*' />
    [NativeTypeName("char[256]")]
    public fixed sbyte warningString[256];
}
