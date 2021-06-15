﻿using SisCrypto.Backends;

namespace SisCrypto {
public static partial class SisCrypto {
    public static AsymmetricEncryptResult AsymmetricEncrypt(byte[] publicKey, byte[] data, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).AsymmetricEncryptFor(publicKey, data);

    public static AsymmetricEncryptResult AsymmetricEncrypt(byte[] publicKey, string data, int version = SISCRYPTO_LATEST_VERSION)
        => AsymmetricEncrypt(publicKey, StringToBytes(data, version), version);

    public static AsymmetricSignResult AsymmetricSign(Secret<byte[]> privateKey, byte[] data, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).AsymmetricSign(privateKey, data);

    public static AsymmetricSignResult AsymmetricSign(Secret<byte[]> privateKey, string data, int version = SISCRYPTO_LATEST_VERSION)
        => AsymmetricSign(privateKey, StringToBytes(data, version), version);

    public static byte[] AsymmetricDecrypt(Secret<byte[]> privateKey, AsymmetricEncryptResult data, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).AsymmetricDecrypt(privateKey, data);

    public static byte[]? AsymmetricVerify(byte[] publicKey, AsymmetricSignResult data, int version = SISCRYPTO_LATEST_VERSION)
        => SisCryptoBackend.GetVersion(version).AsymmetricVerify(publicKey, data);
}
}
