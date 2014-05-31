using System;
using System.Security.Cryptography;
using System.Text;

namespace KesselRun.Cryptography
{
    public class Symmetric
    {
        /// <summary>
        /// Encrypt a string using RijndaelManaged.
        /// </summary>
        public string EncryptString(string password, string salt, string textToEncrypt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password", string.Format("The {0} parameter has to be a non-empty string.", password));

            if (ReferenceEquals(salt, null))
                throw new ArgumentNullException("salt", string.Format("The {0} parameter has to be a non-empty string.", salt));

            if (string.IsNullOrWhiteSpace(textToEncrypt))
                throw new ArgumentNullException("textToEncrypt", string.Format("The {0} parameter has to be a non-empty string.", textToEncrypt));


            RijndaelManaged cipher = SetupCipher(password, salt);

            ICryptoTransform encryptor = cipher.CreateEncryptor();

            byte[] plaintext = Encoding.UTF8.GetBytes(textToEncrypt.Trim());
            byte[] cipherText = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        /// Decrypt a string using RijndaelManaged.
        /// </summary>
        public string DecryptString(string password, string salt, string textToDecrypt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password", string.Format("The {0} parameter has to be a non-empty string.", password));

            if (ReferenceEquals(salt, null))
                throw new ArgumentNullException("salt", string.Format("The {0} parameter has to be a non-empty string.", salt));

            if (string.IsNullOrWhiteSpace(textToDecrypt))
                throw new ArgumentNullException("textToDecrypt", string.Format("The {0} parameter has to be a non-empty string.", textToDecrypt));

            RijndaelManaged cipher = SetupCipher(password, salt);

            //Create the decryptor, convert from base64 to bytes, decrypt
            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(textToDecrypt);
            byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

            return Encoding.UTF8.GetString(plainText);
        }

        /// <summary>
        /// Creates the RijndaelManaged cipher.
        /// </summary>
        public RijndaelManaged SetupCipher(string password, string salt)
        {
            var cipher = new RijndaelManaged();

            cipher.KeySize = 256;
            cipher.BlockSize = 256;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;

            Rfc2898DeriveBytes pkey = GetPasswordKey(password, salt);
            cipher.Key = pkey.GetBytes(cipher.KeySize / 8); //  key size of 265 / 8 = 32 byte array.
            cipher.IV = pkey.GetBytes(cipher.BlockSize / 8); //  key size of 265 / 8 = 32 byte array.

            return cipher;
        }

        /// <summary>
        /// Gets the Rfc2898DeriveBytes key using the salt and the text password.
        /// </summary>
        private Rfc2898DeriveBytes GetPasswordKey(string password, string salt)
        {
            byte[] saltInBytes = Encoding.UTF8.GetBytes(salt);
            var passwordKey = new Rfc2898DeriveBytes(password, saltInBytes);
            return passwordKey;
        }
    }
}
