using ChatEncrypt;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        SPN spn = new SPN();
        Sha256 sha = new Sha256();

        [Test]
        public void ShaEncryption()
        {
            var result = sha.Sha256_Encrypting("musa");
            Assert.AreEqual("763a87e8ecd542b4690f0eb87ee2f7b2955ba3db89bda3350167e589b38653fe", result);
        }
        [Test]
        public void SpnEncryption()
        {
            spn.binaryPassword = spn.StrToBin("musamusa");
            spn.binaryMessage = spn.StrToBin("musa");
            var result = spn.Encryption();
            Assert.AreEqual("10010110011010101111011011000000", result);
        }
        [Test]
        public void SpnDecryption()
        {
            spn.binaryPassword = spn.StrToBin("musamusa");
            var result = spn.Decryption("10010110011010101111011011000000");
            Assert.AreEqual("musa", result);
        }
        [Test]
        public void ConvertingBinary()
        {
            var result = spn.StrToBin("musa");
            Assert.AreEqual("01101101011101010111001101100001", result);
        }
        [Test]
        public void ConvertingString()
        {
            var result = spn.BinToStr("01101101011101010111001101100001");
            Assert.AreEqual("musa", result);
        }
        [Test]
        public void XorDoor()
        {
            var result = spn.Xor("1101", "0011");
            Assert.AreEqual("1110", result);
        }
        [Test]
        public void Substitution()
        {
            var result = spn.Substitution("9472135806fabdec");
            Assert.AreEqual("70b369e1a4c52f8d", result);
        }
        [Test]
        public void RSubsitution()
        {
            var result = spn.ReverseSubstitution("70b369e1a4c52f8d");
            Assert.AreEqual("9472135806fabdec", result);
        }
    }
}