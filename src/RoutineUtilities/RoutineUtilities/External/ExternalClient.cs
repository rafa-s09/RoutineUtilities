namespace RoutineUtilities.External;

/// <summary>
/// Initializes a new instance of the <see cref="ExternalClient"/> class with the specified base URL.
/// </summary>
/// <param name="baseUrl">The base URL for the API.</param>
public class ExternalClient : IDisposable
{
    #region Constructor

    /// <summary>
    /// Private Common HttpClient
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalClient"/> class with the specified base URL.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API.</param>
    public ExternalClient(string baseUrl) => _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };

    #endregion Constructor

    #region Disposable

    /// <summary>
    /// Finalizes an instance of the <see cref="ExternalClient"/> class.
    /// </summary>
    ~ExternalClient() => Dispose();

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="ExternalClient"/> class.
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }

    #endregion Disposable

    #region Private Methods

    /// <summary>
    /// Sets the headers for the HTTP client.
    /// </summary>
    /// <param name="headers">A collection of headers to set.</param>
    private void SetHeaders(IEnumerable<RuKey<string>> headers)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        foreach (RuKey<string> header in headers)
            _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
    }

    #endregion Private Methods

    #region Public Methods

    /// <summary>
    /// Sends a GET request to the specified URL.
    /// </summary>
    /// <typeparam name="TType">The type of the response content.</typeparam>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="headers">Optional headers to include in the request.</param>
    /// <returns>The response content in a <see cref="RuHttpResponse{TType}"/>.</returns>
    public async Task<RuHttpResponse<TType?>> GetAsync<TType>(string url, IEnumerable<RuKey<string>>? headers = null)
    {
        if (headers != null)
            SetHeaders(headers);

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadFromJsonAsync<TType>();
        return new RuHttpResponse<TType?>() { Code = (int)response.StatusCode, Message = response.ReasonPhrase ?? string.Empty, Content = content };
    }

    /// <summary>
    /// Sends a POST request to the specified URL with the specified content.
    /// </summary>
    /// <typeparam name="TType">The type of the request content.</typeparam>
    /// <typeparam name="TResponse">The type of the response content.</typeparam>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="content">The content to send in the request.</param>
    /// <param name="headers">Optional headers to include in the request.</param>
    /// <returns>The response content in a <see cref="RuHttpResponse{TResponse}"/>.</returns>
    public async Task<RuHttpResponse<TResponse?>> PostAsync<TType, TResponse>(string url, TType content, IEnumerable<RuKey<string>>? headers = null)
    {
        if (headers != null)
            SetHeaders(headers);

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, content);
        var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
        return new RuHttpResponse<TResponse?>() { Code = (int)response.StatusCode, Message = response.ReasonPhrase ?? string.Empty, Content = responseData };
    }

    /// <summary>
    /// Sends a PUT request to the specified URL with the specified content.
    /// </summary>
    /// <typeparam name="TType">The type of the request content.</typeparam>
    /// <typeparam name="TResponse">The type of the response content.</typeparam>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="content">The content to send in the request.</param>
    /// <param name="headers">Optional headers to include in the request.</param>
    /// <returns>The response content in a <see cref="RuHttpResponse{TResponse}"/>.</returns>
    public async Task<RuHttpResponse<TResponse?>> PutAsync<TType, TResponse>(string url, TType content, IEnumerable<RuKey<string>>? headers = null)
    {
        if (headers != null)
            SetHeaders(headers);

        HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, content);
        var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
        return new RuHttpResponse<TResponse?>() { Code = (int)response.StatusCode, Message = response.ReasonPhrase ?? string.Empty, Content = responseData };
    }

    /// <summary>
    /// Sends a DELETE request to the specified URL.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response content.</typeparam>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="headers">Optional headers to include in the request.</param>
    /// <returns>The response content in a <see cref="RuHttpResponse{TResponse}"/>.</returns>
    public async Task<RuHttpResponse<TResponse?>> DeleteAsync<TResponse>(string url, IEnumerable<RuKey<string>>? headers = null)
    {
        if (headers != null)
            SetHeaders(headers);

        HttpResponseMessage response = await _httpClient.DeleteAsync(url);
        var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
        return new RuHttpResponse<TResponse?>() { Code = (int)response.StatusCode, Message = response.ReasonPhrase ?? string.Empty, Content = responseData };
    }

    /// <summary>
    /// Sends an HTTP request.
    /// </summary>
    /// <typeparam name="TType">The type of the request content.</typeparam>
    /// <typeparam name="TResponse">The type of the response content.</typeparam>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="headers">Optional headers to include in the request.</param>
    /// <returns>The response content in a <see cref="RuHttpResponse{TResponse}"/>.</returns>
    public async Task<RuHttpResponse<TResponse?>> SendAsync<TType, TResponse>(HttpRequestMessage request, IEnumerable<RuKey<string>>? headers = null)
    {
        if (headers != null)
            SetHeaders(headers);

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
        return new RuHttpResponse<TResponse?>() { Code = (int)response.StatusCode, Message = response.ReasonPhrase ?? string.Empty, Content = responseData };
    }

    /// <summary>
    /// Sends a GET request to the specified URL and returns the response stream.
    /// </summary>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="headers">Optional headers to include in the request.</param>
    /// <returns>The response stream in a <see cref="RuHttpResponse{Stream}"/>.</returns>
    public async Task<RuHttpResponse<Stream>> StreamAsync(string url, IEnumerable<RuKey<string>>? headers = null)
    {
        if (headers != null)
            SetHeaders(headers);

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        var responseData = await response.Content.ReadAsStreamAsync();
        return new RuHttpResponse<Stream>() { Code = (int)response.StatusCode, Message = response.ReasonPhrase ?? string.Empty, Content = responseData };
    }

    #endregion Public Methods
}
