namespace SimpleCalculator.Operations
{
	public class Addition : ICalculatorOperation
	{
		public double Operate(double a, double b)
		{
			return a + b;
		}
	}
}