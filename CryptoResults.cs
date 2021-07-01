namespace SisCrypt {
/**
 * A marker class to indicate that this value is a secret and should be stored securely.
 *
 * Any non-Secret values returned by SisCrypt may be made public without harming security
 *   (with the exception of decrypted results, which should be handled according to application logic.)
 * Any secret value should be stored securely and never made public.
 */
public record Secret<T>(T getSecret);

/**
 * Holds the results of encrypting data with a symmetric algorithm such as AES. In order to
 * decrypt this, you must possess the key that was originally used to encrypt it. This key should
 * be kept secret, but the data in the SymmetricResult itself can safely be made public.
 */
public record SymmetricEncryptResult(byte[] Encrypted, byte[] Salt, int Version);

/**
 * Holds the results of encrypting data with a password. This is simply a common combination of
 * Key Derivation and Symmetric Encryption. In order to decrypt the data, you must possess the
 * password that was originally used to encrypt it. This password should be kept secret, but
 * the data in PasswordEncryptedResult can safely be made public.
 */
public record PasswordEncryptResult(byte[] Data, byte[] KeySalt, byte[] EncryptSalt, int Version);

/**
 * Holds the results of encrypting data with an asymmetric algorithm such as RSA. This data is encrypted
 * so that only a person who holds the private key that matches the public key originally used to
 * create it can decrypt and read it. Never share the private key that can read it, but this data itself
 * can safely be made public.
 */
public record AsymmetricEncryptResult(byte[] Encrypted, int Version);

/**
 * Holds the results of signing the data that was passed in. This allows one to prove that they own
 * the private key that is associated with the public key used to sign the data. This can be used
 * for identity verification. Unlike encryption, anyone can read the data which is contained here
 * simply by applying the public key. This simply guarantees that it was created with the corresponding
 * private key. Do not sign data that you do not want others to be able to read, and never share the private
 * key that was used to sign this data.
 */
public record AsymmetricSignResult(byte[] Signed, byte[] PublicKey, byte[] Hash, int Version);

/**
 * Holds the results of applying a cryptographic transformation to a password. This is a one-way
 * transformation that cannot be reversed. This key will not allow the password that was used to create
 * it to be discovered. However, this key should be kept secret and treated just as securely as the original
 * password, as it is often used in later steps of symmetric encryption or for other secure purposes.
 */
public record DerivedKeyResult(Secret<byte[]> Key, byte[] Salt, int Version);

/**
 * Holds a pair of public and private keys suitable for asymmetric encryption. You should never share
 * your private key, as it can be used to read messages intended only for you or to impersonate you.
 * However, you can and should share your public key. your public key can be used to send messages that
 * only you can read, or to prove that a message was sent by you and not an impostor.
 */
public record KeypairResult(byte[] Public, Secret<byte[]> Private, int Version);
}
