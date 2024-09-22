namespace TriviaSecurityApi.Services
{
    public interface IEncryptionService
    {
        string AESEncryptText(string input, string password);

        string AESDecryptText(string input, string password);

        byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes);

        byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes);

        string ComputeSha256Hash(string input);
    }
}
