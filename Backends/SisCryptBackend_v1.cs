using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SisCrypt.Backends {
internal class SisCryptBackendV1 : SisCryptBackend {
    public static readonly SisCryptBackendV1 INSTANCE = new();

    public int Version => 1;

    public DerivedKeyResult DeriveKey(Secret<byte[]> passcode, byte[] salt) {
        using var pbkdf2 = new Rfc2898DeriveBytes(passcode.getSecret, salt, 25000);
        return new DerivedKeyResult(new Secret<byte[]>(pbkdf2.GetBytes(32)), salt, Version);
    }

    public SymmetricEncryptResult SymmetricEncrypt(Secret<byte[]> key, byte[] salt, byte[] data) {
        Aes encryptor = Aes.Create();
        encryptor.Key = key.getSecret;
        encryptor.IV = salt;
        using var memstream = new MemoryStream();
        using var cryptstream = new CryptoStream(memstream, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
        cryptstream.Write(data, 0, data.Length);
        cryptstream.FlushFinalBlock();
        byte[] encrypted = memstream.ToArray();
        return new SymmetricEncryptResult(encrypted, encryptor.IV, Version);
    }

    public byte[] SymmetricDecrypt(Secret<byte[]> key, SymmetricEncryptResult data) {
        Aes decryptor = Aes.Create();
        decryptor.Key = key.getSecret;
        decryptor.IV = data.Salt;
        using var memstream = new MemoryStream();
        using var cryptstream = new CryptoStream(memstream, decryptor.CreateDecryptor(), CryptoStreamMode.Write);
        cryptstream.Write(data.Encrypted, 0, data.Encrypted.Length);
        cryptstream.FlushFinalBlock();
        return memstream.ToArray();
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

    public byte[] SecureHash(byte[] data) {
        using var hasher = SHA256.Create();
        return hasher.ComputeHash(data);
    }

    public byte[] StringToBytes(string str) {
        return Encoding.UTF8.GetBytes(str);
    }

    public string? BytesToString(byte[] bytes) {
        return Encoding.UTF8.GetString(bytes);
    }
}
}
