namespace RoutineUtilities.Enumerators;

/// <summary>
/// Represents various text encoding formats.
/// </summary>
public enum TextEncode
{
    /// <summary>
    /// American Standard Code for Information Interchange (ASCII) encoding.
    /// </summary>
    ASCII = 0,

    /// <summary>
    /// 8-bit Unicode Transformation Format (UTF-8) encoding.
    /// </summary>
    UTF8 = 1,

    /// <summary>
    /// 16-bit Unicode Transformation Format (UTF-16) encoding.
    /// </summary>
    UTF16 = 2,

    /// <summary>
    /// 32-bit Unicode Transformation Format (UTF-32) encoding.
    /// </summary>
    UTF32 = 3,

    /// <summary>
    /// Universal Character Set (UCS-2) encoding, also known as Unicode.
    /// </summary>
    Unicode = 4,

    /// <summary>
    /// ISO/IEC 8859-1 (Latin-1) encoding.
    /// </summary>
    Latin1 = 5
}