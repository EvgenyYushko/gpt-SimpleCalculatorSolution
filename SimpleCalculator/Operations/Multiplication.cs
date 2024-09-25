using System;

namespace SimpleCalculator.Operations
{
	public class Multiplication : ICalculatorOperation
	{
		public double Operate(double a, double b)
		{
			if ((a == double.MaxValue && b > 1) || (b == double.MaxValue && a > 1) ||
				(a == double.MinValue && b < -1) || (b == double.MinValue && a < -1))
			{
				throw new OverflowException("Multiplication result is too large.");
			}
			return a * b;
		}
	}
}