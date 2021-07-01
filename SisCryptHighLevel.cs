namespace SisCrypt {
public static partial class SisCrypt {
    public const int SISCRYPT_LATEST_VERSION = 1;

    public static PasswordEncryptResult PasswordEncrypt(
        Secret<string> password, string data,
        int version = SISCRYPT_LATEST_VERSION
    ) {
        var keyResult = DeriveKey(password, version);
        var encryptResult = SymmetricEncrypt(keyResult.Key, data, version);
        return new PasswordEncryptResult(
            encryptResult.Encrypted,
            keyResult.Salt,
            encryptResult.Salt,
            version
        );
    }

    public static string PasswordDecrypt(Secret<string> password, PasswordEncryptResult data) {
        var keyResult = DeriveKey(password, data.KeySalt, data.Version);
        var decryptResult = SymmetricDecrypt(
            keyResult.Key,
            new SymmetricEncryptResult(data.Data, data.EncryptSalt, data.Version)
        );
        return BytesToString(decryptResult, data.Version)!;
    }
}
}
