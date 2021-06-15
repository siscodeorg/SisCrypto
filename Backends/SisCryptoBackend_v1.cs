using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SisCrypto.Backends {
internal class SisCryptoBackend_v1 : SisCryptoBackend {
    public static readonly SisCryptoBackend_v1 INSTANCE = new();

    public int Version => 1;

    public DerivedKeyResult DeriveKey(Secret<byte[]> passcode, byte[] salt) {
        using var pbkdf2 = new Rfc2898DeriveBytes(passcode.getSecret, salt, 25000);
        return new DerivedKeyResult(new Secret<byte[]>(pbkdf2.GetBytes(32)), salt, Version);
    }

    public SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, byte[] data) {
        throw new System.NotImplementedException();
    }

    public byte[] SymmetricDecrypt(Secret<byte[]> key, SymmetricEncryptResult data) {
        throw new System.NotImplementedException();
    }

    public KeypairResult GenerateKeypair(byte[] source) {
        throw new System.NotImplementedException();
    }

    public AsymmetricEncryptResult AsymmetricEncryptFor(byte[] publicKey, byte[] data) {
        throw new System.NotImplementedException();
    }

    public byte[] AsymmetricDecrypt(Secret<byte[]> privateKey, AsymmetricEncryptResult data) {
        throw new System.NotImplementedException();
    }

    public AsymmetricSignResult AsymmetricSign(Secret<byte[]> privateKey, byte[] data) {
        throw new System.NotImplementedException();
    }

    public byte[]? AsymmetricVerify(byte[] publicKey, AsymmetricSignResult data) {
        throw new System.NotImplementedException();
    }

    public byte[] StringToBytes(string str) {
        return Encoding.UTF8.GetBytes(str);
    }

    public string? BytesToString(byte[] bytes) {
        return Encoding.UTF8.GetString(bytes);
    }
}
}
