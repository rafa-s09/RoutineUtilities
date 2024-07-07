# EncryptionManager Class

>Provides methods for encryption and decryption using AES, and for hashing using HMAC-SHA256, HMAC-SHA3-256, and SHA256.

## Constructor

### EncryptionManager

Initializes a new instance of the `EncryptionManager` class with the specified password and optional salt.
#### Parameters
- `string password`: The password used to generate the hash key and IV.
- `string? salt`: An optional salt value. If not provided, the first 16 bytes of the hash key are used as the salt.
#### Exceptions
- `ArgumentException`: Thrown when the password is null or empty.

## Methods

[[#AES Methods]]
	[[#EncryptAES]]
	[[#DecryptAES]]
	[[#EncryptAESText]]
	[[#DecryptAESText]]
[[#HMAC-SHA256 Methods]]
	[[#CriptografarHMACSHA256]]
	[[#CriptografarHMACSHA3_256]]
[[#SHA256 Method]]
	[[#CriptografarSHA256]]
[[#Disposable Method]]
	[[#Dispose]]

### AES Methods

#### EncryptAES

Encrypts the specified data using AES encryption.
##### Parameters
- `byte[] data`: The data to encrypt.
##### Returns
- `byte[]`: A byte array containing the encrypted data.

#### DecryptAES

Decrypts the specified data using AES decryption.
##### Parameters
- `byte[] encryptedData`: The encrypted data to decrypt.
##### Returns
- `byte[]`: A byte array containing the decrypted data.

#### EncryptAESText

Encrypts the specified text using AES encryption.
##### Parameters
- `string text`: The text to encrypt.
##### Returns
- `string`: A string containing the encrypted text, encoded in Base64.

#### DecryptAESText

Decrypts the specified text using AES decryption.
##### Parameters
- `string encryptedText`: The encrypted text to decrypt, encoded in Base64.
##### Returns
- `string`: A string containing the decrypted text.

### HMAC-SHA256 Methods

#### CriptografarHMACSHA256

Computes a HMAC-SHA256 hash for the specified text.
##### Parameters
- `string texto`: The text to hash.
##### Returns
- `string`: A string containing the HMAC-SHA256 hash, formatted as a hexadecimal string.

#### CriptografarHMACSHA3_256

Computes a HMAC-SHA3-256 hash for the specified text.
##### Parameters
- `string texto`: The text to hash.
##### Returns
- `string`: A string containing the HMAC-SHA3-256 hash, formatted as a hexadecimal string.

### SHA256 Method

#### CriptografarSHA256

Computes a SHA256 hash for the specified text.
##### Parameters
- `string texto`: The text to hash.
##### Returns
- `string`: A string containing the SHA256 hash, formatted as a hexadecimal string.

### Disposable Method

#### Dispose

Releases all resources used by the current instance of the `EncryptionManager` class.