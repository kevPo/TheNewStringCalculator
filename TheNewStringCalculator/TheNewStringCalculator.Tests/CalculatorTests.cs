using System;
using NUnit.Framework;

namespace TheNewStringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void TestBaseCase()
        {
            var input = "1";

            var result = calculator.Calculate(input);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestNegativeBaseCase()
        {
            var input = "-1";

            var result = calculator.Calculate(input);

            Assert.That(result, Is.EqualTo(-1));
        }

        [TestCase("1+1", 2)]
        [TestCase("1*1", 1)]
        [TestCase("4/2", 2)]
        [TestCase("4-2", 2)]
        [TestCase("5%2", 1)]
        [TestCase("1*(2+4)", 6)]
        [TestCase("2*(3+2*3)", 18)]
        [TestCase("(3+(5-2))*2", 12)]
        public void TestRecursiveCase(String expression, Double expected)
        {
            var result = calculator.Calculate(expression);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("-1+3", 2)]
        [TestCase("3+-1", 2)]
        [TestCase("3--1", 4)]
        public void TestAddingNegatives(String expression, Double expected)
        {
            var result = calculator.Calculate(expression);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMultipleExpression()
        {
            var input = "1+2*4";

            var result = calculator.Calculate(input);

            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void TestOneDice()
        {
            var result = calculator.Calculate("1d10");
            Assert.That(result >= 1, Is.True);
            Assert.That(result <= 10, Is.True);
        }

        [Test]
        public void TestTwoDice()
        {
            var result = calculator.Calculate("2d10");
            Assert.That(result >= 1, Is.True);
            Assert.That(result <= 20, Is.True);
        }
    }
}
