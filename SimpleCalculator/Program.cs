using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("Enter first number:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter operation (+, -, *, /):");
            string operation = Console.ReadLine();

            ICalculatorOperation calculatorOperation = operation switch
            {
                "+" => new Operations.Addition(),
                "-" => new Operations.Subtraction(),
                "*" => new Operations.Multiplication(),
                "/" => new Operations.Division(),
                _ => throw new InvalidOperationException("Invalid operation")
            };

            Calculator calculator = new Calculator(calculatorOperation);
            double result = calculator.Calculate(a, b);

            Console.WriteLine($"Result: {result}");
        }
    }
}