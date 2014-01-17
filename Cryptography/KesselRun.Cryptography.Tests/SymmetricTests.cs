using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KesselRun.Cryptography.Tests
{
    [TestClass]
    public class SymmetricTests
    {
        private static string password, salt, encryptThis;
        

        [ClassInitialize]
        public static void SetupTests(TestContext context)
        {
            password = "bvgfiSdfr4)";
            salt =  Utility.GenerateSalt();
            encryptThis = "Grim words to encrypt!";
        }

        [TestMethod]
        public void CryptoEncryptString_Encrypts_String()
        {
            //  Arrange
            Symmetric symmetric = new Symmetric();

            //  Act
            string encryptedString = symmetric.CryptoEncryptString(password, salt, encryptThis);

            //  Assert            
            Assert.IsInstanceOfType(encryptedString, typeof(string));
            Assert.AreNotEqual(encryptedString, encryptThis);

        }

        [TestMethod]
    [ExpectedException(typeof(ArgumentException),"Salt is not at least eight bytes.")]
        public void CryptoEncryptString_Throws_Error_When_Salt_Is_Empty_String() { 
            //  Arrange
            Symmetric symmetric = new Symmetric();
            salt = string.Empty;

            //  Act
            string encryptedString = symmetric.CryptoEncryptString(password, salt, encryptThis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The salt parameter cannot be null.")]
        public void CryptoEncryptString_Throws_Error_When_Salt_Is_Null()
        {
            //  Arrange
            Symmetric symmetric = new Symmetric();
            salt = null;

            //  Act
            string encryptedString = symmetric.CryptoEncryptString("bvgfiSdfr4)", salt, encryptThis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The password parameter has to be a non-empty string.")]
        public void CryptoEncryptString_Throws_Error_When_Password_Is_Empty_String()
        {
            //  Arrange
            Symmetric symmetric = new Symmetric();
            password = string.Empty;

            //  Act
            string encryptedString = symmetric.CryptoEncryptString(password, salt, encryptThis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The password parameter has to be a non-empty string.")]
        public void CryptoEncryptString_Throws_Error_When_Password_Is_Null()
        {
            //  Arrange
            Symmetric symmetric = new Symmetric();
            password = null;

            //  Act
            string encryptedString = symmetric.CryptoEncryptString(password, salt, encryptThis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The textToEncrypt parameter has to be a non-empty string.")]
        public void CryptoEncryptString_Throws_Error_When_TextToEncrypt_Is_Empty_String()
        {
            //  Arrange
            Symmetric symmetric = new Symmetric();
            encryptThis = string.Empty;

            //  Act
            string encryptedString = symmetric.CryptoEncryptString(password, salt, encryptThis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The textToEncrypt parameter has to be a non-empty string.")]
        public void CryptoEncryptString_Throws_Error_When_TextToEncrypt_Is_Null()
        {
            //  Arrange
            Symmetric symmetric = new Symmetric();
            encryptThis = null;

            //  Act
            string encryptedString = symmetric.CryptoEncryptString(password, salt, encryptThis);
        }
    }
}
