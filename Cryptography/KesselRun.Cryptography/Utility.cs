using System;
using System.Security.Cryptography;
using System.Text;

namespace KesselRun.Cryptography
{
    public class Utility
    {
        private const int SaltSize = 128/8; // 128 bits

        internal static byte[] GenerateSaltInternal(int byteLength = SaltSize)
        {
            var buf = new byte[byteLength];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buf);
            }
            return buf;
        }

        public static string GenerateSalt(int byteLength = SaltSize)
        {
            return Convert.ToBase64String(GenerateSaltInternal(byteLength));
        }


        public static string GenerateRandomString(int size)
        {
            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();

            byte[] randomBytes = new byte[size];

            rngCryptoServiceProvider.GetNonZeroBytes(randomBytes);


            var builder = new StringBuilder(size);
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(52*NextDouble(rngCryptoServiceProvider) + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        internal static double NextDouble(RandomNumberGenerator rngCryptoServiceProvider)
        {
            byte[] buffer = new byte[4];

            rngCryptoServiceProvider.GetBytes(buffer);

            int result = BitConverter.ToInt32(buffer, 0);

            return new Random(result).NextDouble();
        }

        //public static void GenRandomBytes(byte[] buffer)
        //{
        //    //Use cryptographically strong random number generator, 
        //    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        //    //Get enough random bytes to fill the given buffer
        //    rng.GetBytes(buffer);
        //}

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        //private static bool ByteArraysEqual(byte[] a, byte[] b)
        //{
        //    if (ReferenceEquals(a, b))
        //    {
        //        return true;
        //    }

        //    if (a == null || b == null || a.Length != b.Length)
        //    {
        //        return false;
        //    }

        //    bool areSame = true;
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        areSame &= (a[i] == b[i]);
        //    }
        //    return areSame;
        //}
    }
}
