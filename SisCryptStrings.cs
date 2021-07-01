using SisCrypt.Backends;

namespace SisCrypt {
public static partial class SisCrypt {
    public static byte[] StringToBytes(string str, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).StringToBytes(str);

    public static string? BytesToString(byte[] bytes, int version = SISCRYPT_LATEST_VERSION)
        => SisCryptBackend.GetVersion(version).BytesToString(bytes);
}
}
