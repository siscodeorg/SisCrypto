using SisCrypt.Backends;

namespace SisCrypt {
public static partial class SisCrypt {
    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, byte[] data, int version = SISCRYPT_LATEST_VERSION) {
        return SisCryptBackend.GetVersion(version).SymmetricEncrypt(key, salt, data);
    }

    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] data, int version = SISCRYPT_LATEST_VERSION)
        => SymmetricEncrypt(key, SisCryptoRandom.GetSecureBytes(16), data, version);

    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, string data, int version = SISCRYPT_LATEST_VERSION)
        => SymmetricEncrypt(key, StringToBytes(data, version), version);

    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, string data, int version = SISCRYPT_LATEST_VERSION)
        => SymmetricEncrypt(key, salt, StringToBytes(data, version), version);

    public static byte[] SymmetricDecrypt(Secret<byte[]> key, SymmetricEncryptResult data) {
        return SisCryptBackend.GetVersion(data.Version).SymmetricDecrypt(key, data);
    }
}
}
