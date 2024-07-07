namespace RoutineUtilities.Enumerators;

/// <summary>
/// Represents the possible responses for document validation.
/// </summary>
public enum DocumentValidationResponse
{
    /// <summary>
    /// Indicates that the document is invalid.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// Indicates that the document is valid.
    /// </summary>
    Valid = 1,

    /// <summary>
    /// Indicates that the document has the wrong size.
    /// </summary>
    WrongSize = 2
}