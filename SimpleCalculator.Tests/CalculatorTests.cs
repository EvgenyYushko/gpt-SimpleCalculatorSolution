using System;
using NUnit.Framework;
using Moq;
using SimpleCalculator.Operations;
using SimpleCalculator;

namespace SimpleCalculator.Tests
{
	[TestFixture]
	public class CalculatorTests
	{
		private Calculator _calculator;
		private Mock<ICalculatorOperation> _mockOperation;

		[SetUp]
		public void Setup()
		{
			_calculator = new Calculator();
			_mockOperation = new Mock<ICalculatorOperation>();
		}

		[Test]
		public void AdditionTest()
		{
			var addition = new Addition();
			Assert.AreEqual(8, _calculator.Calculate(5, 3, addition));
			Assert.AreEqual(0, _calculator.Calculate(-5, 5, addition));
			Assert.AreEqual(-10, _calculator.Calculate(-7, -3, addition));
		}

		[Test]
		public void SubtractionTest()
		{
			var subtraction = new Subtraction();
			Assert.AreEqual(2, _calculator.Calculate(5, 3, subtraction));
			Assert.AreEqual(-10, _calculator.Calculate(-5, 5, subtraction));
			Assert.AreEqual(-4, _calculator.Calculate(-7, -3, subtraction));
		}

		[Test]
		public void MultiplicationTest()
		{
			var multiplication = new Multiplication();
			Assert.AreEqual(15, _calculator.Calculate(5, 3, multiplication));
			Assert.AreEqual(-25, _calculator.Calculate(-5, 5, multiplication));
			Assert.AreEqual(21, _calculator.Calculate(-7, -3, multiplication));
		}

		[Test]
		public void DivisionTest()
		{
			var division = new Division();
			Assert.AreEqual(2, _calculator.Calculate(6, 3, division));
			Assert.AreEqual(-1, _calculator.Calculate(-5, 5, division));
			Assert.AreEqual(2.5, _calculator.Calculate(-5, -2, division));
		}

		[Test]
		public void DivisionByZeroTest()
		{
			var division = new Division();
			Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(6, 0, division));
		}

		[Test]
		public void LargeNumbersTest()
		{
			var addition = new Addition();
			var multiplication = new Multiplication();
			Assert.AreEqual(2000000000, _calculator.Calculate(1000000000, 1000000000, addition));
			Assert.AreEqual(1000000000000000000, _calculator.Calculate(1000000000, 1000000000, multiplication));
		}

		[Test]
		public void DecimalNumbersTest()
		{
			var addition = new Addition();
			var subtraction = new Subtraction();
			Assert.AreEqual(3.3, _calculator.Calculate(1.1, 2.2, addition), 0.0001);
			Assert.AreEqual(-1.1, _calculator.Calculate(1.1, 2.2, subtraction), 0.0001);
		}

		[Test]
		public void NegativeNumbersTest()
		{
			var multiplication = new Multiplication();
			var division = new Division();
			Assert.AreEqual(15, _calculator.Calculate(-3, -5, multiplication));
			Assert.AreEqual(-3, _calculator.Calculate(15, -5, division));
		}

		[Test]
		public void CalculatorUsesProvidedOperation()
		{
			_mockOperation.Setup(o => o.Operate(It.IsAny<double>(), It.IsAny<double>())).Returns(10);
			var result = _calculator.Calculate(5, 3, _mockOperation.Object);
			Assert.AreEqual(10, result);
			_mockOperation.Verify(o => o.Operate(5, 3), Times.Once);
		}

		[Test]
		public void CalculatorHandlesOperationException()
		{
			_mockOperation.Setup(o => o.Operate(It.IsAny<double>(), It.IsAny<double>())).Throws<InvalidOperationException>();
			Assert.Throws<InvalidOperationException>(() => _calculator.Calculate(5, 3, _mockOperation.Object));
		}

		[Test]
		public void CalculatorHandlesOverflow()
		{
			var multiplication = new Multiplication();
			Assert.Throws<OverflowException>(() => _calculator.Calculate(double.MaxValue, 2, multiplication));
		}

		[Test]
		public void CalculatorHandlesUnderflow()
		{
			var division = new Division();
			Assert.Throws<OverflowException>(() => _calculator.Calculate(1, double.Epsilon, division));
		}

		[Test]
		public void CalculatorHandlesNaN()
		{
			_mockOperation.Setup(o => o.Operate(It.IsAny<double>(), It.IsAny<double>())).Returns(double.NaN);
			var result = _calculator.Calculate(5, 3, _mockOperation.Object);
			Assert.IsTrue(double.IsNaN(result));
		}

		[Test]
		public void CalculatorHandlesInfinity()
		{
			_mockOperation.Setup(o => o.Operate(It.IsAny<double>(), It.IsAny<double>())).Returns(double.PositiveInfinity);
			var result = _calculator.Calculate(5, 3, _mockOperation.Object);
			Assert.IsTrue(double.IsPositiveInfinity(result));
		}
	}
}