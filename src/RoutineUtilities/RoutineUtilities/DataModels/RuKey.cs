namespace RoutineUtilities.DataModels;

/// <summary>
/// Represents a key-value pair where the key is a string and the value is of a specified type.
/// </summary>
/// <typeparam name="TType">The type of the value.</typeparam>
public record RuKey<TType>
{
    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    [JsonPropertyName("value")]
    public required TType Value { get; set; }
}