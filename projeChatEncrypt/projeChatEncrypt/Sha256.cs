using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeChatEncrypt
{
    public class Sha256
    {
        public string SHA_256_Encrypting(string key)
        {
            SHA256 sha = SHA256.Create();
            byte[] valueBytes = Encoding.UTF8.GetBytes(key);
            byte[] shaBytes = sha.ComputeHash(valueBytes);
            return HashToByte(shaBytes);
        }

        private string HashToByte(byte[] shaBytes)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte item in shaBytes)
            {
                result.Append(item.ToString("x2"));
            }
            return result.ToString();
        }
    }
}
