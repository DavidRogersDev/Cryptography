using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace KesselRun.Cryptography.Tests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void GenerateSalt_Creates_String()
        {
            string salt = Utility.GenerateSalt();

            Assert.IsInstanceOfType(salt, typeof(string));
        }

        [TestMethod]
        public void GenerateRandomStringGeneratesRandomString()
        {
            const int size = 34;

            string newRandomString = Utility.GenerateRandomString(size);

            Trace.WriteLine(newRandomString);

            Assert.IsTrue(newRandomString.Length == size);
        }
    }
}
