using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleCalculator.Interfaces;
using SimpleCalculator.Operations;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICalculatorOperation, Addition>()
                .AddTransient<ICalculatorOperation, Subtraction>()
                .AddTransient<ICalculatorOperation, Multiplication>()
                .AddTransient<ICalculatorOperation, Division>()
                .AddTransient<Calculator>()
                .BuildServiceProvider();

            var calculator = serviceProvider.GetService<Calculator>();

            Console.WriteLine("Simple Calculator");
            Console.WriteLine("Enter first number:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter operation (+, -, *, /):");
            string operationSymbol = Console.ReadLine();

            ICalculatorOperation operation = operationSymbol switch
            {
                "+" => serviceProvider.GetService<ICalculatorOperation>(),
                "-" => serviceProvider.GetService<ICalculatorOperation>(),
                "*" => serviceProvider.GetService<ICalculatorOperation>(),
                "/" => serviceProvider.GetService<ICalculatorOperation>(),
                _ => throw new InvalidOperationException("Invalid operation")
            };

            try
            {
                double result = calculator.Calculate(a, b, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}