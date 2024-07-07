# Extensions Class

>Provides extension methods for various string operations including text manipulation, text encoding conversions,  SQL injection checking, invalid character detection, clearing special characters and date and time comparison.

## Methods

[[#Text Methods]]
	[[#GetUntilOrEmpty]]
	[[#GetUntil]]
	[[#GetAfterOrEmpty]]
	[[#GetAfter]]
	[[#CheckforSqlInjection]]
	[[#CheckForInvalidCharacters]]
[[#Clear Special Characters Methods]]
	[[#ClearSymbolsRegex]]
	[[#ClearAccentedCharacters]]
	[[#ClearSymbols]]
	[[#ClearSpecialCharacters]]
[[#Generic Conversions Methods]]
	[[#StringToByteArray]]
	[[#ByteArrayToString]]
	[[#Parameters]]
	[[#ConvertToEnum]]
	[[#ConvertToEnumOrDefault]]
[[#DateTime Functions Methods]]
	[[#HasExpiryDatePassed]]
	[[#HasExpiryDatePassedIgnoringTime]]
	[[#IsDateTimeWithinRange]]
	[[#IsDateTimeWithinRangeIgnoringTime]]
	[[#HasExpiryDateOffsetPassed]]
	[[#HasExpiryDateOffsetPassedIgnoringTime]]
	[[#IsDateOffsetWithinRange]]
	[[#IsDateOffsetWithinRangeIgnoringTime]]
	[[#ToName (DateTime)]]
	[[#ToName (DateTimeOffset)]]


### Text Methods

#### GetUntilOrEmpty

Gets the substring from the start of the string up to the first occurrence of a specified character. Returns an empty string if the input string is null, empty, or whitespace.
##### Parameters
- `string text`: The input string.
- `char stopAt`: The character to stop at.
##### Returns
- `string`: The substring up to the specified character, or an empty string.

#### GetUntil

Gets the substring from the start of the string up to the first occurrence of a specified character. Returns the original string if the input string is null, empty, or whitespace.
##### Parameters
- `string text`: The input string.
- `char stopAt`: The character to stop at.
##### Returns
- `string`: The substring up to the specified character, or the original string.

#### GetAfterOrEmpty

Gets the substring from the first occurrence of a specified character to the end of the string. Returns an empty string if the input string is null, empty, or whitespace.
##### Parameters
- `string text`: The input string.
- `char startAt`: The character to start at.
##### Returns
- `string`: The substring from the specified character to the end of the string, or an empty string.

#### GetAfter

Gets the substring from the first occurrence of a specified character to the end of the string. Returns the original string if the input string is null, empty, or whitespace.
##### Parameters
- `string text`: The input string.
- `char startAt`: The character to start at.
##### Returns
- `string`: The substring from the specified character to the end of the string, or the original string.

#### CheckforSqlInjection

Checks if the input string contains any SQL reserved words, indicating potential SQL injection.
##### Parameters
- `string text`: The input string.
##### Returns
- `bool`: True if the string contains SQL reserved words; otherwise, false.

#### CheckForInvalidCharacters

Checks if the input string contains any invalid characters specified in a given string.
##### Parameters
- `string text`: The input string.
- `string invalidCharacterString`: A string containing invalid characters to check for.
##### Returns
- `bool`: True if the string contains any invalid characters; otherwise, false.

### Clear Special Characters Methods

#### ClearSymbolsRegex

Regular expression to match symbols to be cleared.
##### Returns
- `Regex`: A Regex object for matching symbols.

#### ClearAccentedCharacters

Replaces accented characters in the input string with their non-accented equivalents.
##### Parameters
- `string value`: The input string.
##### Returns
- `string`: The string with accented characters replaced by non-accented equivalents.
##### Exceptions
- `ArgumentNullException`: Thrown when the input string is null.

#### ClearSymbols

Clears symbols from the input string, optionally replacing them with spaces.
##### Parameters
- `string value`: The input string.
- `bool useSpace`: If true, replaces symbols with spaces; otherwise, removes them.
##### Returns
- `string`: The string with symbols cleared.
##### Exceptions
- `ArgumentNullException`: Thrown when the input string is null.

#### ClearSpecialCharacters

Clears special characters from the input string, optionally replacing them with spaces.
##### Parameters
- `string value`: The input string.
- `bool useSpace`: If true, replaces special characters with spaces; otherwise, removes them.
##### Returns
- `string`: The string with special characters cleared.
##### Exceptions
- `ArgumentNullException`: Thrown when the input string is null.

### Generic Conversions Methods

#### StringToByteArray

Converts a string to a byte array using the specified text encoding.
##### Parameters
- `string value`: The input string to convert.
- `TextEncode encode`: The text encoding to use. Default is UTF-8.
##### Returns
- `byte[]`: A byte array representation of the input string.
##### Exceptions
- `ArgumentNullException`: Thrown when the input string is null.

#### ByteArrayToString

Converts a byte array to a string using the specified text encoding.
##### Parameters
- `byte[] value`: The byte array to convert.
- `TextEncode encode`: The text encoding to use. Default is UTF-8.
##### Returns
- `string`: A string representation of the byte array.
##### Exceptions
- `ArgumentNullException`: Thrown when the input byte array is null.

#### ConvertToEnum

Converts an integer value to an enumeration of the specified type.
##### Parameters
- `int value`: The integer value to convert.
##### Returns
- `TEnum`: The corresponding enumeration value.
##### Exceptions
- `ArgumentException`: Thrown when the value is not defined in the enumeration.

#### ConvertToEnumOrDefault

Converts an integer value to an enumeration of the specified type, or returns the default value if the conversion is not possible.
##### Parameters
- `int value`: The integer value to convert.
##### Returns
- `TEnum`: The corresponding enumeration value, or the default value if the conversion is not possible.
##### Exceptions
- `ArgumentException`: Thrown when the enumeration has no defined values.

### DateTime Functions Methods

#### HasExpiryDatePassed

Checks if the expiry date has passed.
##### Parameters
- `DateTime expiryDate`: The expiry date to check.
##### Returns
- `bool`: True if the expiry date has passed; otherwise, false.
##### Example
```csharp
DateTime expiryDate = new DateTime(2023, 6, 1);
bool hasPassed = expiryDate.HasExpiryDatePassed(); // Returns true if the current date is after June 1, 2023.
```

#### HasExpiryDatePassedIgnoringTime

Checks if the expiry date has passed, ignoring the time of day.
##### Parameters
- `DateTime expiryDate`: The expiry date to check.
##### Returns
- `bool`: True if the expiry date has passed, ignoring the time of day; otherwise, false.

##### Example

```csharp
DateTime expiryDate = new DateTime(2023, 6, 1); bool hasPassed = expiryDate.HasExpiryDatePassedIgnoringTime(); // Returns true if the current date is after June 1, 2023, ignoring the time of day.
```

#### IsDateTimeWithinRange

Checks if a date is within a specified range, including the start and end dates.
##### Parameters
- `DateTime date`: The date to check.
- `DateTime start`: The start date of the range.
- `DateTime end`: The end date of the range.
##### Returns
- `bool`: True if the date is within the specified range; otherwise, false.
##### Example

```
DateTime date = new DateTime(2023, 6, 15); DateTime start = new DateTime(2023, 6, 1); DateTime end = new DateTime(2023, 6, 30); bool isWithinRange = date.IsDateTimeWithinRange(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023.
```

#### IsDateTimeWithinRangeIgnoringTime

Checks if a date is within a specified range, including the start and end dates, ignoring the time of day.
##### Parameters
- `DateTime date`: The date to check.
- `DateTime start`: The start date of the range.
- `DateTime end`: The end date of the range.
##### Returns
- `bool`: True if the date is within the specified range, ignoring the time of day; otherwise, false.
##### Example

```csharp
DateTime date = new DateTime(2023, 6, 15); DateTime start = new DateTime(2023, 6, 1); DateTime end = new DateTime(2023, 6, 30); bool isWithinRange = date.IsDateTimeWithinRangeIgnoringTime(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023, ignoring the time of day.
```

#### HasExpiryDateOffsetPassed

Checks if the expiry date (DateTimeOffset) has passed.
##### Parameters
- `DateTimeOffset expiryDate`: The expiry date to check.
##### Returns
- `bool`: True if the expiry date has passed; otherwise, false.
##### Example

```csharp
DateTimeOffset expiryDate = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero); bool hasPassed = expiryDate.HasExpiryDateOffsetPassed(); // Returns true if the current date is after June 1, 2023.
```

#### HasExpiryDateOffsetPassedIgnoringTime

Checks if the expiry date (DateTimeOffset) has passed, ignoring the time of day.
##### Parameters
- `DateTimeOffset expiryDate`: The expiry date to check.
##### Returns
- `bool`: True if the expiry date has passed, ignoring the time of day; otherwise, false.
##### Example

```csharp
DateTimeOffset expiryDate = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero); bool hasPassed = expiryDate.HasExpiryDateOffsetPassedIgnoringTime(); // Returns true if the current date is after June 1, 2023, ignoring the time of day.
```

#### IsDateOffsetWithinRange

Checks if a date (DateTimeOffset) is within a specified range, including the start and end dates.
##### Parameters
- `DateTimeOffset date`: The date to check.
- `DateTimeOffset start`: The start date of the range.
- `DateTimeOffset end`: The end date of the range.
##### Returns
- `bool`: True if the date is within the specified range; otherwise, false.
##### Example

```csharp
DateTimeOffset date = new DateTimeOffset(2023, 6, 15, 0, 0, 0, TimeSpan.Zero); DateTimeOffset start = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero); DateTimeOffset end = new DateTimeOffset(2023, 6, 30, 0, 0, 0, TimeSpan.Zero); bool isWithinRange = date.IsDateOffsetWithinRange(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023.
```

#### IsDateOffsetWithinRangeIgnoringTime

Checks if a date (DateTimeOffset) is within a specified range, including the start and end dates, ignoring the time of day.
##### Parameters
- `DateTimeOffset date`: The date to check.
- `DateTimeOffset start`: The start date of the range.
- `DateTimeOffset end`: The end date of the range.
##### Returns
- `bool`: True if the date is within the specified range, ignoring the time of day; otherwise, false.
##### Example

```csharp
DateTimeOffset date = new DateTimeOffset(2023, 6, 15, 0, 0, 0, TimeSpan.Zero); DateTimeOffset start = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero); DateTimeOffset end = new DateTimeOffset(2023, 6, 30, 0, 0, 0, TimeSpan.Zero); bool isWithinRange = date.IsDateOffsetWithinRangeIgnoringTime(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023, ignoring the time of day.
```

#### ToName (DateTime)

Converts a DateTime to a string formatted as "yyyyMMddHHmmss" or "yyyyMMdd-HHmmss".
##### Parameters
- `DateTime date`: The DateTime to format.
- `bool separedTime`: If true, separates the date and time with a hyphen; otherwise, concatenates them.
##### Returns
- `string`: A string representation of the DateTime.
##### Example

```csharp
DateTime date = new DateTime(2023, 6, 15, 14, 30, 0); string formattedDate = date.ToName(); // Returns "20230615143000". string formattedDateWithHyphen = date.ToName(true); // Returns "20230615-143000".
```

#### ToName (DateTimeOffset)

Converts a DateTimeOffset to a string formatted as "yyyyMMddHHmmss" or "yyyyMMdd-HHmmss".
##### Parameters
- `DateTimeOffset date`: The DateTimeOffset to format.
- `bool separedTime`: If true, separates the date and time with a hyphen; otherwise, concatenates them.
##### Returns
- `string`: A string representation of the DateTimeOffset.
##### Example

```csharp
DateTimeOffset date = new DateTimeOffset(2023, 6, 15, 14, 30, 0, TimeSpan.Zero); string formattedDate = date.ToName(); // Returns "20230615143000". string formattedDateWithHyphen = date.ToName(true); // Returns "20230615-143000".
```