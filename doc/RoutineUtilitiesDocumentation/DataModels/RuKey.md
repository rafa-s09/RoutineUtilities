# RuKey Record

>Represents a key-value pair where the key is a string and the value is of a specified type.

## Type Parameters

- `TType`: The type of the value.

## Properties

### Key

Gets or sets the key.
- `required string Key`

### Value

Gets or sets the value.
- `required TType Value`

## Constructor

### RuKey(string key, TType value)

Initializes a new instance of the `RuKey<TType>` class with the specified key and value.
#### Parameters
- `string key`: The key.
- `TType value`: The value.

## Example

```csharp
// Creating an instance of RuKey with string type value
RuKey<string> stringKeyValue = new RuKey<string>() { Key = "ExampleKey", Value = "ExampleValue" };
Console.WriteLine($"Key: {stringKeyValue.Key}, Value: {stringKeyValue.Value}");

// Creating an instance of RuKey with int type value
RuKey<int> intKeyValue = new RuKey<int>() { Key = "NumberKey", Value = 123 };
Console.WriteLine($"Key: {intKeyValue.Key}, Value: {intKeyValue.Value}");
```
