using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar;

namespace CaesarTests
{
    [TestClass]
    public class СryptographerTest
    {
        [TestMethod]
        public void EncodeToDecode()
        {
            Cryptographer a = new Cryptographer();

            string input = "Привет, меня зовут Антон! А как зовут тебя? Hello, my name is <Anton> 1..";

            Assert.AreEqual(input, a.Decode(a.Encode(input)), true);
        }

        [TestMethod]
        public void EncodeWithStepOne()
        {
            Cryptographer a = new Cryptographer(1);

            string input = "АБВГД";
            string expected = "БВГДЕ";

            string actual = a.Encode(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
