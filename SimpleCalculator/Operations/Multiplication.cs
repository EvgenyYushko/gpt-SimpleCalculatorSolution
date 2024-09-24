using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Operations
{
    public class Multiplication : ICalculatorOperation
    {
        public double Operate(double a, double b)
        {
            return a * b;
        }
    }
}