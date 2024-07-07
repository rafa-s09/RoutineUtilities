namespace RoutineUtilities.Security;

/// <summary>
/// Provides methods for generating random text, unique identifiers, and GUIDs.
/// </summary>
public static class Generator
{
    /// <summary>
    /// Generates a random string of the specified length, optionally including special characters.
    /// </summary>
    /// <param name="length">The length of the random string to generate.</param>
    /// <param name="includeSpecialCharacters">If true, includes special characters in the random string; otherwise, only alphanumeric characters are included.</param>
    /// <returns>A random string of the specified length.</returns>
    public static string RandomText(int length, bool includeSpecialCharacters = false)
    {
        const string caracteresNormais = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string caracteresEspeciais = "!@#$%^&*";
        string caracteres = includeSpecialCharacters ? (caracteresNormais + caracteresEspeciais) : caracteresNormais;

        StringBuilder sb = new();
        Random rnd = new();

        for (int i = 0; i < length; i++)
        {
            int indice = rnd.Next(caracteres.Length);
            sb.Append(caracteres[indice]);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Generates a unique identifier string in the format "XXX-XXXXX-XXXXX-XXXX".
    /// </summary>
    /// <returns>A unique identifier string.</returns>
    public static string Uid()
    {
        StringBuilder sb = new();
        sb.Append(RandomText(3));
        sb.Append('-');
        sb.Append(RandomText(5));
        sb.Append('-');
        sb.Append(RandomText(5));
        sb.Append('-');
        sb.Append(RandomText(4));

        return sb.ToString().ToUpper();
    }

    /// <summary>
    /// Generates a GUID (Globally Unique Identifier) string, optionally including special characters.
    /// </summary>
    /// <param name="includeSpecialCharacters">If true, includes hyphens in the GUID string; otherwise, returns a hyphen-less GUID string.</param>
    /// <returns>A GUID string.</returns>
    public static string DefaultGuid(bool includeSpecialCharacters = true)
    {
        Guid guid = Guid.NewGuid();
        return includeSpecialCharacters ? guid.ToString() : guid.ToString("N");
    }
}