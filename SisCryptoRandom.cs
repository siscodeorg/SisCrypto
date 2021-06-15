using System.Security.Cryptography;

namespace SisCrypto {
public static class SisCryptoRandom {
    public static byte[] GetSecureBytes(int len) {
        byte[] bytes = new byte[len];
        using var service = new RNGCryptoServiceProvider();
        service.GetBytes(bytes);
        return bytes;
    }
}
}
