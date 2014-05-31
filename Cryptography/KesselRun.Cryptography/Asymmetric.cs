using System;
using System.Security.Cryptography;
using System.Text;

namespace KesselRun.Cryptography
{
    public class Asymmetric
    {
        public string HashString(string text, string salt, string entropy)
        {
            var sha512Managed = new SHA512Managed();
            byte[] hashBytes = sha512Managed.ComputeHash(Encoding.UTF8.GetBytes(text + salt + entropy));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
