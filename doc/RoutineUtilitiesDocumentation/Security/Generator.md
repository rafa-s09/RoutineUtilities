# Generator Class

> Provides methods for generating random text, unique identifiers, and GUIDs.

## Methods

[[#RandomText]]
[[#Uid]]
[[#DefaultGuid]]

### RandomText

Generates a random string of the specified length, optionally including special characters.
#### Parameters
- `int length`: The length of the random string to generate.
- `bool includeSpecialCharacters`: If true, includes special characters in the random string; otherwise, only alphanumeric characters are included. Default is false.
#### Returns
- `string`: A random string of the specified length.
#### Example
```csharp
string randomString = Generator.RandomText(10, true);
```

### Uid

Generates a unique identifier string in the format "XXX-XXXXX-XXXXX-XXXX".
####  Returns
- `string`: A unique identifier string.
#### Example
```csharp
string uid = Generator.Uid();
```

### DefaultGuid

Generates a GUID (Globally Unique Identifier) string, optionally including special characters.
#### Parameters
- `bool includeSpecialCharacters`: If true, includes hyphens in the GUID string; otherwise, returns a hyphen-less GUID string. Default is true.
#### Returns
- `string`: A GUID string.
#### Example
```csharp
string guid = Generator.DefaultGuid(); 
```

```csharp
string guidWithoutHyphens = Generator.DefaultGuid(false); 
```