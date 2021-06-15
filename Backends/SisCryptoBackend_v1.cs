namespace SisCrypto.Backends {
internal class SisCryptoBackend_v1 : SisCryptoBackend {
    public static readonly SisCryptoBackend_v1 INSTANCE = new();

    public int Version => 1;

    public DerivedKeyResult DeriveKey(Secret<byte[]> passcode, byte[] salt) {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

    public string? BytesToString(byte[] str) {
        throw new System.NotImplementedException();
    }
}
}
