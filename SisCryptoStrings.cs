using SisCrypto.Backends;

namespace SisCrypto {
public static partial class SisCrypto {
    public static byte[] StringToBytes(string str, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).StringToBytes(str);

    public static string? BytesToString(byte[] bytes, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).BytesToString(bytes);
}
}
