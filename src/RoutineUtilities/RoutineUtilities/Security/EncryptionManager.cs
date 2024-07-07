namespace RoutineUtilities.Security;

/// <summary>
/// Provides methods for encryption and decryption using AES, and for hashing using HMAC-SHA256, HMAC-SHA3-256, and SHA256.
/// </summary>
public class EncryptionManager : IDisposable
{
    #region Construtor

    private readonly byte[] hashKey;
    private readonly byte[] iV;

    /// <summary>
    /// Initializes a new instance of the <see cref="EncryptionManager"/> class with the specified password and optional salt.
    /// </summary>
    /// <param name="password">The password used to generate the hash key and IV.</param>
    /// <param name="salt">An optional salt value. If not provided, the first 16 bytes of the hash key are used as the salt.</param>
    /// <exception cref="ArgumentException">Thrown when the password is null or empty.</exception>
    public EncryptionManager(string password, string? salt = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(password, nameof(password));

        try
        {
            hashKey = SHA256.HashData(password.StringToByteArray());
            salt ??= hashKey[..16].ByteArrayToString();
            iV = SHA256.HashData(salt.StringToByteArray())[16..];
        }
        catch
        {
            throw;
        }
    }

    #endregion Construtor

    #region Disposable

    /// <summary>
    /// Finalizes an instance of the <see cref="EncryptionManager"/> class.
    /// </summary>
    ~EncryptionManager() => Dispose();

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="EncryptionManager"/> class.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    #endregion Disposable

    #region AES

    /// <summary>
    /// Encrypts the specified data using AES encryption.
    /// </summary>
    /// <param name="data">The data to encrypt.</param>
    /// <returns>A byte array containing the encrypted data.</returns>
    public byte[] EncryptAES(byte[] data)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = hashKey;
            aesAlg.IV = iV;

            using (MemoryStream msEncrypt = new())
            {
                using (CryptoStream csEncrypt = new(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    csEncrypt.Write(data, 0, data.Length);
                    csEncrypt.FlushFinalBlock();
                    return msEncrypt.ToArray();
                }
            }
        }
    }

    /// <summary>
    /// Decrypts the specified data using AES decryption.
    /// </summary>
    /// <param name="encryptedData">The encrypted data to decrypt.</param>
    /// <returns>A byte array containing the decrypted data.</returns>
    public byte[] DecryptAES(byte[] encryptedData)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = hashKey;
            aesAlg.IV = iV;

            using (MemoryStream msDecrypt = new(encryptedData))
            {
                using (CryptoStream csDecrypt = new(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (MemoryStream ms = new())
                    {
                        csDecrypt.CopyTo(ms);
                        return ms.ToArray();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Encrypts the specified text using AES encryption.
    /// </summary>
    /// <param name="text">The text to encrypt.</param>
    /// <returns>A string containing the encrypted text, encoded in Base64.</returns>
    public string EncryptAESText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = hashKey;
            aesAlg.IV = iV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new())
            {
                using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new(csEncrypt))
                        swEncrypt.Write(text);
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    /// <summary>
    /// Decrypts the specified text using AES decryption.
    /// </summary>
    /// <param name="encryptedText">The encrypted text to decrypt, encoded in Base64.</param>
    /// <returns>A string containing the decrypted text.</returns>
    public string DecryptAESText(string encryptedText)
    {
        if (string.IsNullOrEmpty(encryptedText))
            return string.Empty;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = hashKey;
            aesAlg.IV = iV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new(Convert.FromBase64String(encryptedText)))
            {
                using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new(csDecrypt))
                        return srDecrypt.ReadToEnd();
                }
            }
        }
    }

    #endregion AES

    #region HMAC-SHA256

    /// <summary>
    /// Computes a HMAC-SHA256 hash for the specified text.
    /// </summary>
    /// <param name="texto">The text to hash.</param>
    /// <returns>A string containing the HMAC-SHA256 hash, formatted as a hexadecimal string.</returns>
    public string CriptografarHMACSHA256(string texto)
    {
        using (HMACSHA256 hmac = new(hashKey))
        {
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(texto));

            StringBuilder builder = new();
            foreach (byte b in hashBytes)
                builder.AppendFormat("{0:x2}", b);

            return builder.ToString();
        }
    }

    /// <summary>
    /// Computes a HMAC-SHA3-256 hash for the specified text.
    /// </summary>
    /// <param name="texto">The text to hash.</param>
    /// <returns>A string containing the HMAC-SHA3-256 hash, formatted as a hexadecimal string.</returns>
    public string CriptografarHMACSHA3_256(string texto)
    {
        using (HMACSHA3_256 hmac = new(hashKey))
        {
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(texto));

            StringBuilder builder = new();
            foreach (byte b in hashBytes)
                builder.AppendFormat("{0:x2}", b);

            return builder.ToString();
        }
    }

    #endregion HMAC-SHA256

    #region SHA256

    /// <summary>
    /// Computes a SHA256 hash for the specified text.
    /// </summary>
    /// <param name="texto">The text to hash.</param>
    /// <returns>A string containing the SHA256 hash, formatted as a hexadecimal string.</returns>
    public static string CriptografarSHA256(string texto) => SHA256.HashData(texto.StringToByteArray()).ByteArrayToString();

    #endregion SHA256
}
