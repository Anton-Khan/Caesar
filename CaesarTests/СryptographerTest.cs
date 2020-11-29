using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar;

namespace CaesarTests
{
    [TestClass]
    public class �ryptographerTest
    {
        [TestMethod]
        public void EncodeToDecode()
        {
            Cryptographer a = new Cryptographer();

            string input = "������, ���� ����� �����! � ��� ����� ����? Hello, my name is <Anton> 1..";

            Assert.AreEqual(input, a.Decode(a.Encode(input)), true);
        }

        [TestMethod]
        public void EncodeWithStepOne()
        {
            Cryptographer a = new Cryptographer(1);

            string input = "�����";
            string expected = "�����";

            string actual = a.Encode(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
