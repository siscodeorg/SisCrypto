using SisCrypto.Backends;

namespace SisCrypto {
public static partial class SisCrypto {
    public static byte[] SecureHash(byte[] data, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).SecureHash(data);

    public static byte[] SecureHash(string data, int version = SISCRYPTO_LATEST_VERSION)
        => SecureHash(StringToBytes(data, version), version);
}
}
