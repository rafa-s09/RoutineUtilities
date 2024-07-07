namespace RoutineUtilities.DataModels;

/// <summary>
/// Represents an HTTP response with a status code, message, and optional content of a specified type.
/// </summary>
/// <typeparam name="TType">The type of the content.</typeparam>
public record RuHttpResponse<TType>
{
    /// <summary>
    /// Gets or sets the status code of the HTTP response.
    /// </summary>
    [JsonPropertyName("code")]
    public required int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the HTTP response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the content of the HTTP response.
    /// </summary>
    [JsonPropertyName("content")]
    public TType? Content { get; set; }
}