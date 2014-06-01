using System;
using System.Security.Cryptography;
using System.Text;
using KesselRun.Cryptography.Enums;

namespace KesselRun.Cryptography
{
    public class Asymmetric
    {
        public string HashString(string text, string salt, string entropy, HashType hashType = HashType.SHA512)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Parameter cannot be null or comprise soley of white space", "text");
            if (string.IsNullOrWhiteSpace(salt))
                throw new ArgumentException("Parameter cannot be null or comprise of white space", "salt");
            if (ReferenceEquals(entropy, null)) throw new ArgumentNullException("entropy");

            byte[] hashBytes;

            switch (hashType)
            {
                case HashType.SHA1:
                    var sha1Managed = new SHA1Managed();
                    hashBytes = sha1Managed.ComputeHash(Encoding.UTF8.GetBytes(text + salt + entropy));
                    return Convert.ToBase64String(hashBytes);
                case HashType.SHA256:
                    var sha256Managed = new SHA256Managed();
                    hashBytes = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(text + salt + entropy));
                    return Convert.ToBase64String(hashBytes);
                case HashType.SHA384:
                    var sha384Managed = new SHA384Managed();
                    hashBytes = sha384Managed.ComputeHash(Encoding.UTF8.GetBytes(text + salt + entropy));
                    return Convert.ToBase64String(hashBytes);
                case HashType.SHA512:
                    var sha512Managed = new SHA512Managed();
                    hashBytes = sha512Managed.ComputeHash(Encoding.UTF8.GetBytes(text + salt + entropy));
                    return Convert.ToBase64String(hashBytes);
                default:
                    throw new NotSupportedException(string.Format("The following hash type is not supported: {0}",
                        hashType));
            }
        }
    }
}
