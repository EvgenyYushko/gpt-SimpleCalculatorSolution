using SimpleCalculator.Interfaces;

namespace SimpleCalculator
{
    public class Calculator
    {
        private readonly ICalculatorOperation _operation;

        public Calculator(ICalculatorOperation operation)
        {
            _operation = operation;
        }

        public double Calculate(double a, double b)
        {
            return _operation.Operate(a, b);
        }
    }
}