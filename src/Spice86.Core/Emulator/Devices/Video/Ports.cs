namespace Spice86.Core.Emulator.Devices.Video;

public static class Ports {
    public const int CrtControllerAddress = 0x03B4;
    public const int CrtControllerData = 0x03B5;
    public const int InputStatus1Read = 0x03BA;
    public const int FeatureControlWrite = 0x03BA;
    public const int AttributeAddress = 0x03C0;
    public const int AttributeData = 0x03C1;
    public const int InputStatus0Read = 0x03C2;
    public const int MiscOutputWrite = 0x03C2;
    public const int SequencerAddress = 0x03C4;
    public const int SequencerData = 0x03C5;
    public const int DacPelMask = 0x03C6;
    public const int DacStateRead = 0x03C7;
    public const int DacAddressReadIndex = 0x03C7;
    public const int DacAddressWriteIndex = 0x03C8;
    public const int DacData = 0x03C9;
    public const int FeatureControlRead = 0x03CA;
    public const int MiscOutputRead = 0x03CC;
    public const int GraphicsControllerAddress = 0x03CE;
    public const int GraphicsControllerData = 0x03CF;
    public const int CrtControllerAddressAltMirror1 = 0x03D0;
    public const int CrtControllerDataAltMirror1 = 0x03D1;
    public const int CrtControllerAddressAltMirror2 = 0x03D2;
    public const int CrtControllerDataAltMirror2 = 0x03D3;
    public const int CrtControllerAddressAlt = 0x03D4;
    public const int CrtControllerDataAlt = 0x03D5;
    public const int CgaModeControl = 0x03D8;
    public const int CgaColorSelect = 0x03D9;
    public const int InputStatus1ReadAlt = 0x03DA;
    public const int FeatureControlWriteAlt = 0x03DA;
}