using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace KesselRun.Cryptography.Tests
{
    [TestClass]
    public class AsymmetricTests
    {
        [TestMethod]
        public void HashStringHashesString()
        {
            var asymmetric = new Asymmetric();

            var entropy = Utility.GenerateRandomString(20);

            var salt = Utility.GenerateSalt();
            var password = "MyDogHasFleas";

            var hash = asymmetric.HashString(password, salt, entropy);

            Trace.WriteLine(salt);
            Trace.WriteLine(entropy);
            Trace.WriteLine(hash);

            Assert.IsTrue(hash.Equals(asymmetric.HashString(password, salt, entropy), StringComparison.Ordinal));
        }
        
        [TestMethod]
        public void HashStringHashesStringWhereEntrpoyEmptyString()
        {
            var asymmetric = new Asymmetric();

            var entropy = string.Empty;

            var salt = Utility.GenerateSalt();
            var password = "MyDogHasFleas";

            var hash = asymmetric.HashString(password, salt, entropy);

            Trace.WriteLine(salt);
            Trace.WriteLine(entropy);
            Trace.WriteLine(hash);

            Assert.IsTrue(hash.Equals(asymmetric.HashString(password, salt, entropy), StringComparison.Ordinal));
        }
    }
}
