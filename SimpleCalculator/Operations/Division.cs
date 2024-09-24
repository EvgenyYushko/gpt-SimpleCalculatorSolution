using System;
using SimpleCalculator.Interfaces;

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
            return a / b;
        }
    }
}