using Microsoft.AspNetCore.Mvc;
using SimpleCalculator;
using SimpleCalculator.Operations;
using System;

namespace SimpleCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add(double a, double b)
        {
            var addition = new Addition();
            var calculator = new Calculator(addition);
            double result = calculator.Calculate(a, b);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(double a, double b)
        {
            var subtraction = new Subtraction();
            var calculator = new Calculator(subtraction);
            double result = calculator.Calculate(a, b);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(double a, double b)
        {
            var multiplication = new Multiplication();
            var calculator = new Calculator(multiplication);
            double result = calculator.Calculate(a, b);
            return Ok(result);
        }

        [HttpGet("divide")]
        public IActionResult Divide(double a, double b)
        {
            var division = new Division();
            var calculator = new Calculator(division);
            try
            {
                double result = calculator.Calculate(a, b);
                return Ok(result);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Division by zero is not allowed.");
            }
        }
    }
}