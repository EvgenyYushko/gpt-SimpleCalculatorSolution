namespace SimpleCalculator.Operations
{
	public class Subtraction : ICalculatorOperation
	{
		public double Operate(double a, double b)
		{
			return a - b;
		}
	}
}