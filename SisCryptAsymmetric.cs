using SisCrypt.Backends;

namespace SisCrypt {
public static partial class SisCrypt {
    public static AsymmetricEncryptResult AsymmetricEncrypt(byte[] publicKey, byte[] data, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).AsymmetricEncryptFor(publicKey, data);

    public static AsymmetricEncryptResult AsymmetricEncrypt(byte[] publicKey, string data, int version = SISCRYPT_LATEST_VERSION)
        => AsymmetricEncrypt(publicKey, StringToBytes(data, version), version);

    public static AsymmetricSignResult AsymmetricSign(Secret<byte[]> privateKey, byte[] data, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).AsymmetricSign(privateKey, data);

    public static AsymmetricSignResult AsymmetricSign(Secret<byte[]> privateKey, string data, int version = SISCRYPT_LATEST_VERSION)
        => AsymmetricSign(privateKey, StringToBytes(data, version), version);

    public static byte[] AsymmetricDecrypt(Secret<byte[]> privateKey, AsymmetricEncryptResult data, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).AsymmetricDecrypt(privateKey, data);

    public static byte[]? AsymmetricVerify(byte[] publicKey, AsymmetricSignResult data, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).AsymmetricVerify(publicKey, data);
}
}
