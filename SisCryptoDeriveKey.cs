using SisCrypto.Backends;

namespace SisCrypto {
public static partial class SisCrypto {
    public static DerivedKeyResult DeriveKey(Secret<byte[]> passcode, byte[] salt, int version = 1)
        => SisCryptoBackend.GetVersion(version).DeriveKey(passcode, salt);

    public static DerivedKeyResult DeriveKey(Secret<byte[]> passcode, int version = 1)
        => DeriveKey(passcode, SisCryptoRandom.GetSecureBytes(16), version);

    public static DerivedKeyResult DeriveKey(Secret<string> passphrase, int version = 1)
        => DeriveKey(new Secret<byte[]>(StringToBytes(passphrase.getSecret, version)), version);

    public static DerivedKeyResult DeriveKey(Secret<string> passphrase, byte[] salt, int version = 1)
        => DeriveKey(new Secret<byte[]>(StringToBytes(passphrase.getSecret, version)), salt, version);
}
}
