using SimpleCalculator.Interfaces;

namespace SimpleCalculator
{
    public class Calculator
    {
        public double Calculate(double a, double b, ICalculatorOperation operation)
        {
            return operation.Operate(a, b);
        }
    }
}