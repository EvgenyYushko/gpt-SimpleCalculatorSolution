using System;

namespace SimpleCalculator.Operations
{
	// Класс Multiplication реализует операцию умножения для калькулятора
	public class Multiplication : ICalculatorOperation
	{
		// Метод Operate выполняет умножение двух чисел
		public double Operate(double a, double b)
		{
			// Проверка на переполнение при умножении
			if ((a == double.MaxValue && b > 1) || (b == double.MaxValue && a > 1) ||
				(a == double.MinValue && b < -1) || (b == double.MinValue && a < -1))
			{
				throw new OverflowException("Multiplication result is too large.");
			}
			// Возвращает результат умножения
			return a * b;
		}
	}
}