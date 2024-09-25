using System;

namespace SimpleCalculator.Operations
{
	// Класс Division реализует операцию деления для калькулятора
	public class Division : ICalculatorOperation
	{
		// Метод Operate выполняет деление двух чисел
		public double Operate(double a, double b)
		{
			// Проверка на деление на ноль
			if (b == 0)
			{
				throw new DivideByZeroException("Division by zero is not allowed.");
			}
			// Проверка на слишком большое значение делителя
			if (Math.Abs(b) <= double.Epsilon)
			{
				throw new OverflowException("Division result is too large.");
			}
			// Возвращает результат деления
			return a / b;
		}
	}
}