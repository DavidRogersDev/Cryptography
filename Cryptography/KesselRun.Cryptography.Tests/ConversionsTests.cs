using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KesselRun.Cryptography.Tests
{
    [TestClass]
    public class ConversionsTests
    {
        [TestMethod]
        public void HexStringToByteArray_Returns_Byte_Array()
        {
            //  Arrange
            string stringToConvert = "2AF3"; // taken from http://en.wikipedia.org/wiki/Hexadecimal

            //  Act
            byte[] actual = Conversions.HexStringToByteArray(stringToConvert);

            string st = Conversions.ByteArrayToHex(actual);
            //string st2 = Conversions.ByteArrayToString(actual);
            //string st3 = Conversions.BinaryToHex(actual);
            //string st3 = Conversions.HexStr(actual);
            string st4 = Conversions.ByteToHexBitFiddle(actual);
            //int number = int.Parse(stringToConvert, NumberStyles.HexNumber);

            //var bla = Conversions.HexByte(stringToConvert, 0, 0, 0);

            //  Assert
            Assert.IsInstanceOfType(actual, typeof(byte[]));

        }
    }
}
