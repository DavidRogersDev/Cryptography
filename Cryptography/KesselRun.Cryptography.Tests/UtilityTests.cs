using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
