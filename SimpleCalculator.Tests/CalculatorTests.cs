using NUnit.Framework;
using SimpleCalculator;
using System;
using SimpleCalculator.Operations;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void AdditionTest()
        {
            var addition = new Addition();
            double result = _calculator.Calculate(5, 3, addition);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SubtractionTest()
        {
            var subtraction = new Subtraction();
            double result = _calculator.Calculate(5, 3, subtraction);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MultiplicationTest()
        {
            var multiplication = new Multiplication();
            double result = _calculator.Calculate(5, 3, multiplication);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void DivisionTest()
        {
            var division = new Division();
            double result = _calculator.Calculate(6, 3, division);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DivisionByZeroTest()
        {
            var division = new Division();
            Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(6, 0, division));
        }
    }
}