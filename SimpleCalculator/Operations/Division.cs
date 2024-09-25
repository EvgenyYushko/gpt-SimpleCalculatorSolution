using System;

namespace SimpleCalculator.Operations
{
	public class Division : ICalculatorOperation
	{
		public double Operate(double a, double b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException("Division by zero is not allowed.");
			}
			if (Math.Abs(b) <= double.Epsilon)
			{
				throw new OverflowException("Division result is too large.");
			}
			return a / b;
		}
	}
}