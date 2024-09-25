namespace SimpleCalculator
{
	// Интерфейс ICalculatorOperation определяет метод для выполнения операций калькулятора
	public interface ICalculatorOperation
	{
		double Operate(double a, double b);
	}
}