# RuHttpResponse Record

> Represents an HTTP response with a status code, message, and optional content of a specified type.

## Type Parameters

- `TType`: The type of the content.

## Properties

### Code

Gets or sets the status code of the HTTP response.
- `required int Code`

### Message

Gets or sets the message of the HTTP response.
- `string? Message`

### Content

Gets or sets the content of the HTTP response.
- `TType? Content`

## Constructor

### RuHttpResponse(int code, string message, TType? content = default)

Initializes a new instance of the `RuHttpResponse<TType>` class with the specified code, message, and optional content.
#### Parameters
- `int code`: The status code of the HTTP response.
- `string message`: The message of the HTTP response.
- `TType? content`: The content of the HTTP response.

## Example

```csharp
// Creating an instance of RuHttpResponse with string type content
RuHttpResponse<string> response = new RuHttpResponse<string>() { Code = 200, Message = "OK", Content = "Response content" };
Console.WriteLine($"Code: {response.Code}, Message: {response.Message}, Content: {response.Content}");

// Creating an instance of RuHttpResponse with int type content
RuHttpResponse<int> intResponse = new RuHttpResponse<int>() { Code = 404, Message = "Not Found", Content = null;
Console.WriteLine($"Code: {intResponse.Code}, Message: {intResponse.Message}, Content: {intResponse.Content}");
```
