using NUnit.Framework;
using SimpleCalculator;
using System;
using SimpleCalculator.Operations;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AdditionTest()
        {
            // Arrange
            var addition = new Addition();
            var calculator = new Calculator(addition);

            // Act
            double result = calculator.Calculate(5, 3);

            // Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SubtractionTest()
        {
            // Arrange
            var subtraction = new Subtraction();
            var calculator = new Calculator(subtraction);

            // Act
            double result = calculator.Calculate(5, 3);

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MultiplicationTest()
        {
            // Arrange
            var multiplication = new Multiplication();
            var calculator = new Calculator(multiplication);

            // Act
            double result = calculator.Calculate(5, 3);

            // Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void DivisionTest()
        {
            // Arrange
            var division = new Division();
            var calculator = new Calculator(division);

            // Act
            double result = calculator.Calculate(6, 3);

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DivisionByZeroTest()
        {
            // Arrange
            var division = new Division();
            var calculator = new Calculator(division);

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate(6, 0));
        }
    }
}