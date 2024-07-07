namespace RoutineUtilities.Utility;

/// <summary>
/// Provides extension methods for various string operations including text manipulation, text encoding conversions, 
/// SQL injection checking, invalid character detection, clearing special characters and date and time comparison.
/// </summary>
public static partial class Extensions
{
    #region Text

    /// <summary>
    /// Gets the substring from the start of the string up to the first occurrence of a specified character.
    /// Returns an empty string if the input string is null, empty, or whitespace.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="stopAt">The character to stop at.</param>
    /// <returns>The substring up to the specified character, or an empty string.</returns>
    public static string GetUntilOrEmpty(this string text, char stopAt)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);
        return charLocation > 0 ? text[..charLocation] : string.Empty;
    }

    /// <summary>
    /// Gets the substring from the start of the string up to the first occurrence of a specified character.
    /// Returns the original string if the input string is null, empty, or whitespace.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="stopAt">The character to stop at.</param>
    /// <returns>The substring up to the specified character, or the original string.</returns>
    public static string GetUntil(this string text, char stopAt)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);
        return charLocation > 0 ? text[..charLocation] : text;

    }

    /// <summary>
    /// Gets the substring from the first occurrence of a specified character to the end of the string.
    /// Returns an empty string if the input string is null, empty, or whitespace.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="startAt">The character to start at.</param>
    /// <returns>The substring from the specified character to the end of the string, or an empty string.</returns>
    public static string GetAfterOrEmpty(this string text, char startAt)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        int charLocation = text.IndexOf(startAt, StringComparison.Ordinal);
        return charLocation > 0 ? text[(charLocation + 1)..] : string.Empty;
    }

    /// <summary>
    /// Gets the substring from the first occurrence of a specified character to the end of the string.
    /// Returns the original string if the input string is null, empty, or whitespace.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="startAt">The character to start at.</param>
    /// <returns>The substring from the specified character to the end of the string, or the original string.</returns>
    public static string GetAfter(this string text, char startAt)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        int charLocation = text.IndexOf(startAt, StringComparison.Ordinal);
        return charLocation > 0 ? text[(charLocation + 1)..] : text;
    }

    /// <summary>
    /// Checks if the input string contains any SQL reserved words, indicating potential SQL injection.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <returns>True if the string contains SQL reserved words; otherwise, false.</returns>
    public static bool CheckforSqlInjection(this string text)
    {
        string[] SQLReservedWords = ["SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "CREATE", "ALTER", "EXECUTE", "UNION", "FROM", "WHERE", "OR", "AND", "INTO", "VALUES", "TABLE", "DATABASE"];

        foreach (string keyWord in SQLReservedWords)
            if (text.ToUpper().IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) > 0)
                return true;

        return false;
    }

    /// <summary>
    /// Checks if the input string contains any invalid characters specified in a given string.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="invalidCharacterString">A string containing invalid characters to check for.</param>
    /// <returns>True if the string contains any invalid characters; otherwise, false.</returns>
    public static bool CheckForInvalidCharacters(this string text, string invalidCharacterString)
    {
        for (int i = 0; i < invalidCharacterString.Length; i++)
            if (text.IndexOf(invalidCharacterString[i], StringComparison.OrdinalIgnoreCase) > 1)
                return true;

        return false;
    }

    #endregion Text

    #region Clear Special Characters

    /// <summary>
    /// Regular expression to match symbols to be cleared.
    /// </summary>
    /// <returns>A Regex object for matching symbols.</returns>
    [GeneratedRegex(@"[^0-9A-Za-za-çÇáéíóúýÁÉÍÓÚÝàèìòùÀÈÌÒÙãõñäëïöüÿÄËÏÖÜÃÕÑâêîôûÂÊÎÔÛ ,]")]
    private static partial Regex ClearSymbolsRegex();

    /// <summary>
    /// Replaces accented characters in the input string with their non-accented equivalents.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string with accented characters replaced by non-accented equivalents.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
    public static string ClearAccentedCharacters(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value.Length < 1)
            return value;

        string result = value;
        string[] accented = ["ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û"];
        string[] nonAccented = ["c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U"];

        for (int i = 0; i < accented.Length; i++)
            result = result.Replace(accented[i], nonAccented[i]);

        return result;
    }

    /// <summary>
    /// Clears symbols from the input string, optionally replacing them with spaces.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <param name="useSpace">If true, replaces symbols with spaces; otherwise, removes them.</param>
    /// <returns>The string with symbols cleared.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
    public static string ClearSymbols(this string value, bool useSpace = false)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value.Length < 1)
            return value;

        if (useSpace)
            return ClearSymbolsRegex().Replace(value, " ").Replace("}", " ").Replace("{", " ").Replace("|", " ").Replace(",", " ").Replace("~", " ");
        else
            return ClearSymbolsRegex().Replace(value, "").Replace("}", "").Replace("{", "").Replace("|", "").Replace(",", "").Replace("~", "");
    }

    /// <summary>
    /// Clears special characters from the input string, optionally replacing them with spaces.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <param name="useSpace">If true, replaces special characters with spaces; otherwise, removes them.</param>
    /// <returns>The string with special characters cleared.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
    public static string ClearSpecialCharacters(this string value, bool useSpace = false)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value.Length < 1)
            return value;

        string result = value.ClearAccentedCharacters();
        return result.ClearSymbols(useSpace);
    }

    #endregion Clear Special Characters

    #region Generic Conversions 

    /// <summary>
    /// Converts a string to a byte array using the specified text encoding.
    /// </summary>
    /// <param name="value">The input string to convert.</param>
    /// <param name="encode">The text encoding to use. Default is UTF-8.</param>
    /// <returns>A byte array representation of the input string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
    public static byte[] StringToByteArray(this string value, TextEncode encode = TextEncode.UTF8)
    {
        ArgumentNullException.ThrowIfNull(value);

        return encode switch
        {
            TextEncode.ASCII => Encoding.ASCII.GetBytes(value),
            TextEncode.UTF8 => Encoding.UTF8.GetBytes(value),
            TextEncode.UTF16 => Encoding.BigEndianUnicode.GetBytes(value),
            TextEncode.UTF32 => Encoding.UTF32.GetBytes(value),
            TextEncode.Unicode => Encoding.Unicode.GetBytes(value),
            TextEncode.Latin1 => Encoding.Latin1.GetBytes(value),
            _ => Encoding.UTF8.GetBytes(value),
        };
    }

    /// <summary>
    /// Converts a byte array to a string using the specified text encoding.
    /// </summary>
    /// <param name="value">The byte array to convert.</param>
    /// <param name="encode">The text encoding to use. Default is UTF-8.</param>
    /// <returns>A string representation of the byte array.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input byte array is null.</exception>
    public static string ByteArrayToString(this byte[] value, TextEncode encode = TextEncode.UTF8)
    {
        ArgumentNullException.ThrowIfNull(value);

        return encode switch
        {
            TextEncode.ASCII => Encoding.ASCII.GetString(value),
            TextEncode.UTF8 => Encoding.UTF8.GetString(value),
            TextEncode.UTF16 => Encoding.BigEndianUnicode.GetString(value),
            TextEncode.UTF32 => Encoding.UTF32.GetString(value),
            TextEncode.Unicode => Encoding.Unicode.GetString(value),
            TextEncode.Latin1 => Encoding.Latin1.GetString(value),
            _ => Encoding.UTF8.GetString(value),
        };
    }

    /// <summary>
    /// Converts an integer value to an enumeration of the specified type.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
    /// <param name="value">The integer value to convert.</param>
    /// <returns>The corresponding enumeration value.</returns>
    /// <exception cref="ArgumentException">Thrown when the value is not defined in the enumeration.</exception>
    public static TEnum ConvertToEnum<TEnum>(this int value) where TEnum : Enum
    {
        if (Enum.IsDefined(typeof(TEnum), value))
            return (TEnum)Enum.ToObject(typeof(TEnum), value);

        throw new ArgumentException($"O valor {value} não é válido para o enumerador {typeof(TEnum).FullName}");
    }

    /// <summary>
    /// Converts an integer value to an enumeration of the specified type, or returns the default value if the conversion is not possible.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
    /// <param name="value">The integer value to convert.</param>
    /// <returns>The corresponding enumeration value, or the default value if the conversion is not possible.</returns>
    /// <exception cref="ArgumentException">Thrown when the enumeration has no defined values.</exception>
    public static TEnum ConvertToEnumOrDefault<TEnum>(this int value) where TEnum : Enum
    {
        if (Enum.IsDefined(typeof(TEnum), value))
            return (TEnum)Enum.ToObject(typeof(TEnum), value);

        TEnum[] EnumValues = (TEnum[])Enum.GetValues(typeof(TEnum));
        if (EnumValues.Length > 0)
            return EnumValues[0];

        throw new ArgumentException($"O valor {value} não é válido para o enumerador {typeof(TEnum).FullName}");
    }

    #endregion Generic Conversions

    #region DateTime Functions 

    /// <summary>
    /// Checks if the expiry date has passed.
    /// </summary>
    /// <param name="expiryDate">The expiry date to check.</param>
    /// <returns>True if the expiry date has passed; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTime expiryDate = new DateTime(2023, 6, 1);
    /// bool hasPassed = expiryDate.HasExpiryDatePassed(); // Returns true if the current date is after June 1, 2023.
    /// </code>
    /// </example>
    public static bool HasExpiryDatePassed(this DateTime expiryDate) => expiryDate < DateTime.Now;

    /// <summary>
    /// Checks if the expiry date has passed, ignoring the time of day.
    /// </summary>
    /// <param name="expiryDate">The expiry date to check.</param>
    /// <returns>True if the expiry date has passed, ignoring the time of day; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTime expiryDate = new DateTime(2023, 6, 1);
    /// bool hasPassed = expiryDate.HasExpiryDatePassedIgnoringTime(); // Returns true if the current date is after June 1, 2023, ignoring the time of day.
    /// </code>
    /// </example>
    public static bool HasExpiryDatePassedIgnoringTime(this DateTime expiryDate) => expiryDate.Date < DateTime.Now.Date;

    /// <summary>
    /// Checks if a date is within a specified range, including the start and end dates.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range.</param>
    /// <returns>True if the date is within the specified range; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 6, 15);
    /// DateTime start = new DateTime(2023, 6, 1);
    /// DateTime end = new DateTime(2023, 6, 30);
    /// bool isWithinRange = date.IsDateTimeWithinRange(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023.
    /// </code>
    /// </example>
    public static bool IsDateTimeWithinRange(this DateTime date, DateTime start, DateTime end) => (date >= start) && (date <= end);

    /// <summary>
    /// Checks if a date is within a specified range, including the start and end dates, ignoring the time of day.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range.</param>
    /// <returns>True if the date is within the specified range, ignoring the time of day; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 6, 15);
    /// DateTime start = new DateTime(2023, 6, 1);
    /// DateTime end = new DateTime(2023, 6, 30);
    /// bool isWithinRange = date.IsDateTimeWithinRangeIgnoringTime(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023, ignoring the time of day.
    /// </code>
    /// </example>
    public static bool IsDateTimeWithinRangeIgnoringTime(this DateTime date, DateTime start, DateTime end) => (date.Date >= start.Date) && (date.Date <= end.Date);

    /// <summary>
    /// Checks if the expiry date (DateTimeOffset) has passed.
    /// </summary>
    /// <param name="expiryDate">The expiry date to check.</param>
    /// <returns>True if the expiry date has passed; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTimeOffset expiryDate = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero);
    /// bool hasPassed = expiryDate.HasExpiryDateOffsetPassed(); // Returns true if the current date is after June 1, 2023.
    /// </code>
    /// </example>
    public static bool HasExpiryDateOffsetPassed(this DateTimeOffset expiryDate) => expiryDate < DateTimeOffset.UtcNow;

    /// <summary>
    /// Checks if the expiry date (DateTimeOffset) has passed, ignoring the time of day.
    /// </summary>
    /// <param name="expiryDate">The expiry date to check.</param>
    /// <returns>True if the expiry date has passed, ignoring the time of day; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTimeOffset expiryDate = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero);
    /// bool hasPassed = expiryDate.HasExpiryDateOffsetPassedIgnoringTime(); // Returns true if the current date is after June 1, 2023, ignoring the time of day.
    /// </code>
    /// </example>
    public static bool HasExpiryDateOffsetPassedIgnoringTime(this DateTimeOffset expiryDate) => expiryDate.UtcDateTime.Date < DateTimeOffset.UtcNow.UtcDateTime.Date;

    /// <summary>
    /// Checks if a date (DateTimeOffset) is within a specified range, including the start and end dates.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range.</param>
    /// <returns>True if the date is within the specified range; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 6, 15, 0, 0, 0, TimeSpan.Zero);
    /// DateTimeOffset start = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero);
    /// DateTimeOffset end = new DateTimeOffset(2023, 6, 30, 0, 0, 0, TimeSpan.Zero);
    /// bool isWithinRange = date.IsDateOffsetWithinRange(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023.
    /// </code>
    /// </example>
    public static bool IsDateOffsetWithinRange(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end) => (date >= start) && (date <= end);

    /// <summary>
    /// Checks if a date (DateTimeOffset) is within a specified range, including the start and end dates, ignoring the time of day.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <param name="start">The start date of the range.</param>
    /// <param name="end">The end date of the range.</param>
    /// <returns>True if the date is within the specified range, ignoring the time of day; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 6, 15, 0, 0, 0, TimeSpan.Zero);
    /// DateTimeOffset start = new DateTimeOffset(2023, 6, 1, 0, 0, 0, TimeSpan.Zero);
    /// DateTimeOffset end = new DateTimeOffset(2023, 6, 30, 0, 0, 0, TimeSpan.Zero);
    /// bool isWithinRange = date.IsDateOffsetWithinRangeIgnoringTime(start, end); // Returns true if the date is between June 1, 2023, and June 30, 2023, ignoring the time of day.
    /// </code>
    /// </example>
    public static bool IsDateOffsetWithinRangeIgnoringTime(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end) => (date.UtcDateTime.Date >= start.UtcDateTime.Date) && (date.UtcDateTime.Date <= end.UtcDateTime.Date);

    /// <summary>
    /// Converts a DateTime to a string formatted as "yyyyMMddHHmmss" or "yyyyMMdd-HHmmss".
    /// </summary>
    /// <param name="date">The DateTime to format.</param>
    /// <param name="separedTime">If true, separates the date and time with a hyphen; otherwise, concatenates them.</param>
    /// <returns>A string representation of the DateTime.</returns>
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 6, 15, 14, 30, 0);
    /// string formattedDate = date.ToName(); // Returns "20230615143000".
    /// string formattedDateWithHyphen = date.ToName(true); // Returns "20230615-143000".
    /// </code>
    /// </example>
    public static string ToName(this DateTime date, bool separedTime = false) => separedTime ? date.ToString("yyyyMMdd-HHmmss") : date.ToString("yyyyMMddHHmmss");

    /// <summary>
    /// Converts a DateTimeOffset to a string formatted as "yyyyMMddHHmmss" or "yyyyMMdd-HHmmss".
    /// </summary>
    /// <param name="date">The DateTimeOffset to format.</param>
    /// <param name="separedTime">If true, separates the date and time with a hyphen; otherwise, concatenates them.</param>
    /// <returns>A string representation of the DateTimeOffset.</returns>
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 6, 15, 14, 30, 0, TimeSpan.Zero);
    /// string formattedDate = date.ToName(); // Returns "20230615143000".
    /// string formattedDateWithHyphen = date.ToName(true); // Returns "20230615-143000".
    /// </code>
    /// </example>
    public static string ToName(this DateTimeOffset date, bool separedTime = false) => separedTime ? date.ToString("yyyyMMdd-HHmmss") : date.ToString("yyyyMMddHHmmss");

    #endregion DateTime Functions 
}
