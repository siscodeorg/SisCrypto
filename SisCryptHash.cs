using SisCrypt.Backends;

namespace SisCrypt {
public static partial class SisCrypt {
    public static byte[] SecureHash(byte[] data, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).SecureHash(data);

    public static byte[] SecureHash(string data, int version = SISCRYPT_LATEST_VERSION)
        => SecureHash(StringToBytes(data, version), version);
}
}
