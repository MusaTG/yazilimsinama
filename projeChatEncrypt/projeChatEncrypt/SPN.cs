using System;
using System.Text;

namespace ChatEncrypt
{
    public class SPN
    {
        public string message, binaryMessage, password, binaryPassword, sBox = "";

        public SPN() { }

        public SPN(string password)
        {
            this.password = password;
            this.binaryPassword = this.StrToBin(this.password);
        }

        public SPN(string message, string password)
        {
            this.password = password;
            this.binaryPassword = this.StrToBin(this.password);
            this.message = message;
            this.binaryMessage = this.StrToBin(this.message);
        }

        public string StrToBin(string data)
        {
            string binary = "";

            for (int i = 0; i < data.Length; i++)
                binary += Convert.ToString(data[i], 2).PadLeft(8, '0');

            return binary;
        }

        public string BinToStr(string encodingText)
        {
            Encoding utf8Encoding = Encoding.UTF8;
            string binaryString = encodingText.Replace(" ", "");
            var binLengt = (int)(binaryString.Length / 8);
            var bytes = new byte[binaryString.Length / 8];

            for (var i = 0; i < binLengt; i++)
                bytes[i] = Convert.ToByte(binaryString.Substring(i * 8, 8), 2);

            string str = utf8Encoding.GetString(bytes);

            return str;
        }

        public string Xor(string text, string password)
        {
            string binaryXor = "";
            string txt = "";
            string pass = "";
            for (int i = 0; i < text.Length; i++)
            {
                txt += text[i].ToString();
                pass += password[i].ToString();
                int xor = Convert.ToInt32(text[i]) ^ Convert.ToInt32(password[i]);
                binaryXor += xor.ToString();
            }
            return binaryXor;
        }

        public string Substitution(string data)
        {
            string permutationData = "";
            permutationData += data[2];
            permutationData += data[8];
            permutationData += data[12];
            permutationData += data[5];
            permutationData += data[9];
            permutationData += data[0];
            permutationData += data[14];
            permutationData += data[4];
            permutationData += data[11];
            permutationData += data[1];
            permutationData += data[15];
            permutationData += data[6];
            permutationData += data[3];
            permutationData += data[10];
            permutationData += data[7];
            permutationData += data[13];

            return permutationData;
        }

        public string ReverseSubstitution(string data)
        {
            string reverseSubstitution = "";
            reverseSubstitution += data[5];
            reverseSubstitution += data[9];
            reverseSubstitution += data[0];
            reverseSubstitution += data[12];
            reverseSubstitution += data[7];
            reverseSubstitution += data[3];
            reverseSubstitution += data[11];
            reverseSubstitution += data[14];
            reverseSubstitution += data[1];
            reverseSubstitution += data[4];
            reverseSubstitution += data[13];
            reverseSubstitution += data[8];
            reverseSubstitution += data[2];
            reverseSubstitution += data[15];
            reverseSubstitution += data[6];
            reverseSubstitution += data[10];

            return reverseSubstitution;
        }


        public string Encryption()
        {
            string cipherText = "";
            for (int i = 0; i < this.binaryMessage.Length; i += 16)
            {
                string data = this.binaryMessage.Substring(i, 16);
                for (int j = 0; j < 64; j += 16)
                {
                    string xor = this.Xor(data, this.binaryPassword.Substring(j, 16));
                    if (j < 32)
                        sBox = this.Substitution(xor);
                    else
                        sBox = xor;
                    data = sBox;
                }
                cipherText += data;
            }
            return cipherText;
        }

        public string Decryption(string data)
        {
            string plainText = "";
            for (int i = 0; i < data.Length; i += 16)
            {
                string cipherText = data.Substring(i, 16);
                for (int j = 48; j >= 0; j -= 16)
                {
                    string xor = this.Xor(cipherText, this.binaryPassword.Substring(j, 16));
                    if (j == 48 || j == 0)
                        sBox = xor;
                    else
                        sBox = this.ReverseSubstitution(xor);
                    cipherText = sBox;
                }
                plainText += cipherText;
            }
            return this.BinToStr(plainText);
        }
    }
}