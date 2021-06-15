namespace SisCrypto {
public static partial class SisCrypto {
    public const int SISCRYPTO_LATEST_VERSION = -1;

    public static SymmetricEncryptResult SymmetricEncryptWithPassword(
        Secret<string> password, string data,
        int version = SISCRYPTO_LATEST_VERSION
    ) {
        var salt = SisCryptoRandom.GetSecureBytes(16);
        var keyResult = DeriveKey(password, salt, version);
        var encryptResult = SymmetricEncrypt(keyResult.Key, salt, data, version);
        return encryptResult;
    }

    public static string SymmetricDecryptWithPassword(Secret<string> password, SymmetricEncryptResult data) {
        var keyResult = DeriveKey(password, data.Salt, data.Version);
        var decryptResult = SymmetricDecrypt(keyResult.Key, data);
        return BytesToString(decryptResult, data.Version)!;
    }
}
}
