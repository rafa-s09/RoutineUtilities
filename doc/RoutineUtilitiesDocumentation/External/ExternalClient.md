# ExternalClient Class

> Provides methods to send HTTP requests (GET, POST, PUT, DELETE, custom) to an external API, with responses in the `RuHttpResponse` format.

## Constructor

### ExternalClient(string baseUrl)

Initializes a new instance of the `ExternalClient` class with the specified base URL.

#### Parameters
- `string baseUrl`: The base URL for the API.

## Methods

[[#HTTP Methods]]
	[[#GetAsync]]
	[[#PostAsync]]
	[[#PutAsync]]
	[[#DeleteAsync]]
	[[#SendAsync]]
	[[#StreamAsync]]
[[#Disposable Method]]
	[[#Dispose]]

## HTTP Methods
### GetAsync

Sends a GET request to the specified URL.

#### Parameters

- `string url`: The URL to send the request to.
- `IEnumerable<RuKey<string>>? headers`: Optional headers to include in the request.

#### Returns

- `Task<RuHttpResponse<TType?>>`: The response content in a `RuHttpResponse<TType?>`.

### PostAsync

Sends a POST request to the specified URL with the specified content.

#### Parameters
- `string url`: The URL to send the request to.
- `TType content`: The content to send in the request.
- `IEnumerable<RuKey<string>>? headers`: Optional headers to include in the request.
#### Returns
- `Task<RuHttpResponse<TResponse?>>`: The response content in a `RuHttpResponse<TResponse?>`.

### PutAsync

Sends a PUT request to the specified URL with the specified content.

#### Parameters
- `string url`: The URL to send the request to.
- `TType content`: The content to send in the request.
- `IEnumerable<RuKey<string>>? headers`: Optional headers to include in the request.
#### Returns
- `Task<RuHttpResponse<TResponse?>>`: The response content in a `RuHttpResponse<TResponse?>`.

### DeleteAsync

Sends a DELETE request to the specified URL.

#### Parameters
- `string url`: The URL to send the request to.
- `IEnumerable<RuKey<string>>? headers`: Optional headers to include in the request.
#### Returns
- `Task<RuHttpResponse<TResponse?>>`: The response content in a `RuHttpResponse<TResponse?>`.

### SendAsync

Sends an HTTP request.

#### Parameters
- `HttpRequestMessage request`: The HTTP request message to send.
- `IEnumerable<RuKey<string>>? headers`: Optional headers to include in the request.
#### Returns
- `Task<RuHttpResponse<TResponse?>>`: The response content in a `RuHttpResponse<TResponse?>`.

### StreamAsync

Sends a GET request to the specified URL and returns the response stream.

#### Parameters
- `string url`: The URL to send the request to.
- `IEnumerable<RuKey<string>>? headers`: Optional headers to include in the request.
#### Returns
- `Task<RuHttpResponse<Stream>>`: The response stream in a `RuHttpResponse<Stream>`.

### Disposable Method

#### Dispose

Releases all resources used by the current instance of the `ExternalClient` class.

## Example
```csharp
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var client = new ExternalClient("https://api.example.com");

        // GET request
        var getResult = await client.GetAsync<MyResponseType>("endpoint");
        Console.WriteLine($"Code: {getResult.Code}, Message: {getResult.Message}, Content: {getResult.Content}");

        // POST request
        var postResult = await client.PostAsync<MyRequestType, MyResponseType>("endpoint", new MyRequestType());
        Console.WriteLine($"Code: {postResult.Code}, Message: {postResult.Message}, Content: {postResult.Content}");

        // PUT request
        var putResult = await client.PutAsync<MyRequestType, MyResponseType>("endpoint", new MyRequestType());
        Console.WriteLine($"Code: {putResult.Code}, Message: {putResult.Message}, Content: {putResult.Content}");

        // DELETE request
        var deleteResult = await client.DeleteAsync<MyResponseType>("endpoint");
        Console.WriteLine($"Code: {deleteResult.Code}, Message: {deleteResult.Message}, Content: {deleteResult.Content}");

        // Send custom request
        var request = new HttpRequestMessage(HttpMethod.Get, "endpoint");
        var sendResult = await client.SendAsync<MyRequestType, MyResponseType>(request);
        Console.WriteLine($"Code: {sendResult.Code}, Message: {sendResult.Message}, Content: {sendResult.Content}");

        // Get response stream
        var streamResult = await client.StreamAsync("endpoint");
        Console.WriteLine($"Code: {streamResult.Code}, Message: {streamResult.Message}");

        client.Dispose();
    }
}
```