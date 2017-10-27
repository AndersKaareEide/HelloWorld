using NUnit.Framework;

namespace HelloWorld.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        private ICalculator _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new Calculator();
        }

        [Test]
        public void TestAddFunction()
        {
            int result = _calc.Add(12, 4);
            Assert.That(result, Is.EqualTo(16));
        }

        [Test]
        public void TestMulFunction()
        {
            int result = _calc.Mul(2, 3);
            Assert.That(result, Is.EqualTo(6));
        }
    }
}