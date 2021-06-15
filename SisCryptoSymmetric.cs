using SisCrypto.Backends;

namespace SisCrypto {
public static partial class SisCrypto {
    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, byte[] data, int version = SISCRYPTO_LATEST_VERSION) {
        return SisCryptoBackend.GetVersion(version).SymmetricEncrypt(key, salt, data);
    }

    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] data, int version = SISCRYPTO_LATEST_VERSION)
        => SymmetricEncrypt(key, SisCryptoRandom.GetSecureBytes(16), data, version);

    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, string data, int version = SISCRYPTO_LATEST_VERSION)
        => SymmetricEncrypt(key, StringToBytes(data, version), version);

    public static SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, string data, int version = SISCRYPTO_LATEST_VERSION)
        => SymmetricEncrypt(key, salt, StringToBytes(data, version), version);

    public static byte[] SymmetricDecrypt(Secret<byte[]> key, SymmetricEncryptResult data) {
        return SisCryptoBackend.GetVersion(data.Version).SymmetricDecrypt(key, data);
    }
}
}
