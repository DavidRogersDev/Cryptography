using System;
using System.Security.Cryptography;
using System.Text;
using KesselRun.Cryptography.Enums;

namespace KesselRun.Cryptography
{
    public class Asymmetric
    {
        public string HashString(string text, string salt, string entropy, HashType hashType = HashType.Sha512)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Parameter cannot be null or comprise soley of white space", "text");
            if (string.IsNullOrWhiteSpace(salt)) throw new ArgumentException("Parameter cannot be null or comprise of white space", "salt");
            if (ReferenceEquals(entropy, null)) throw new ArgumentNullException("entropy");

            switch (hashType)
            {
                case HashType.Sha512: 
                    var sha512Managed = new SHA512Managed();
                    byte[] hashBytes = sha512Managed.ComputeHash(Encoding.UTF8.GetBytes(text + salt + entropy));
                    return Convert.ToBase64String(hashBytes);
                default: throw new NotSupportedException(string.Format("The following hash type is not supported: {0}", hashType));
            }
        }
    }
}
