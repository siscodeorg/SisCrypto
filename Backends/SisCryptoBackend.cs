using System;

namespace SisCrypto.Backends {
public interface SisCryptoBackend {
    public int Version { get; }

    public DerivedKeyResult DeriveKey(Secret<byte[]> passcode, byte[] salt);

    public SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, byte[] data);

    public byte[] SymmetricDecrypt(Secret<byte[]> key, SymmetricEncryptResult data);

    public KeypairResult GenerateKeypair(byte[] source);

    public AsymmetricEncryptResult AsymmetricEncryptFor(byte[] publicKey, byte[] data);

    public byte[] AsymmetricDecrypt(Secret<byte[]> privateKey, AsymmetricEncryptResult data);

    public AsymmetricSignResult AsymmetricSign(Secret<byte[]> privateKey, byte[] data);

    public byte[]? AsymmetricVerify(byte[] publicKey, AsymmetricSignResult data);

    public byte[] SecureHash(byte[] data);

    public byte[] StringToBytes(string str);

    public string? BytesToString(byte[] str);

    public static SisCryptoBackend GetVersion(int version) {
        return version switch {
            1 => SisCryptoBackend_v1.INSTANCE,
            _ => throw new NotSupportedException(
                $"SisCrypto backend version ${version} does not exist. Are you out of date?"
            )
        };
    }
}
}
