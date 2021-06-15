namespace SisCrypto {
public static partial class SisCrypto {
    public const int SISCRYPTO_LATEST_VERSION = -1;

    public record PasswordEncryptResult(byte[] Data, byte[] KdfSalt, byte[] EncryptSalt, int Version);

    public static PasswordEncryptResult PasswordEncrypt(
        Secret<string> password, string data,
        int version = SISCRYPTO_LATEST_VERSION
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
        var keyResult = DeriveKey(password, data.KdfSalt, data.Version);
        var decryptResult = SymmetricDecrypt(
            keyResult.Key,
            new SymmetricEncryptResult(data.Data, data.EncryptSalt, data.Version)
        );
        return BytesToString(decryptResult, data.Version)!;
    }
}
}
