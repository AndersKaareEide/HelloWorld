using NUnit.Framework;

namespace RomanNumeralConverter.Test
{
    // ReSharper disable once InconsistentNaming
    public class RNConverterTests
    {
        private RNConverter converter;
        private string inputString;
        private int inputInt;
        private string resultString;
        private int resultInt;

        [SetUp]
        public void Setup()
        {
            converter = new RNConverter();
        }

        [Test]
        public void TestConvertIs()
        {
            inputString = "I";
            resultInt = converter.ToDecimal(inputString);
            Assert.That(resultInt, Is.EqualTo(1));

            inputString = "III";
            resultInt = converter.ToDecimal(inputString);
            Assert.That(resultInt, Is.EqualTo(3));
        }

        [Test]
        public void TestConvertVandIs()
        {
            inputString = "V";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(5));

            inputString = "VI";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(6));

            inputString = "VIII";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(8));
        }

        [Test]
        public void TestConvertSubtractionIV()
        {
            inputString = "IV";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(4));
        }

        [Test]
        public void TestConvertXs()
        {
            inputString = "X";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(10));

            inputString = "XXX";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(30));

            inputString = "XXVII";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(27));
        }

        [Test]
        public void TestConvertSubtractionXIX()
        {
            inputString = "XIX";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(19));
        }

        [Test]
        public void TestConvertLs()
        {
            inputString = "L";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(50));
        }

        [Test]
        public void TestConvertSubtractionWithL()
        {
            inputString = "XL";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(40));

            inputString = "XLIV";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(44));

            inputString = "XLIX";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(49));
        }

        [Test]
        public void TestConvertVarious()
        {
            inputString = "CDXLVII";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(447));

            inputString = "CCCXC";
            resultInt = converter.ToDecimal(inputString);

            Assert.That(resultInt, Is.EqualTo(390));
        }

        [Test]
        public void TestConvert1s()
        {
            inputInt = 1;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("I"));

            inputInt = 3;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("III"));
        }

        [Test]
        public void TestConvert5s()
        {
            inputInt = 5;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("V"));

            inputInt = 8;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("VIII"));
        }

        [Test]
        public void TestConvert4()
        {
            inputInt = 4;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("IV"));
        }

        [Test]
        public void TestConvert10s()
        {
            inputInt = 10;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("X"));

            inputInt = 38;
            resultString = converter.ToRoman(inputInt);

            Assert.That(resultString, Is.EqualTo("XXXVIII"));
        }

        [Test]
        public void TestConvertLotsOfNumbers()
        {
            TestConvertNumber(44, "XLIV");
            TestConvertNumber(277, "CCLXXVII");
            TestConvertNumber(1994, "MCMXCIV");
        }

        [Test]
        public void TestTwoWayConversionWithRandomNumbers()
        {
            for (int number = 0; number < 5000; number++)
            {
                string romanRep = converter.ToRoman(number);
                int decimalRep = converter.ToDecimal(romanRep);

                Assert.That(decimalRep, Is.EqualTo(number));
            }
        }

        private void TestConvertNumber(int input, string expected)
        {
            resultString = converter.ToRoman(input);

            Assert.That(resultString, Is.EqualTo(expected));
        }
    }
}
