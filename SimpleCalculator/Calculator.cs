namespace SimpleCalculator
{
	// Класс Calculator отвечает за выполнение операций с числами
	public class Calculator
	{
		// Метод Calculate выполняет заданную операцию над двумя числами
		public double Calculate(double a, double b, ICalculatorOperation operation)
		{
			return operation.Operate(a, b);
		}
	}
}