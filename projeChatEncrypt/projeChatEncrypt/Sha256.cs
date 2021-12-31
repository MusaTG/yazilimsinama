using System.Security.Cryptography;
using System.Text;

namespace ChatEncrypt
{
    public class Sha256
    {
        public string Sha256_Encrypting(string password)
        {
            SHA256 sha = SHA256.Create();
            byte[] valueBytes = Encoding.UTF8.GetBytes(password);
            byte[] shaBytes = sha.ComputeHash(valueBytes);
            return HashToByte(shaBytes);
        }

        private string HashToByte(byte[] shaBytes)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte item in shaBytes)
            {
                result.Append($"{item:x2}");
            }
            return result.ToString();
        }
    }
}