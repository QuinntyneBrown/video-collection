namespace VideoCollection.Security
{
    public interface IEncryptionService
    {
        string HashPassword(string password);
        string EncryptString(string plainText);
        string DecryptString(string cipherText);
        string EncryptUri(string plainText);
    }
}
