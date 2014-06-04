using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace KesselRun.Cryptography.Tests
{
    [TestClass]
    public class AsymmetricTests
    {
        private const string password = "Y7(ghjt5";

        [TestMethod]
        public void HashStringHashesString()
        {
            var asymmetric = new Asymmetric();

            var entropy = Utility.GenerateRandomString(20);

            var salt = Utility.GenerateSalt();

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

            var hash = asymmetric.HashString(password, salt, entropy);

            Trace.WriteLine(salt);
            Trace.WriteLine(entropy);
            Trace.WriteLine(hash);

            Assert.IsTrue(hash.Equals(asymmetric.HashString(password, salt, entropy), StringComparison.Ordinal));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HashStringHashesStringWherePasswordEmptyString()
        {
            var asymmetric = new Asymmetric();

            var entropy = string.Empty;

            var salt = Utility.GenerateSalt();
            var password = "";

            var hash = asymmetric.HashString(password, salt, entropy);
            
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HashStringHashesStringWherePasswordNull()
        {
            var asymmetric = new Asymmetric();

            var entropy = string.Empty;

            var salt = Utility.GenerateSalt();
            string password = null;

            var hash = asymmetric.HashString(password, salt, entropy);
            
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HashStringHashesStringWhereSaltNull()
        {
            var asymmetric = new Asymmetric();

            var entropy = string.Empty;

            string salt = null;

            var hash = asymmetric.HashString(password, salt, entropy);
            
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HashStringHashesStringWhereSaltIsEmptyString()
        {
            var asymmetric = new Asymmetric();

            var entropy = string.Empty;

            var salt = "";

            var hash = asymmetric.HashString(password, salt, entropy);
            
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashStringHashesStringWhereEntropyIsNull()
        {
            var asymmetric = new Asymmetric();

            string entropy = null;

            var salt = Utility.GenerateSalt();

            var hash = asymmetric.HashString(password, salt, entropy);
            
            Assert.Fail();
        }
    }
}
